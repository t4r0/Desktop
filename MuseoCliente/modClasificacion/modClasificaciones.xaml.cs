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
            gvCategorias.SelectedValuePath = "id";
        }

        private async void CargarColecciones()
        {
            Task<ArrayList> t = Task<ArrayList>.Factory.StartNew(() => colec.regresarTodo());
            await t;
            gvColecciones.ItemsSource  = t.Result;
            gvColecciones.SelectedValuePath = "id";
        }

        private async void CargarClasificaciones()
        {
            Task<ArrayList> t = Task<ArrayList>.Factory.StartNew(() => clasif.regresarTodo());
            await t;
            gvClasificaciones.ItemsSource = t.Result;
            gvClasificaciones.SelectedValuePath = "id";
        }

        private async void buscarColecciones(string nombre)
        {
            Task<ArrayList> task = Task<ArrayList>.Factory.StartNew(() => colec.consultarNombre(nombre));
            await task;
            gvColecciones.ItemsSource = task.Result;
        }
        private async void buscarCategorias(string nombre)
        {
            Task<ArrayList> task = Task<ArrayList>.Factory.StartNew(() => categ.consultarNombre(nombre));
            await task;
            gvCategorias.ItemsSource = task.Result;
        }
        private async void buscarClasificacion(string nombre)
        {
            Task<ArrayList> task = Task<ArrayList>.Factory.StartNew(() => clasif.consultarNombre(nombre));
            await task;
            gvClasificaciones.ItemsSource = task.Result;
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

        private void btnNuevaClas_Click(object sender, RoutedEventArgs e)
        {
            modClasificacion frm = new modClasificacion();
            frm.borde = borde;
            frm.anterior = this;
            borde.Child = frm;
        }

        private void txtBuscarColecciones_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txtBuscarColecciones.Text.Length > 3)
                buscarColecciones(txtBuscarColecciones.Text);
            else
                CargarColecciones();
        }

        private void btnBuscarColecciones_Click(object sender, RoutedEventArgs e)
        {
            buscarColecciones(txtBuscarColecciones.Text);
        }

        private void btnEditarColeccion_Click(object sender, RoutedEventArgs e)
        {
            if (gvColecciones.SelectedValue != null)
            {
                modColeccion frm = new modColeccion();
                frm.borde = borde;
                frm.anterior = this;
                frm.modificar = true;
                frm.id = Convert.ToInt16(gvColecciones.SelectedValue.ToString());
                borde.Child = frm;
            }
            else
            {
                MessageBox.Show("Debe seleccionar una colección para editar", "Advertencia");
            }
        }

        private void btnEditarCategoria_Click(object sender, RoutedEventArgs e)
        {
            if (gvCategorias.SelectedItem != null)
            {
                modCategoria frm = new modCategoria();
                frm.borde = borde;
                frm.anterior = this;
                frm.modificar = true;
                frm.id = Convert.ToInt16(gvCategorias.SelectedValue.ToString());
                borde.Child = frm;
            }
            else
            {
                MessageBox.Show("Debe seleccionar una categoría para editar", "Advertencia");
            }
        }

        private void txtBuscarCategoria_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txtBuscarCategoria.Text.Length > 3)
                buscarCategorias(txtBuscarCategoria.Text);
            else
                CargarCategorias();
        }

        private void txtBuscarClasificacion_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txtBuscarClasificacion.Text.Length > 3)
                buscarClasificacion(txtBuscarClasificacion.Text);
            else
                CargarClasificaciones();
        }

        private void btnBuscarCategoria_Click(object sender, RoutedEventArgs e)
        {
            buscarCategorias(txtBuscarCategoria.Text);
        }

        private void btnBuscarClasificacion_Click(object sender, RoutedEventArgs e)
        {
            buscarClasificacion(txtBuscarClasificacion.Text);
        }

        private void btnEditarClasificacion_Click(object sender, RoutedEventArgs e)
        {
            if (gvClasificaciones.SelectedValue != null)
            {
                modClasificacion frm = new modClasificacion();
                frm.borde = borde;
                frm.anterior = this;
                frm.modificar = true;
                frm.DataContext = gvClasificaciones.SelectedItem;
                borde.Child = frm;
            }
            else
            {
                MessageBox.Show("Debe seleccionar una clasificación para editar", "Advertencia");
            }
        }

        private void btnEliminarClasificacion_Click(object sender, RoutedEventArgs e)
        {
            if (gvClasificaciones.SelectedValue != null)
            {
                Clasificacion clasificacion = new Clasificacion();
                clasificacion = (Clasificacion)gvClasificaciones.SelectedItem;
                clasificacion.eliminar();
                if (Connection.Objects.Error.isActivo())
                {
                    MessageBox.Show(Connection.Objects.Error.descripcionError, Connection.Objects.Error.nombreError);
                }
                else
                {
                    MessageBox.Show("Se ha eliminado correctamente", "Correcto");
                    CargarColecciones();
                }
            }
            else
            {
                MessageBox.Show("Debe seleccionar una clasificación antes de eliminar", "Advertencia");
            }
        }

        private void btnEliminarCategoria_Click(object sender, RoutedEventArgs e)
        {
            if (gvCategorias.SelectedItem != null)
            {
                Categoria categoria = new Categoria();
                categoria = (Categoria)gvCategorias.SelectedItem;
                //categoria
                if (Connection.Objects.Error.isActivo())
                {
                    MessageBox.Show(Connection.Objects.Error.descripcionError, Connection.Objects.Error.nombreError);
                }
                else
                {
                    MessageBox.Show("Se ha eliminado correctamente", "Correcto");
                    CargarCategorias();
                }
            }
            else
            {
                MessageBox.Show("Debe seleccionar una categoría antes de eliminar", "Advertencia");
            }
        }

        private void btnEliminarColeccion_Click(object sender, RoutedEventArgs e)
        {
            if (gvColecciones.SelectedValue != null)
            {
                Coleccion coleccion = new Coleccion();
                coleccion = (Coleccion)gvColecciones.SelectedItem;
                //coleccion
                if (Connection.Objects.Error.isActivo())
                {
                    MessageBox.Show(Connection.Objects.Error.descripcionError, Connection.Objects.Error.nombreError);
                }
                else
                {
                    MessageBox.Show("Se ha eliminado correctamente", "Correcto");
                    CargarCategorias();
                }
            }
            else
            {
                MessageBox.Show("Debe seleccionar una colección antes de eliminar", "Advertencia");
            }
        }
	}
}