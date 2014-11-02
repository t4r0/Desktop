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
	/// Lógica de interacción para modClasificacion.xaml
	/// </summary>
	public partial class modClasificacion : UserControl
	{
        Connection.Objects.Clasificacion clasificacion = new Connection.Objects.Clasificacion();
        Connection.Objects.Ficha fichas = new Connection.Objects.Ficha();
        Connection.Objects.Categoria categ = new Connection.Objects.Categoria();
        Connection.Objects.Coleccion colec = new Connection.Objects.Coleccion();
        public UserControl anterior;
        public Border borde;
        public bool modificar = false;
        public int id;
        public modClasificacion()
		{
			this.InitializeComponent();
		}

        private void LayoutRoot_Loaded(object sender, RoutedEventArgs e)
        {
            //Cargar datos
            //Fichas
            cmbFicha.DisplayMemberPath = "nombre";
            cmbFicha.SelectedValuePath = "id";
            cmbFicha.ItemsSource = fichas.regresarTodos();
            //Categorias
            cmbCategoria.DisplayMemberPath = "nombre";
            cmbCategoria.SelectedValue = "id";
            cmbCategoria.ItemsSource = categ.regresarTodo();
            //Coleccion
            cmbColeccion.DisplayMemberPath = "nombre";
            cmbColeccion.SelectedValue = "id";
            cmbColeccion.ItemsSource = colec.regresarTodo();
            //Si es para modificar
            if (modificar == true)
            {
                lblOperacion.Content = "Modificar Clasificación";
                //
            }
            else
            {
                lblOperacion.Content = "Nueva Clasificación";
            }
        }

        private void btnGuardar_Click(object sender, RoutedEventArgs e)
        {
            clasificacion.codigo = txtCodigo.Text;
            /*clasificacion.ficha = Convert.ToInt16(cmbFicha.SelectedValue);
            clasificacion.categoria = Convert.ToInt16(cmbCategoria.SelectedValue);
            clasificacion.coleccion = Convert.ToInt16(cmbColeccion.SelectedValue);
            if (modificar == false)
            {
                clasificacion.guardar();
            }
            else
            {
                clasificacion.modificar();
            }
            if (Connection.Objects.Error.isActivo())
            {
                MessageBox.Show(Connection.Objects.Error.nombreError, Connection.Objects.Error.descripcionError);
            }
            else
            {
                MessageBox.Show("Correcto");
            }*/
        }

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            borde.Child = anterior;
        }
	}
}