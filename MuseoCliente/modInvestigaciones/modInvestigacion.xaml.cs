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
using System.Threading.Tasks;
using System.Collections;
using MuseoCliente.Properties;

namespace MuseoCliente
{
	/// <summary>
	/// Lógica de interacción para modInvestigacion.xaml
	/// </summary>
	public partial class modInvestigacion : UserControl
	{
        //Pendiente Editor: Porque es el usuario que ingresa -
        Pieza piezas = new Pieza();
        Autor autores = new Autor();
        Investigacion investigacion = new Investigacion();
        public UserControl anterior;
        public Border borde;
        public bool modificar = false;
        public int id;
        public modInvestigacion()
		{
			this.InitializeComponent();
		}

        private void LayoutRoot_Loaded(object sender, RoutedEventArgs e)
        {
            investigacion = (Investigacion) this.DataContext;
            //Cargar datos
            cmbAutor.ItemsSource = autores.regresarTodos();
            cmbAutor.DisplayMemberPath = "nombre";
            cmbAutor.SelectedValuePath = "id";
            //Si es para modificar
            if (modificar == true)
            {
                lblOperacion.Content = "Modificar Investigación";
                //ArrayList listado = investigacion.regresarPiezas();
                List<string> lista = new List<string>();
                foreach(LinkInvestigacion link in investigacion.regresarLinkInvestigacion())
                {
                    lista.Add(link.link);
                }
                LinksReferencia.LoadOptions(lista);
                gvPiezasGuardadas.ItemsSource = investigacion.regresarPiezas();
                cmbAutor.SelectedValue = investigacion.autor;
            }
            else
            {
                lblOperacion.Content = "Nueva Categoría";
                gvPiezasGuardadas.ItemsSource = new ArrayList();
            }
        }

        private void btnGuardar_Click(object sender, RoutedEventArgs e)
        {
            investigacion = (Investigacion) this.DataContext;
            investigacion.autor = (int) cmbAutor.SelectedValue;
            investigacion.editor = Settings.user.username;
            List<string> listado = LinksReferencia.GetOptions();
            ArrayList piezas = (ArrayList) gvPiezasGuardadas.ItemsSource;
            if (modificar == false)
            {
                investigacion.ingresarPiezas(piezas.ToList<Pieza>());
                foreach(string link in LinksReferencia.GetOptions())
                    if (!link.Equals("Opcion"))
                        investigacion.ingresarLinks(link);
                investigacion.fecha = DateTime.Now;
                investigacion.guardar();
            }
            else
            {
                investigacion.ingresarPiezas(piezas.ToList<Pieza>());
                List<LinkInvestigacion> lista = new List<LinkInvestigacion>();
                foreach (string link in LinksReferencia.GetOptions())
                    if (!link.Equals("Opcion"))
                        lista.Add(new LinkInvestigacion(link));
                investigacion.ingresarLinks(lista);
                investigacion.modificar();
            }

            if (Connection.Objects.Error.isActivo())
            {
                MessageBox.Show(Connection.Objects.Error.nombreError, Connection.Objects.Error.descripcionError);
            }
            else
            {
                MessageBox.Show("Correcto");
                borde.Child = anterior;
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

        private void btnPublicar_Click(object sender, RoutedEventArgs e)
        {
            //Codigo para publicar en la web
        }

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            borde.Child = anterior;
        }

        private void btnSeleccionar_Click(object sender, RoutedEventArgs e)
        {
            string codigo = txtCodigo.Text;
            buscarPiezas(codigo);
        }
        private async void buscarPiezas(string codigo)
        {
            Task<ArrayList> task = Task<ArrayList>.Factory.StartNew(()=>piezas.buscarCodigo(codigo));
            await task;
            gvPiezas.ItemsSource = task.Result;
        }

        private void txtCodigo_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txtCodigo.Text.Length > 3)
            {
                buscarPiezas(txtCodigo.Text);
            }
            else
            {
                gvPiezas.ItemsSource = null;
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Pieza piezaSeleccionada = (Pieza) gvPiezas.SelectedItem;

            gvPiezasGuardadas.ItemsSource = this.verificarPieza(piezaSeleccionada);
            gvPiezasGuardadas.Items.Refresh();
            //gvPiezasGuardadas.Items.Add(piezaSeleccionada);
        }
        private ArrayList verificarPieza(Pieza pieza)
        {
            ArrayList listado = (ArrayList) gvPiezasGuardadas.ItemsSource;
            Boolean existePieza = false;
            if (listado.Count == 0) 
            {
                listado.Add(pieza);
                existePieza = true;
            } 
            for (int i = 0; i < listado.Count; i++) 
            {
                Pieza piezaActual = (Pieza) listado[i];

                if (piezaActual.codigo == pieza.codigo)
                {
                    existePieza = true;
                    break;
                }
            }
            if (!existePieza)
                listado.Add(pieza);
            return listado;
        }
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            ArrayList listado = (ArrayList)gvPiezasGuardadas.ItemsSource;
            Pieza piezaSeleccionada = (Pieza) gvPiezasGuardadas.SelectedItem;
            for (int i = 0; i < listado.Count; i++)
            {
                Pieza piezaActual = (Pieza)listado[i];
                if (piezaActual.codigo == piezaSeleccionada.codigo)
                {
                    listado.RemoveAt(i);
                    break;
                }
            }
            gvPiezasGuardadas.ItemsSource = listado;
            gvPiezasGuardadas.Items.Refresh();
        }
	}
}