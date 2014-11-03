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
	/// Lógica de interacción para modSala.xaml
	/// </summary>
	public partial class modSala : UserControl
	{
        Connection.Objects.Sala sala = new Connection.Objects.Sala();
        public UserControl anterior;
        public Border borde;
        public bool modificar = false;
        public int id;
        private string direccionImagen = "";
        private string nombreImagen = "";
        public modSala()
		{
			this.InitializeComponent();
		}

        private void btnGuardar_Click(object sender, RoutedEventArgs e)
        {
            UtilidadS3 utilidad = new UtilidadS3();
            sala = (Sala) this.DataContext;
            // comentario 
            sala.fotografia = utilidad.subirSalaoEvento(sala.nombre, direccionImagen ,sala.nombre + "." + nombreImagen.Split('.')[1], true);
            if (modificar == false)
            {
                sala.guardar();
            }
            else
            {
                sala.modificar();
            }
            if (Connection.Objects.Error.isActivo())
            {
                MessageBox.Show(Connection.Objects.Error.nombreError, Connection.Objects.Error.descripcionError);
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

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            borde.Child = anterior;
        }

        private void btnBuscar_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void LayoutRoot_Loaded(object sender, RoutedEventArgs e)
        {
            //Si es para modificar
            if (modificar == true)
            {
                lblOperacion.Content = "Modificar Sala";
                //categ = categ.buscarPorID(id);
                txtNombre.Text = "Pendiente";
                //rtxtDescripcion.TextChanged = "";
                //txtFoto.Text = "";
            }
            else
            {
                lblOperacion.Content = "Nueva Sala";
            }
        }

        private void Border_MouseUp_1(object sender, MouseButtonEventArgs e)
        {
            OpenFileDialog dialogo = new OpenFileDialog();
            dialogo.Filter = "Archivos PNG (*.png)|*.png|Archivos JPG (*.jpg)|*.jpg";
            dialogo.InitialDirectory = "C:";
            dialogo.Title = "Seleccione la Imagen de la Sala";
            if (dialogo.ShowDialog() == true)
            {
                direccionImagen =  dialogo.FileName;
                nombreImagen = dialogo.SafeFileName;
                ImageSource imageSource = new BitmapImage(new Uri(dialogo.FileName));
                imageSala.Source = imageSource;
            }
        }
	}
}