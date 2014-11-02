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
	/// Lógica de interacción para modCategoria.xaml
	/// </summary>
	public partial class modCategoria : UserControl
	{
        Connection.Objects.Categoria categ = new Connection.Objects.Categoria();
        public UserControl anterior;
        public Border borde;
        public bool modificar = false;
        public int id;
        public modCategoria()
		{
			this.InitializeComponent();
		}

        private void btnGuardar_Click(object sender, RoutedEventArgs e)
        {
            categ.nombre = txtNombre.Text;
            if (modificar == false)
            {
                categ.guardar();
            }
            else
            {
                categ.modificar();
            }
            if (Connection.Objects.Error.isActivo())
            {
                MessageBox.Show(Connection.Objects.Error.nombreError, Connection.Objects.Error.descripcionError);
            }
            else
            {
                MessageBox.Show("Correcto");
            }
        }

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            borde.Child = anterior;
        }

        private void LayoutRoot_Loaded(object sender, RoutedEventArgs e)
        {
            //Cargar datos
            //Si es para modificar
            if (modificar == true)
            {
                lblOperacion.Content = "Modificar Categoría";
                //categ = categ.buscarPorID(id);
                txtNombre.Text = "Pendiente";
            }
            else
            {
                lblOperacion.Content = "Nueva Categoría";
            }
        }
	}
}