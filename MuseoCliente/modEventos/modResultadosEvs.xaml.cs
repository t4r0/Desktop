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
	/// Lógica de interacción para modResultadosEvs.xaml
	/// </summary>
	public partial class modResultadosEvs : UserControl
	{
        private string busqueda = "Eventos ursaring";
        private Connection.Objects.Eventos eventos = new Connection.Objects.Eventos();
        public modResultadosEvs()
		{
			this.InitializeComponent();
		}

        private void rbTodos_Checked(object sender, RoutedEventArgs e)
        {
            if (eventos.consultarNombre(busqueda) != null)
            {
                gvResultados.ItemsSource = eventos.consultarNombre(busqueda);
            }
            else
            {
                MessageBox.Show("No hay eventos con el nombre");
            }
        }

        private void rbFinalizados_Checked(object sender, RoutedEventArgs e)
        {
            //Pendiente por las nuevas consultas
        }

        private void rbProximos_Checked(object sender, RoutedEventArgs e)
        {
            //Pendiente por las nuevas consultas
        }
	}
}