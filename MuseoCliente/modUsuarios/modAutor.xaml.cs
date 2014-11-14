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
	/// Lógica de interacción para modAutor.xaml
	/// </summary>
	public partial class modAutor : UserControl
	{
        Connection.Objects.Autor autor = new Connection.Objects.Autor();
        Connection.Objects.Pais paises = new Connection.Objects.Pais();
        public UserControl anterior;
        public Border borde;
        public bool modificar = false;
        public int id;
        public modAutor()
		{
			this.InitializeComponent();
		}

        private void btnGuardar_Click(object sender, RoutedEventArgs e)
        {
            autor.nombre = txtNombre.Text;
            autor.apellido = txtApellido.Text;
            autor.pais = cmbPais.SelectedValue.ToString();
            if (modificar == false)
            {
                autor.guardar();
            }
            else
            {
                autor.modificar();
            }
            if (Connection.Objects.Error.isActivo())
            {
                MessageBox.Show(Connection.Objects.Error.descripcionError, Connection.Objects.Error.nombreError);
            }
            else
            {
                MessageBox.Show("Correcto");
            }
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            cargarPaises();
            //Cargar datos
            //Si es para modificar
            if (modificar == true)
            {
                lblOperacion.Content = "Modificar Autor";
                autor.regresarObjeto(id);
                txtNombre.Text = autor.nombre;
                txtApellido.Text = autor.apellido;
                cmbPais.SelectedValue = autor.pais;
            }
            else
            {
                lblOperacion.Content = "Nuevo Autor";
            }
        }
        private async void cargarPaises()
        {
            Task<ArrayList> task = Task<ArrayList>.Factory.StartNew(() => paises.regresarTodos());
            await task;
            cmbPais.DisplayMemberPath = "printable_name";
            cmbPais.SelectedValuePath = "iso";
            cmbPais.ItemsSource = task.Result;
        }
        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            borde.Child = anterior;
        }
	}
}