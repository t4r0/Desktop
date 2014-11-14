using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using MuseoCliente.Connection.Objects;
using MuseoCliente.Properties;
using System.Threading.Tasks;
using Microsoft.Win32;

namespace MuseoCliente
{
	/// <summary>
	/// Lógica de interacción para modPieza.xaml
	/// </summary>
	public partial class modPieza : UserControl
	{
        
        public Border borde;
        public UIElement anterior;
        string ruta;
        public bool Crear
        {
            get;
            set;
        }
        public modPieza()
		{
			this.InitializeComponent();
		}

        private void LayoutRoot_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void btnGuardar_Click(object sender, RoutedEventArgs e)
        {
            Pieza pieza = DataContext as Pieza;
            if (Crear)
            {
                pieza.responsableRegistro = Settings.user.username;
                pieza.guardar();
                CrearFoto(ruta, pieza.codigo);
            }
            else
            {
                pieza.modificar();
            }

            if (Error.isActivo())
            {
                MessageBox.Show(Error.descripcionError, Error.nombreError);
            }
            else
            {
                MessageBox.Show("Guardado con éxito");
            }
        }

        private async void CargarPaises()
        {
            Pais paises = new Pais();
            Task<List<Pais>> t = Task<List<Pais>>.Factory.StartNew(() => paises.fetchAll());
            await t;
            cmbPais.ItemsSource = t.Result;
            cmbPais.DisplayMemberPath = "printable_name";
            cmbPais.SelectedValuePath = "iso";
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            CargarPaises();
        }

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            Border border = this.Parent as Border;
            border.Child = this.anterior;
        }

        private void Image_MouseUp_1(object sender, MouseButtonEventArgs e)
        {
            OpenFileDialog dialogo = new OpenFileDialog();
            Pieza pieza = DataContext as Pieza;
            dialogo.Filter = "Archivos PNG (*.png)|*.png|Archivos JPG (*.jpg)|*.jpg";
            dialogo.InitialDirectory = "C:";
            dialogo.Title = "Seleccione la Imagen del Afiche";
            if (dialogo.ShowDialog() == true)
            {
                string archivo = dialogo.SafeFileName;
                string ruta = TratarImagen(dialogo.FileName,"temp_" + pieza.codigo);
                SubirFoto(archivo, ruta);
            }
        }

        private string TratarImagen(string direccion, string nombre)
        {
            Imagen im = new Imagen();
            return im.cambia(direccion, 800, 800, nombre);

        }

        private async void SubirFoto(string archivo, string ruta)
        {
            Pieza pieza = DataContext as Pieza;
            UtilidadS3 utilidad = new UtilidadS3();
            Task<string> t =
                Task<string>.Factory.StartNew(() => utilidad.subirArchivoPieza(pieza.codigo, ruta, archivo, true));
            await t;
            if (!Crear)
            {
                CrearFoto(t.Result, pieza.codigo);
            }
            else
            {
                ruta = t.Result;
                ImageSource imageSource = new BitmapImage(new Uri(ruta));
                foto.Source = imageSource;
            }
      
        }

        private async void CrearFoto(string ruta, string codigo)
        {
            Fotografia fotografia = new Fotografia()
            {
                perfil = true,
                pieza = codigo,
                ruta = ruta,
                tipo = 1
            };
            Task t = Task.Factory.StartNew(()=>fotografia.guardar());
            await t;
            if (!Error.isActivo())
            {
                ImageSource imageSource = new BitmapImage(new Uri(fotografia.ruta));
                foto.Source = imageSource;
            }
            else
                MessageBox.Show("Ocurrio un error al subir la fotografia");
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dialogo = new OpenFileDialog();
            Pieza pieza = DataContext as Pieza;
            dialogo.Filter = "Archivos PDF (*.pdf)|*.pdf|Archivos txt (*.txt)|*.txt";
            dialogo.InitialDirectory = "C:";
            dialogo.Title = "Seleccione el archivo de registro";
            if (dialogo.ShowDialog() == true)
            {
                string archivo = dialogo.SafeFileName;
                string ruta = dialogo.FileName;
                SubirArchivo(ruta, archivo);
            }

        }

        public async void SubirArchivo(string ruta, string nombre)
        {
            Pieza pieza = DataContext as Pieza;
            UtilidadS3 utilidad = new UtilidadS3();
            Task<string> t = Task<string>.Factory.StartNew(()
                => utilidad.subirArchivoPieza(pieza.codigo, ruta, nombre, false));
            await t;
            fileTxt.Text = t.Result;
        }
	}
}