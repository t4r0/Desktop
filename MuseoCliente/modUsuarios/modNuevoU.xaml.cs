using Newtonsoft.Json;
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
using System.Windows.Shapes;
using MuseoCliente.Connection;

namespace MuseoCliente
{
	/// <summary>
	/// Lógica de interacción para modNuevoU.xaml
	/// </summary>
	public partial class modNuevoU : Window
	{
        Dictionary<string, string> dict = new Dictionary<string, string>();
        Connection.Objects.Usuario usuario = new Connection.Objects.Usuario();
        public UserControl anterior;
        public Border borde;
        public modNuevoU()
		{
			this.InitializeComponent();
			
			// A partir de este punto se requiere la inserción de código para la creación del objeto.
		}

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Connection.Connector conector = new Connection.Connector("/api/v1/registrar/");
            dict["username"] = txtUserName.Text;
            dict["password"] = txtContra.Text;
            dict["email"] = txtCorreo.Text;
            string content = JsonConvert.SerializeObject(dict, Formatting.Indented);
            conector.create(content);
            if (Connection.Objects.Error.isActivo())
            {
                MessageBox.Show(Connection.Objects.Error.descripcionError, Connection.Objects.Error.nombreError);

            }
            else
            {
                MessageBox.Show("Usuario Ingresado Correctamente","Registro");
            }
        }
	}
}