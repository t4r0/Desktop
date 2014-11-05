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
using Newtonsoft.Json;
using MuseoCliente.Connection;
using MuseoCliente.Connection.Objects;
using MuseoCliente.Properties;
using MuseoCliente.Designer;
using System.Threading.Tasks;
namespace MuseoCliente
{
	/// <summary>
	/// Lógica de interacción para Login.xaml
	/// </summary>
	public partial class Login : Window
	{
        Dictionary<string, string> dict = new Dictionary<string, string>();
		public Login()
		{
			this.InitializeComponent();
			
			// A partir de este punto se requiere la inserción de código para la creación del objeto.
		}

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            addAnimation();
            Task<Usuario> t = new Task<Usuario>(() => login());
            t.RunSynchronously();
            ShowWindow(t.Result);
        }

        private void addAnimation()
        {
            LoadingAnimation animation = new LoadingAnimation
            {
                HorizontalAlignment = System.Windows.HorizontalAlignment.Stretch,
                VerticalAlignment = System.Windows.VerticalAlignment.Stretch,
                Width = contentGrid.ActualWidth,
                Height = contentGrid.ActualHeight,
                Margin = new Thickness(0,0,0,0)
            };
            animation.message.Text = "Iniciando sesión";            
            Grid.SetZIndex(animation, 999);
            LayoutRoot.Children.Add(animation);
            dict["username"] = txtUsuario.Text;
            dict["password"] = txtPassword.Password;
        }

        private Usuario login()
        {
            Usuario user = new Usuario();
            try
            {
                string content = JsonConvert.SerializeObject(dict, Formatting.Indented);
                Connector conector = new Connector("/api/v1/login/");
                user = user.Deserialize(conector.create(content));
                return user;
               
            }
            catch (Exception ex)
            {
                throw ex;
            }
          
        }

        private void ShowWindow(Usuario user)
        {
            MainWindow main = new MainWindow() { DataContext = user };
            Settings.user = user;
            this.Hide();
            main.ShowDialog();
            this.Close();
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            txtUsuario.Focus();
            txtUsuario.SelectAll();
        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.Enter)
                login();
        }
	}
}