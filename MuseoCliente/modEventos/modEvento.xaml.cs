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
	/// Lógica de interacción para modEvento.xaml
	/// </summary>
	public partial class modEvento : UserControl
	{
        Connection.Objects.Eventos evento = new Connection.Objects.Eventos();
        public modEvento()
		{
			this.InitializeComponent();
		}

        private void btnGuardar_Click(object sender, RoutedEventArgs e)
        {
            evento.sala = 1;
            evento.nombre = txtNombre.Text;
            evento.fecha = dpFecha.SelectedDate.Value;
            evento.descripcion = StringFromRichTextBox(rtxtDescripcion);
            evento.afiche = txtAfiche.Text;
            evento.usuario = 1;
            evento.guardar();
            if (Connection.Objects.Error.isActivo())
            {
                MessageBox.Show(Connection.Objects.Error.descripcionError, Connection.Objects.Error.nombreError);
            }
            else
            {
                MessageBox.Show("Bien puto Ursaring");
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
	}
}