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
	/// Lógica de interacción para modEventos.xaml
	/// </summary>
	public partial class modEventos : UserControl
	{
        Connection.Objects.Eventos eventos = new Connection.Objects.Eventos();
        public modEventos()
		{
			this.InitializeComponent();
		}

        private void LayoutRoot_Loaded(object sender, RoutedEventArgs e)
        {
            gvProximos.ItemsSource = eventos.regresarTodos(); //regresarProximos
            gvConcluidos.ItemsSource = eventos.regresarTodos(); //regresarConcluidos
        }
	}
}