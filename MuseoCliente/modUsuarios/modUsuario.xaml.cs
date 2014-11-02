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
	/// Lógica de interacción para modUsuario.xaml
	/// </summary>
	public partial class modUsuario : UserControl
	{
        Connection.Objects.Usuario usuario = new Connection.Objects.Usuario();
        Connection.Objects.Pais paises = new Connection.Objects.Pais();
        public UserControl anterior;
        public Border borde;
        public bool modificar = false;
		public bool Modificar{
			get{ return modificar;}
			set{ modificar=value;}
		}
        public string userName;
        public modUsuario()
		{
			this.InitializeComponent();
		}

        private void LayoutRoot_Loaded(object sender, RoutedEventArgs e)
        {
            //cmbGrupo.DisplayMemberPath = "Nombre del grupo"; //Pendiente
            //cmbGrupo.SelectedValuePath = "id?"; //Pendiente
            cmbPais.SelectedValuePath = "iso";
            cmbPais.DisplayMemberPath = "printable_name";
            cmbPais.ItemsSource = paises.regresarTodos();
            //Falta clase para regresar todos los grupos de usuario. cmbPais.ItemsSource = paises.regresarTodos();
            //Cargar datos
            //Si es para modificar
            if (modificar == true)
            {
                lblOperacion.Content = "Modificar Usuario";
                usuario = (Usuario)usuario.consultaUserName(userName)[0];
                lblUserName.Text = usuario.username;
                txtNombres.Text = usuario.first_name;
                txtApellidos.Text = usuario.last_name;
                txtCorreo.Text = usuario.email;
                //txtContra.Text = usuario.password;
                cmbPais.SelectedValue = usuario.pais;
                rtxtBiografia.Text = usuario.biografia;
                if (usuario.is_staff == true)
                    chkStaff.IsChecked = true;
                else
                    chkStaff.IsChecked = false;
                if (usuario.voluntario == true)
                    chkVoluntario.IsChecked = true;
                else
                    chkVoluntario.IsChecked = false;
            }
            else
            {
                lblOperacion.Content = "Nuevo Usuario";
            }
        }

        private void btnGuardar_Click(object sender, RoutedEventArgs e)
        {
            usuario.first_name = txtNombres.Text;
            usuario.last_name = txtApellidos.Text;
            //usuario.password = txtContra.Text;
            usuario.email = txtCorreo.Text;
            usuario.pais = cmbPais.SelectedValue.ToString();
            usuario.biografia = rtxtBiografia.Text;
            // Pendiente: usuario.last_login
            if (chkStaff.IsChecked == true)
                usuario.is_staff = true;
            else
                usuario.is_staff = false;
            if (chkVoluntario.IsChecked == true)
                usuario.voluntario = true;
            else
                usuario.voluntario = false;
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

            /* Pendiente voluntario
            if (chkVoluntario.IsChecked == true)
            {
                //
            }*/
        }

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            borde.Child = anterior;
        }

        private void cmbPais_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void cmbPais_Loaded(object sender, RoutedEventArgs e)
        {
            /*ComboBox cmb = (ComboBox)sender;
            Pais paises = new Pais();
            cmb.ItemsSource = paises.fetchAll();
            cmb.SelectedValuePath = "iso";
            cmb.DisplayMemberPath = "printable_name";*/
        }

        private void cmbGrupo_Loaded(object sender, RoutedEventArgs e)
        {
            /*ComboBox cmb =(ComboBox) sender;
            Grupo grupos = new Grupo();
            cmb.ItemsSource = grupos.fetchAll();
            cmb.SelectedValuePath = "id";
            cmb.DisplayMemberPath = "name";*/
        }
	}
}