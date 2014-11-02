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
	/// Lógica de interacción para modUsuarios.xaml
	/// </summary>
	public partial class modUsuarios : UserControl
	{
        Connection.Objects.Usuario usuarios = new Connection.Objects.Usuario();
        public Border borde;
        public modUsuarios()
		{
			this.InitializeComponent();
		}

        private void LayoutRoot_Loaded(object sender, RoutedEventArgs e)
        {
            gvActivos.ItemsSource = usuarios.regresarTodos(); //Pendiente filtrado
            gvVoluntarios.ItemsSource = usuarios.regresarTodos(); //Pendiente voluntarios
        }

        private void btnNuevo_Click(object sender, RoutedEventArgs e)
        {
            modUsuario frm = new modUsuario();
            frm.borde = borde;
            frm.anterior = this;
            borde.Child = frm;
        }

        private void btnBuscar_Click(object sender, RoutedEventArgs e)
        {
            modResultadosUsers frm = new modResultadosUsers();
            frm.busqueda = txtBuscar.Text;
            frm.borde = borde;
            frm.anterior = this;
            borde.Child = frm;
        }

        private void btnNuevoAu_Click(object sender, RoutedEventArgs e)
        {
            modAutor frm = new modAutor();
            frm.borde = borde;
            frm.anterior = this;
            borde.Child = frm;
        }

        private void gvActivos_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
	}
}