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
using System.Threading;
namespace MuseoCliente
{
	/// <summary>
	/// Lógica de interacción para Login.xaml
	/// </summary>
    /// 

	public partial class Login : Window
	{
        CancellationTokenSource cToken = new CancellationTokenSource();
        CancellationToken token;
        string s;
        LoadingAnimation animation;

        Dictionary<string, string> dict = new Dictionary<string, string>();
		public Login()
		{
			this.InitializeComponent();
            animation = new LoadingAnimation{
            HorizontalAlignment = System.Windows.HorizontalAlignment.Stretch,
            VerticalAlignment = System.Windows.VerticalAlignment.Stretch
        };
			
			// A partir de este punto se requiere la inserción de código para la creación del objeto.
		}

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            StartApp();
        }

        private async void StartApp()
        {
            addAnimation();
            cToken = new CancellationTokenSource();
            token = cToken.Token;
            Task<Usuario> t = Task<Usuario>.Factory.StartNew(() => login(token));
            await t;
            removeAnimation();
            if (!token.IsCancellationRequested)
            {
                Settings.user = t.Result;
                ShowWindow(Settings.user);
            }
        }

        private void removeAnimation()
        {
            contentGrid.Children.Remove(animation);
            message.Text = s;
        }

        private void addAnimation()
        {           
            animation.message.Text = "Cargando";    
            animation.Width = contentGrid.ActualWidth;
            animation.Height = contentGrid.ActualHeight;
            Grid.SetZIndex(animation, 999);
            contentGrid.Children.Add(animation);
            dict["username"] = txtUsuario.Text;
            dict["password"] = txtPassword.Password;
        }

        private Usuario login(CancellationToken token)
        {
            Usuario user = new Usuario();
            try
            {
                string content = JsonConvert.SerializeObject(dict, Formatting.Indented);
                Connector conector = new Connector("/api/v1/login/");
                user = user.Deserialize(conector.create(content));
                conector = new Connector("/api/v1/usuarios/" + user.username + "/permisos/");
                content = conector.fetch();
                Settings.permisos = ((Dictionary<string, List<string>>)JsonConvert.DeserializeObject<Dictionary<string, List<string>>>(content))["permisos"];
                return user;
               
            }
            catch (Exception ex)
            {
                cToken.Cancel();
                s = ex.Message;
            }
            return null;
        }

        private void ShowWindow(Usuario user)
        {
            MainWindow main = new MainWindow() { DataContext = user };
            Settings.user = user;
            this.Hide();
            if (main.ShowDialog() == true)
            {
                this.Show();
                clean();
            }
            else
                this.Close();
        }

        private void clean()
        {
            txtUsuario.Focus();
            txtUsuario.SelectAll();
            txtPassword.Password = "";
            s = "";
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            clean();
        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
                StartApp();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
             if (this.WindowState == WindowState.Normal) this.WindowState = WindowState.Maximized;
            else this.WindowState = WindowState.Normal;

        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void DockPanel_PreviewMouseDown_1(object sender, MouseButtonEventArgs e)
        {

            this.DragMove();
        }
	}
}