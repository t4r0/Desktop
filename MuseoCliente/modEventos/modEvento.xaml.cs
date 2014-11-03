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
        public modEvento()
		{
			this.InitializeComponent();
		}

        private void btnGuardar_Click(object sender, RoutedEventArgs e)
        {
            UtilidadS3 utilidad = new UtilidadS3();
            evento = (Eventos)this.DataContext;
            Imagen op = new Imagen();
            nuevaDir = op.cambia(direccionImagen, 800, 800, evento.nombre);
            evento.afiche = utilidad.subirSalaoEvento(evento.nombre, nuevaDir, evento.nombre + "." + nombreImagen.Split('.')[1], false);
            //eventohora
            evento.usuario = "JEscalante";
            if (modificar == false)
            {
                evento.guardar();
            }
            else
            {
                evento.modificar();
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

        string StringFromRichTextBox(RichTextBox rtb)
        {
            TextRange textRange = new TextRange(
                // TextPointer to the start of content in the RichTextBox.
                rtb.Document.ContentStart,
                // TextPointer to the end of content in the RichTextBox.
                rtb.Document.ContentEnd
            );

            // The Text property on a TextRange object returns a string 
            // representing the plain text content of the TextRange. 
            return textRange.Text;
        }

        private void btnBuscar_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void LayoutRoot_Loaded(object sender, RoutedEventArgs e)
        {
            cmbSala.DisplayMemberPath = "nombre";
            cmbSala.SelectedValuePath = "nombre";
            cmbSala.ItemsSource = salas.regresarTodos();
            //Si es para modificar
            if (modificar == true)
            {
                lblOperacion.Content = "Modificar Evento";
                //categ = categ.buscarPorID(id);
                //dpFecha.SelectedDate = 
                //rtxtDescripcion.TextChanged = "";
            }
            else
            {
                lblOperacion.Content = "Nuevo Evento";
            }
            
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
            }
        }
	}
}