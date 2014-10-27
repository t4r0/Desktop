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
namespace MuseoCliente
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        Sala sala = new Sala();
        Estructuras.Observador observer;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded_1(object sender, RoutedEventArgs e)
        {
            
        }

        private void itemClasif_Click(object sender, RoutedEventArgs e)
        {
            //observer = new Estructuras.Observador(modClasificaciones);
            bdrContenedor.Child = observer.ventanaActual();
        }

        private void itemPiezas_Click(object sender, RoutedEventArgs e)
        {
            //bdrContenedor.Child = new modInventario();
        }
    }
}
