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

namespace MuseoCliente
{
	/// <summary>
	/// Lógica de interacción para modEvento.xaml
	/// </summary>
	public partial class modEvento : UserControl
	{
        Connection.Objects.Eventos evento = new Connection.Objects.Eventos();
        Connection.Objects.Sala salas = new Connection.Objects.Sala();
        public modEvento()
		{
			this.InitializeComponent();
		}

        private void btnGuardar_Click(object sender, RoutedEventArgs e)
        {
            //evento.sala = Convert.ToInt16(cmbSala.SelectedValue.ToString());
            evento.sala = 3;
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

        private void btnBuscar_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dialogo = new OpenFileDialog();
            dialogo.Filter = "Archivos PNG (*.png)|*.png|Archivos JPG (*.jpg)|*.jpg";
            dialogo.InitialDirectory = "C:";
            dialogo.Title = "Seleccione la Imagen del Afiche";
            dialogo.ShowDialog();
            if (dialogo.ShowDialog() == true)
                txtAfiche.Text = dialogo.FileName;
        }

        private void LayoutRoot_Loaded(object sender, RoutedEventArgs e)
        {
            cmbSala.DisplayMemberPath = "nombre";
            cmbSala.SelectedValuePath = "id";
            cmbSala.ItemsSource = salas.regresarTodos();
        }
	}
}