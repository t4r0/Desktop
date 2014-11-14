using Microsoft.Win32;
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
using System.Globalization;
using System.Threading.Tasks;
using System.Collections;

namespace MuseoCliente
{
	/// <summary>
	/// Lógica de interacción para modEvento.xaml
	/// </summary>
	public partial class modEvento : UserControl
	{
        Eventos evento = new Eventos();
        Sala salas = new Sala();
        public UserControl anterior;
        public Border borde;
        public bool modificar = false;
        public string nombre;
        private string direccionImagen = "";
        private string nombreImagen = "";
        string nuevaDir = "";
        bool modificarImagen = false;
        public modEvento()
		{
			this.InitializeComponent();
		}

        private void btnGuardar_Click(object sender, RoutedEventArgs e)
        {
            UtilidadS3 utilidad = new UtilidadS3();
            evento = (Eventos)this.DataContext;
            Imagen op = new Imagen();
            if (modificarImagen == true)
            {
                nuevaDir = op.cambia(direccionImagen, 800, 800, evento.nombre);
                evento.afiche = utilidad.subirSalaoEvento(evento.nombre, nuevaDir, evento.nombre + "." + nombreImagen.Split('.')[1], false);
            }
            evento.usuario = "JEscalante";
            evento.fecha = dpFecha.SelectedDate.Value.Date;
            if (modificar == false)
            {
                evento.guardar();
                modificarImagen = false;
            }
            else
            {
                evento.modificar();
                modificarImagen = false;
            }
            if (Connection.Objects.Error.isActivo())
            {
                MessageBox.Show(Connection.Objects.Error.descripcionError, Connection.Objects.Error.nombreError);
            }
            else
            {
                MessageBox.Show("Correcto");
            }
        }

        private void btnBuscar_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void LayoutRoot_Loaded(object sender, RoutedEventArgs e)
        {
            cargarSalas();
            //Si es para modificar
            if (modificar == true)
            {
                lblOperacion.Content = "Modificar Evento";
            }
            else
            {
                lblOperacion.Content = "Nuevo Evento";
            }
        }
        private async void cargarSalas()
        {
            cmbSala.DisplayMemberPath = "nombre";
            cmbSala.SelectedValuePath = "nombre";
            Task<ArrayList> task = Task<ArrayList>.Factory.StartNew(() => salas.regresarTodos());
            await task;
            cmbSala.ItemsSource = task.Result;
        }
        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            borde.Child = anterior;
        }

        private void imageAfiche_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            
        }

        private void Border_MouseUp_1(object sender, MouseButtonEventArgs e)
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
                imageAfiche.Source = imageSource;
                modificarImagen = true;
            }
        }
	}
}