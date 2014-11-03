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
	/// Lógica de interacción para modResultados.xaml
	/// </summary>
	public partial class modResultadosClas : UserControl
	{
        public string busqueda = "";
        Categoria categ = new Categoria();
        Coleccion colec = new Coleccion();
        public UserControl anterior;
        public Border borde;
        public modResultadosClas()
		{
			this.InitializeComponent();
		}

        private void LayoutRoot_Loaded(object sender, RoutedEventArgs e)
        {
            rbCateg.IsChecked = true;
        }

        private void rbCateg_Checked(object sender, RoutedEventArgs e)
        {
            if (categ.consultarNombre(busqueda) != null)
            {
                gvResultados.ItemsSource = categ.consultarNombre(busqueda);
                gvResultados.SelectedValuePath = "id";
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
                gvResultados.ItemsSource = colec.consultarNombre(busqueda);
                gvResultados.SelectedValuePath = "id";
            }
            else
            {
                MessageBox.Show("No hay colecciones con el nombre");
            }
        }

        private void btnEditar_Click(object sender, RoutedEventArgs e)
        {
            if (rbCateg.IsChecked == true)
            {
                modCategoria frm = new modCategoria();
                frm.borde = borde;
                frm.anterior = this.anterior;
                frm.modificar = true;
                frm.id = Convert.ToInt16(gvResultados.SelectedValue.ToString());
                borde.Child = frm;
            }
            if (rbColec.IsChecked == true)
            {
                modColeccion frm = new modColeccion();
                frm.borde = borde;
                frm.anterior = this.anterior;
                frm.modificar = true;
                frm.id = Convert.ToInt16(gvResultados.SelectedValue.ToString());
                borde.Child = frm;
            }
        }

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            borde.Child = anterior;
        }
	}
}