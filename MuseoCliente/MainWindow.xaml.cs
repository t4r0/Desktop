using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using MuseoCliente.Connection;
using MuseoCliente.Connection.Objects;
using MuseoCliente.Designer;
using MuseoCliente.Properties;

namespace MuseoCliente
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        MenuItem selected = new MenuItem();

        Sala sala = new Sala();
        public MainWindow()
        {
            InitializeComponent();
            LoadPermissions();
        }

        private void LoadPermissions()
        {
            itemOperaciones.Visibility = Settings.permisos.Contains("operaciones.add_consolidacion") ?
                Visibility.Visible : Visibility.Collapsed;
            itemFichas.Visibility = Settings.permisos.Contains("registro.add_ficha") ?
                Visibility.Visible : Visibility.Collapsed;
            itemClasif.Visibility = Settings.permisos.Contains("piezas.add_clasificacion") ?
                Visibility.Visible : Visibility.Collapsed;
            itemInsta.Visibility = Settings.permisos.Contains("traslados.add_traslado") ?
                Visibility.Visible : Visibility.Collapsed;
            itemEventos.Visibility = Settings.permisos.Contains("eventos.add_eventos") ?
                Visibility.Visible : Visibility.Collapsed;
            itemUsuarios.Visibility = Settings.permisos.Contains("auth.add_user") ?
                Visibility.Visible : Visibility.Collapsed;

        }

        private void Window_Loaded_1(object sender, RoutedEventArgs e)
        {
            
        }
        private void Select(MenuItem item)
        {
            item.IsChecked  = true;
            selected.IsChecked = false;
            selected = item;
        }
        private void itemClasif_Click(object sender, RoutedEventArgs e)
        {
            Select((MenuItem)sender);
            modClasificaciones frm = new modClasificaciones();
            frm.borde = bdrContenedor;
            bdrContenedor.Child = frm;
        }

        private void itemPiezas_Click(object sender, RoutedEventArgs e)
        {
            Select((MenuItem)sender);
            modInventario frm = new modInventario();
            bdrContenedor.Child = frm;
        }

        private void itemEventos_Click(object sender, RoutedEventArgs e)
        {
            Select((MenuItem)sender);
            modEventos frm = new modEventos();
            frm.borde = bdrContenedor;
            bdrContenedor.Child = frm;
        }

        private void itemInsta_Click(object sender, RoutedEventArgs e)
        {
            Select((MenuItem)sender);
            modInstalaciones frm = new modInstalaciones();
            frm.borde = bdrContenedor;
            bdrContenedor.Child = frm;
        }

        private void itemInves_Click(object sender, RoutedEventArgs e)
        {
            Select((MenuItem)sender);
            modInvestigaciones frm = new modInvestigaciones();
            frm.borde = bdrContenedor;
            bdrContenedor.Child = frm;
        }

        private void itemUsuarios_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void itemFotos_Click(object sender, RoutedEventArgs e)
        {
            Select((MenuItem)sender);
            modGaleria frm = new modGaleria();
            bdrContenedor.Child = frm;
        }

        private void itemUsuarios_Click_1(object sender, RoutedEventArgs e)
        {
            Select((MenuItem)sender);
            modUsuarios frm = new modUsuarios();
            frm.borde = bdrContenedor;
            bdrContenedor.Child = frm;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            bdrContenedor.Child = new WelcomePage();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            WelcomePage frm = new WelcomePage();
            modUsuario usr = new modUsuario() { anterior = frm, borde = bdrContenedor, modificar = true, userName=Settings.user.username };
            usr.DataContext = DataContext;            
            bdrContenedor.Child = usr;
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            Select((MenuItem)sender);
            bdrContenedor.Child = new FormDesigner();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            Connector con = new Connector("/api/v1/logout/");
            con.create("");
            this.DialogResult = true;
            this.Close();
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            if (this.WindowState == WindowState.Maximized)
                this.WindowState = WindowState.Normal;
            else
                this.WindowState = WindowState.Maximized;
        }

        private void Button_Close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Rectangle_PreviewMouseDown_1(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void itemOperaciones_Click(object sender, RoutedEventArgs e)
        {
            Select((MenuItem)sender);
            modOperaciones frm = new modOperaciones();
            frm.borde = bdrContenedor;
            bdrContenedor.Child = frm;
        }

        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.github.com/museoXela/");
        }
    }
}
