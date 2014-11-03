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
	/// Lógica de interacción para modInvestigacion.xaml
	/// </summary>
	public partial class modInvestigacion : UserControl
	{
        //Pendiente Editor: Porque es el usuario que ingresa -
        Connection.Objects.Pieza piezas = new Connection.Objects.Pieza();
        Connection.Objects.Autor autores = new Connection.Objects.Autor();
        Connection.Objects.Investigacion investigacion = new Connection.Objects.Investigacion();
        public UserControl anterior;
        public Border borde;
        public bool modificar = false;
        public int id;
        bool publicado = false;
        public modInvestigacion()
		{
			this.InitializeComponent();
		}

        private void LayoutRoot_Loaded(object sender, RoutedEventArgs e)
        {
            //Cargar datos
            cmbAutor.DisplayMemberPath = "nombre";
            cmbAutor.SelectedValuePath = "id";
            //Si es para modificar
            if (modificar == true)
            {
                lblOperacion.Content = "Modificar Investigación";
                //txtCodigoPieza.Text = pieza.codigo;
                //txtNombrePieza.Text = pieza.nombre;
                //cmbAutor.ItemsSource = piezas.nombre;

            }
            else
            {
                lblOperacion.Content = "Nueva Categoría";
                cmbAutor.ItemsSource = autores.regresarTodos();
            }
        }

        private void btnGuardar_Click(object sender, RoutedEventArgs e)
        {
            investigacion.titulo = txtTitulo.Text;
            investigacion.contenido = txtDescripcion.Text;
            investigacion.resumen = txtResumen.Text;
            // Error en la clase = investigacion.autor = Convert.ToInt16(cmbAutor.SelectedValue.ToString());
            investigacion.publicado = publicado; //Verificar la clase porque en la BD esta como tinyInt
            // Pregunta: la fecha es con un Now()? o puede seleccionar fecha? investigacion.fecha = ????;
            if (modificar == false)
            {
                investigacion.guardar();
            }
            else
            {
                investigacion.modificar();
            }
            if (Connection.Objects.Error.isActivo())
            {
                MessageBox.Show(Connection.Objects.Error.nombreError, Connection.Objects.Error.descripcionError);
            }
            else
            {
                MessageBox.Show("Correcto");
            }
            //Falta la clase para que investigacion tenga pieza
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

        private void btnPublicar_Click(object sender, RoutedEventArgs e)
        {
            //Codigo para publicar en la web
            publicado = true;
        }

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            borde.Child = anterior;
        }
	}
}