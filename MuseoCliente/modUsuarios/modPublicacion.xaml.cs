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

namespace MuseoCliente
{
	/// <summary>
	/// Lógica de interacción para modPublicacion.xaml
	/// </summary>
	public partial class modPublicacion : UserControl
	{
        //Pendiente lo de voluntarios
        Connection.Objects.Publicacion publicacion = new Connection.Objects.Publicacion();
        public UserControl anterior;
        public Border borde;
        public bool modificar = false;
        public int id;
        public modPublicacion()
		{
			this.InitializeComponent();
		}

        private void LayoutRoot_Loaded(object sender, RoutedEventArgs e)
        {
            //Si es para modificar
            if (modificar == true)
            {
                lblOperacion.Content = "Modificar Publicación";
                //
            }
            else
            {
                lblOperacion.Content = "Nueva Publicación";
            }
        }

        private void btnGuardar_Click(object sender, RoutedEventArgs e)
        {
            publicacion.nombre = txtNombre.Text;
            publicacion.publicacion = StringFromRichTextBox(rtxtPublicacion);
            if (modificar == false)
            {
                publicacion.guardar();
            }
            else
            {
                publicacion.modificar();
            }
            if (Connection.Objects.Error.isActivo())
            {
                MessageBox.Show(Connection.Objects.Error.nombreError, Connection.Objects.Error.descripcionError);
            }
            else
            {
                MessageBox.Show("Correcto");
            }
            //Pendiente clase para linkear la investigacion
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
	}
}