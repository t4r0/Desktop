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
	/// Lógica de interacción para modClasificacion.xaml
	/// </summary>
	public partial class modClasificacion : UserControl
	{
        Clasificacion clasificacion = new Clasificacion();
        Ficha fichas = new Ficha();
        Categoria categ = new Categoria();
        Coleccion colec = new Coleccion();
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
            cmbFicha.ItemsSource = fichas.regresarTodos();
            cmbFicha.DisplayMemberPath = "nombre";
            cmbFicha.SelectedValuePath = "id";
            //Categorias
            cmbCategoria.ItemsSource = categ.regresarTodo();
            cmbCategoria.DisplayMemberPath = "nombre";
            cmbCategoria.SelectedValuePath = "id";
            //Coleccion
            cmbColeccion.ItemsSource = colec.regresarTodo();
            cmbColeccion.DisplayMemberPath = "nombre";
            cmbColeccion.SelectedValuePath = "id";
            //Si es para modificar
            if (modificar == true)
            {
                lblOperacion.Content = "Modificar Clasificación";
            }
            else
            {
                lblOperacion.Content = "Nueva Clasificación";
            }
        }

        private void btnGuardar_Click(object sender, RoutedEventArgs e)
        {
            clasificacion = (Clasificacion)this.DataContext;
            if (!txtCodigo.Text.Equals("") && (!txtNombre.Text.Equals("")) && (cmbFicha.SelectedValue != null) && (cmbCategoria.SelectedValue != null) && (cmbColeccion.SelectedValue != null))
            {
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
                    MessageBox.Show(Connection.Objects.Error.descripcionError, Connection.Objects.Error.nombreError);
                }
                else
                {
                    MessageBox.Show("Correcto");
                    borde.Child = anterior;
                }
            }
            else
            {
                MessageBox.Show("No se ha rellenado los campos necesarios para guardar el registro");
            }
            
        }

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            borde.Child = anterior;
        }
	}
}