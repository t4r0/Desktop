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
	/// Lógica de interacción para modUsuario.xaml
	/// </summary>
	public partial class modUsuario : UserControl
	{
        Connection.Objects.Usuario usuario = new Connection.Objects.Usuario();
        public UserControl anterior;
        public Border borde;
        public bool modificar = false;
		public bool Modificar{
			get{ return modificar;}
			set{ modificar=value;}
		}
        public int id;
        public modUsuario()
		{
			this.InitializeComponent();
		}

        private void LayoutRoot_Loaded(object sender, RoutedEventArgs e)
        {
            //cmbGrupo.DisplayMemberPath = "Nombre del grupo"; //Pendiente
            //cmbGrupo.SelectedValuePath = "id?"; //Pendiente
            //Falta clase para regresar todos los grupos de usuario. cmbPais.ItemsSource = paises.regresarTodos();
            //Cargar datos
            //Si es para modificar
            if (modificar == true)
            {
                lblOperacion.Content = "Modificar Usuario";
                //
            }
            else
            {
                lblOperacion.Content = "Nuevo Usuario";
            }
        }

        private void btnGuardar_Click(object sender, RoutedEventArgs e)
        {
            /*usuario.first_name = txtNombres.Text;
            //usuario.last_name = txtApellidos.Text; El apellido no puede ser int!
            usuario.username = txtUserName.Text;
            usuario.password = txtContra.Text;
            usuario.email = txtContra.Text;
            // Pendiente: usuario.last_login
            if (chkSuperUsuario.IsChecked == true)
                usuario.is_superuser = 1;
            else
                usuario.is_superuser = 0;
            if (chkActivo.IsChecked == true)
                usuario.is_active = 1;
            else
                usuario.is_active = 0;
            if (chkStaff.IsChecked == true)
                usuario.is_staff = 1;
            else
                usuario.is_staff = 0;
            if (modificar == false)
            {
                usuario.guardar();
            }
            else
            {
                usuario.modificar();
            }
            if (Connection.Objects.Error.isActivo())
            {
                MessageBox.Show(Connection.Objects.Error.nombreError, Connection.Objects.Error.descripcionError);
            }
            else
            {
                MessageBox.Show("Correcto");
            }
            // Pendiente grupo usuario

            // Pendiente voluntario
            if (chkVoluntario.IsChecked == true)
            {
                //
            }*/
        }

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            borde.Child = anterior;
        }
	}
}