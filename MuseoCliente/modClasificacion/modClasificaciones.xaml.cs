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
namespace MuseoCliente
{
	/// <summary>
	/// Lógica de interacción para modClasificaciones.xaml
	/// </summary>
	public partial class modClasificaciones : UserControl
	{
        Connection.Objects.Categoria categ = new Connection.Objects.Categoria();
        Connection.Objects.Coleccion colec = new Connection.Objects.Coleccion();
        Connection.Objects.Clasificacion clasif = new Connection.Objects.Clasificacion();
        public Border borde;
        public modClasificaciones()
		{
			this.InitializeComponent();
		}

        private void LayoutRoot_Loaded(object sender, RoutedEventArgs e)
        {
            CargarCategorias();
            CargarColecciones();
            CargarClasificaciones();
        }

        private async void CargarCategorias()
        {
            Task<ArrayList> t = Task<ArrayList>.Factory.StartNew(() => categ.regresarTodo());
            await t;
            gvCategorias.ItemsSource = t.Result;
        }

        private async void CargarColecciones()
        {
            Task<ArrayList> t = Task<ArrayList>.Factory.StartNew(() => colec.regresarTodo());
            await t;
            gvColecciones.ItemsSource  = t.Result;
        }

        private async void CargarClasificaciones()
        {
            Task<ArrayList> t = Task<ArrayList>.Factory.StartNew(() => clasif.regresarTodo());
            await t;
            gvClasificaciones.ItemsSource = t.Result;
        }
        private void btnNuevaCateg_Click(object sender, RoutedEventArgs e)
        {
            modCategoria frm = new modCategoria();
            frm.borde = borde;
            frm.anterior = this;
            borde.Child = frm;
        }

        private void btnNuevaColec_Click(object sender, RoutedEventArgs e)
        {
            modColeccion frm = new modColeccion();
            frm.borde = borde;
            frm.anterior = this;
            borde.Child = frm;
        }

        private void btnBuscar_Click(object sender, RoutedEventArgs e)
        {
            modResultadosClas frm = new modResultadosClas();
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
	}
}