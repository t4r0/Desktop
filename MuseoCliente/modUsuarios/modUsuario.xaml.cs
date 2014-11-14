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
using Microsoft.Win32;
using System.Threading.Tasks;
using System.Collections;

namespace MuseoCliente
{
	/// <summary>
	/// Lógica de interacción para modUsuario.xaml
	/// </summary>
	public partial class modUsuario : UserControl
	{
        Usuario usuario = new Usuario();
        Pais paises = new Pais();
        Grupo grupos = new Grupo();
        public UserControl anterior;
        public Border borde;
        public bool modificar = false;
        //Para las imagenes
        private string direccionImagen = "";
        private string nombreImagen = "";
        string nuevaDir = "";
        bool modificarImagen = false;
		public bool Modificar{
			get{ return modificar;}
			set{ modificar=value;}
		}
        public string userName;
        public modUsuario()
		{
			this.InitializeComponent();
		}

        private void LayoutRoot_Loaded(object sender, RoutedEventArgs e)
        {
            //Paises
            cmbPais.SelectedValuePath = "iso";
            cmbPais.DisplayMemberPath = "printable_name";
            cmbPais.ItemsSource = paises.regresarTodos();
            //Si es para modificar
            if (modificar == true)
            {
                lblOperacion.Content = "Modificar Usuario";
            }
            else
            {
                lblOperacion.Content = "Nuevo Usuario";
            }
        }
        private async void cargarPaises()
        {
            Task<ArrayList> task = Task<ArrayList>.Factory.StartNew(() => paises.regresarTodos());
            await task;
            cmbPais.DisplayMemberPath = "printable_name";
            cmbPais.SelectedValuePath = "iso";
            cmbPais.ItemsSource = task.Result;
        }
        private void btnGuardar_Click(object sender, RoutedEventArgs e)
        {
            UtilidadS3 utilidad = new UtilidadS3();
            usuario = (Usuario)this.DataContext;
            Imagen op = new Imagen();
            if (modificarImagen == true)
            {
                nuevaDir = op.cambia(direccionImagen, 256, 256, usuario.username);
                usuario.fotografia = utilidad.subirFotoUsuario(usuario.username, nuevaDir, usuario.username+nombreImagen.Split('.')[1]);
            }
            if (modificar == false)
            {
                usuario.guardar();
            }
            else
            {
                usuario.modificar();
            }
            if (Connection.Objects.Error.isActivo())
            {
                MessageBox.Show(Connection.Objects.Error.nombreError, Connection.Objects.Error.descripcionError);
            }
            else
            {
                MessageBox.Show("Correcto");
            }
            /* Pendiente voluntario
            if (chkVoluntario.IsChecked == true)
            {
                //
            }*/
        }

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            borde.Child = anterior;
        }

        private void cmbPais_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void cmbPais_Loaded(object sender, RoutedEventArgs e)
        {
            /*ComboBox cmb = (ComboBox)sender;
            Pais paises = new Pais();
            cmb.ItemsSource = paises.fetchAll();
            cmb.SelectedValuePath = "iso";
            cmb.DisplayMemberPath = "printable_name";*/
        }

        private void cmbGrupo_Loaded(object sender, RoutedEventArgs e)
        {
            /*ComboBox cmb =(ComboBox) sender;
            Grupo grupos = new Grupo();
            cmb.ItemsSource = grupos.fetchAll();
            cmb.SelectedValuePath = "id";
            cmb.DisplayMemberPath = "name";*/
        }

        private void Border_MouseUp(object sender, MouseButtonEventArgs e)
        {
            OpenFileDialog dialogo = new OpenFileDialog();
            dialogo.Filter = "Archivos PNG (*.png)|*.png|Archivos JPG (*.jpg)|*.jpg";
            dialogo.InitialDirectory = "C:";
            dialogo.Title = "Seleccione la Imagen del Afiche";
            if (dialogo.ShowDialog() == true)
            {
                direccionImagen = dialogo.FileName;
                nombreImagen = dialogo.SafeFileName;
                ImageSource imageSource = new BitmapImage(new Uri(dialogo.FileName));
                imageUser.Source = imageSource;
                modificarImagen = true;
            }
        }
	}
}