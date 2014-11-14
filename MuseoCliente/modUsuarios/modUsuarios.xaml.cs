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
using System.Threading.Tasks;
using System.Collections;

namespace MuseoCliente
{
	/// <summary>
	/// Lógica de interacción para modUsuarios.xaml
	/// </summary>
	public partial class modUsuarios : UserControl
	{
        Connection.Objects.Usuario usuarios = new Connection.Objects.Usuario();
        Connection.Objects.Autor autores = new Connection.Objects.Autor();
        public Border borde;
        public modUsuarios()
		{
			this.InitializeComponent();
		}

        private void LayoutRoot_Loaded(object sender, RoutedEventArgs e)
        {
            cargarUsuarios();
            cargarAutores();
        }


        private void btnNuevoUsuario_Click(object sender, RoutedEventArgs e)
        {
            modNuevoU frm = new modNuevoU();
            frm.ShowDialog();
        }

        private async void cargarUsuarios()
        {
            Task<ArrayList> task = Task<ArrayList>.Factory.StartNew(() => usuarios.regresarTodos());
            await task;
            gvActivos.ItemsSource = task.Result;
        }
        private async void cargarAutores()
        {
            Task<ArrayList> task = Task<ArrayList>.Factory.StartNew(() => autores.regresarTodos());
            await task;
            gvVoluntarios.ItemsSource = task.Result;
            gvVoluntarios.SelectedValuePath = "id";
        }
        private async void buscarUsuarios(string username)
        {
            Task<ArrayList> task = Task<ArrayList>.Factory.StartNew(() => usuarios.consultaUserName(username));
            await task;
            gvActivos.ItemsSource = task.Result;
        }
        private async void buscarAutores(string nombre)
        {
            Task<ArrayList> task = Task<ArrayList>.Factory.StartNew(() => autores.consultarApellido(nombre));
            await task;
            gvVoluntarios.ItemsSource = task.Result;
        }
        private void btnNuevoAutor_Click(object sender, RoutedEventArgs e)
        {
            modAutor frm = new modAutor();
            frm.borde = borde;
            frm.anterior = this;
            borde.Child = frm;
        }

        private void txtBuscarUsuarios_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txtBuscarUsuarios.Text.Length > 3)
                buscarUsuarios(txtBuscarUsuarios.Text);
            else
                cargarUsuarios();
        }

        private void txtBuscarAutores_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txtBuscarAutores.Text.Length > 3)
                buscarAutores(txtBuscarAutores.Text);
            else
                cargarAutores();
            
        }

        private void btnBuscarUsuarios_Click(object sender, RoutedEventArgs e)
        {
            buscarUsuarios(txtBuscarUsuarios.Text);
        }

        private void btnBuscarAutores_Click(object sender, RoutedEventArgs e)
        {
            buscarAutores(txtBuscarAutores.Text);
        }

        private void btnEditarUsuario_Click(object sender, RoutedEventArgs e)
        {
            modUsuario frm = new modUsuario();
            frm.borde = borde;
            frm.anterior = this;
            frm.modificar = true;
            borde.Child = frm;
            frm.DataContext = gvActivos.SelectedItem;
        }

        private void btnEditarAutor_Click(object sender, RoutedEventArgs e)
        {
            modAutor frm = new modAutor();
            frm.borde = borde;
            frm.anterior = this;
            if (gvVoluntarios.SelectedValue != null)
            {
                frm.modificar = true;
                frm.id = Convert.ToInt16(gvVoluntarios.SelectedValue.ToString());
            }
            borde.Child = frm;
        }
	}
}