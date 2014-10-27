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
	/// Lógica de interacción para modResultados.xaml
	/// </summary>
	public partial class modResultadosClas : UserControl
	{
        public string busqueda = "";
        private Connection.Objects.Categoria categ = new Connection.Objects.Categoria();
        private Connection.Objects.Coleccion colec = new Connection.Objects.Coleccion();
        public UserControl anterior;
        public Border borde;
        public modResultadosClas()
		{
			this.InitializeComponent();
		}

        private void LayoutRoot_Loaded(object sender, RoutedEventArgs e)
        {
            //gvResultados.ItemsSource = 
        }

        private void rbCateg_Checked(object sender, RoutedEventArgs e)
        {
            if (categ.consultarNombre(busqueda) != null)
            {
                gvResultados.SelectedValue = "nombre";
                gvResultados.ItemsSource = categ.consultarNombre(busqueda);
            }
            else
            {
                MessageBox.Show("No hay categorias con el nombre");
            }
        }

        private void rbColec_Checked(object sender, RoutedEventArgs e)
        {
            if (colec.consultarNombre(busqueda) != null)
            {
                gvResultados.SelectedValue = "nombre";
                gvResultados.ItemsSource = colec.consultarNombre(busqueda);
            }
            else
            {
                MessageBox.Show("No hay colecciones con el nombre");
            }
        }

        private void btnEditar_Click(object sender, RoutedEventArgs e)
        {
            modCategoria frm = new modCategoria();
            frm.borde = borde;
            frm.anterior = this;
            frm.id = Convert.ToInt16(gvResultados.SelectedValue.ToString());
            MessageBox.Show(gvResultados.SelectedValue.ToString());
            borde.Child = frm;
        }

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            borde.Child = anterior;
        }
	}
}