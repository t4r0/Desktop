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
using System.Collections;
using MuseoCliente.Connection.Objects;
using System.Threading.Tasks;
namespace MuseoCliente
{
	/// <summary>
	/// Lógica de interacción para modInventario.xaml
	/// </summary>
	public partial class modInventario : UserControl
	{
        Connection.Objects.Pieza piezas = new Connection.Objects.Pieza();
        public Border borde;
        public modInventario()
		{
			this.InitializeComponent();
		}

        private void LayoutRoot_Loaded(object sender, RoutedEventArgs e)
        {
            /*Falta consulta de piezas que estan en bodega y las que estan en exhibicion
            gvBodega.ItemsSource = ;
            gvExhibicion.ItemsSource = ;*/
        }

        private void btnNuevaPieza_Click(object sender, RoutedEventArgs e)
        {
            modPieza frm = new modPieza();
            frm.borde = borde;
            //frm.anterior = this;
            borde.Child = frm;
        }

        private void btnBuscar_Click(object sender, RoutedEventArgs e)
        {
            modResultadosPiezas frm = new modResultadosPiezas();
            frm.busqueda = txtBuscar.Text;
            frm.borde = borde;
            frm.anterior = this;
            borde.Child = frm;
        }

        private void btnNuevaClas_Click(object sender, RoutedEventArgs e)
        {
            modClasificacion frm = new modClasificacion();
            frm.borde = borde;
            frm.anterior = this;
            borde.Child = frm;
        }

        private void ListBox_Loaded_1(object sender, RoutedEventArgs e)
        {
            CargarColecciones();
        }

        private async void CargarColecciones()
        {
            Coleccion col = new Coleccion();
            Task<List<Coleccion>> t = Task<List<Coleccion>>.Factory.StartNew(() =>col.fetchAll());
            await t;
            listColecciones.ItemsSource = t.Result;
            listColecciones.DisplayMemberPath = "nombre";
        }

        private void listColecciones_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ListBox list = sender as ListBox;
            Coleccion col = list.SelectedItem as Coleccion;
            if (list != null)
            {
                if (list.SelectedItem != null)
                {
                    CargarCategorias(col);
                    CargarPiezas("?coleccion=" + col.id);
                }
            }

        }

        private async void CargarCategorias(Coleccion col)
        {
            Task<List<Categoria>> t = Task<List<Categoria>>.Factory.StartNew(() => col.ObtenerCategorias());
            await t;
            catsPanel.Visibility = Visibility.Visible;
            listCats.ItemsSource = t.Result;
            listCats.DisplayMemberPath = "nombre";
            clasPanel.Visibility = Visibility.Collapsed;
            addButton.Visibility = Visibility.Hidden;
        }

        private void listCats_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ListBox list = sender as ListBox;
            Coleccion col = listColecciones.SelectedItem as Coleccion;
            Categoria cat = list.SelectedItem as Categoria;
            if (list != null)
            {
                if (cat != null && col!=null)
                {
                    CargarClasificaciones(cat);
                    CargarPiezas("?coleccion=" + col.id + "&categoria=" + cat.id);
                }
            }
        }
        private async void CargarPiezas(string filtro)
        {
            Pieza pieza = new Pieza();
            Task<List<Pieza>> t = Task<List<Pieza>>.Factory.StartNew(() => pieza.GetAsCollection(filtro));
            await t;
            listPiezas.ItemsSource = t.Result;
        }
        private async void CargarClasificaciones(Categoria cat)
        {
            Task<List<Clasificacion>> t = Task<List<Clasificacion>>.Factory.StartNew(() => cat.regresarClasificacion());
            await t;
            clasPanel.Visibility = Visibility.Visible;
            listClas.ItemsSource = t.Result;
            listClas.DisplayMemberPath = "nombre";
        }

        private void listClas_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ListBox list = sender as ListBox;
            Clasificacion cla = list.SelectedItem as Clasificacion;
            if (list != null)
            {
                if (cla != null)
                {
                    addButton.Visibility = Visibility.Visible;
                    CargarPiezas("?clasificacion=" + cla.id);
                }
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Clasificacion cla= listClas.SelectedItem as Clasificacion;
            Pieza pieza = new Pieza() { codigo = "M." + cla.codigo + "." + (cla.piezas + 1), clasificacion=cla.id};
            modPieza frm = new modPieza() { DataContext = pieza, Crear=true};
            frm.borde = this.Parent as Border;
            frm.anterior = this;
            frm.borde.Child = frm;
        }

        private void ListView_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            ListView view = sender as ListView;
            if (view != null && view.SelectedItem != null)
            {
                editButton.Visibility = Visibility.Visible;
            }
            else
            {
                editButton.Visibility = Visibility.Hidden;
            }
        }

        private void editButton_Click(object sender, RoutedEventArgs e)
        {
            Pieza pieza = listPiezas.SelectedItem as Pieza;
            if (pieza != null)
            {               
                modPieza frm = new modPieza() { DataContext = pieza, Crear=false};
                frm.borde = this.Parent as Border;
                frm.anterior = this;
                frm.borde.Child = frm;                
            }
        }
	}
}