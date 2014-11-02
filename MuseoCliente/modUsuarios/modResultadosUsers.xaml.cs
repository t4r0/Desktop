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
	/// Lógica de interacción para modResultadosUsers.xaml
	/// </summary>
	public partial class modResultadosUsers : UserControl
	{
        public string busqueda = "";
        private Connection.Objects.Usuario usuarios = new Connection.Objects.Usuario();
        public UserControl anterior;
        public Border borde;
        public modResultadosUsers()
		{
			this.InitializeComponent();
		}

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            borde.Child = anterior;
        }

        private void LayoutRoot_Loaded(object sender, RoutedEventArgs e)
        {
            gvResultados.SelectedValuePath = "username";
            gvResultados.ItemsSource = usuarios.regresarTodos();
        }

        private void rbUsuarios_Click(object sender, RoutedEventArgs e)
        {
            if (usuarios.consultaUserName(busqueda) != null)
            {
                gvResultados.ItemsSource = usuarios.consultaUserName(busqueda);
            }
            else
            {
                MessageBox.Show("No hay usuarios con el nombre");
            }
        }

        private void rbVoluntarios_Click(object sender, RoutedEventArgs e)
        {
            /*Falta consultar voluntarios por nombre
            if (usuarios.consultarNombre(busqueda) != null)
            {
                gvResultados.SelectedValue = "id";
                gvResultados.ItemsSource = usuarios.consultarNombre(busqueda);
            }
            else
            {
                MessageBox.Show("No hay usuarios con el nombre");
            }*/
        }

        private void btnEditar_Click(object sender, RoutedEventArgs e)
        {
            modUsuario frm = new modUsuario();
            frm.borde = borde;
            frm.anterior = this;
            frm.modificar = true;
            frm.userName = gvResultados.SelectedValue.ToString();
            borde.Child = frm;
        }
	}
}