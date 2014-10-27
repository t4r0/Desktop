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
        public Border borde;
        public modEventos()
		{
			this.InitializeComponent();
		}

        private void LayoutRoot_Loaded(object sender, RoutedEventArgs e)
        {
            gvProximos.ItemsSource = eventos.regresarTodos(); //regresarProximos
            gvConcluidos.ItemsSource = eventos.regresarTodos(); //regresarConcluidos
        }

        private void btnNuevo_Click(object sender, RoutedEventArgs e)
        {
            modEvento frm = new modEvento();
            frm.borde = borde;
            frm.anterior = this;
            borde.Child = frm;
        }

        private void btnBuscar_Click(object sender, RoutedEventArgs e)
        {
            modResultadosEvs frm = new modResultadosEvs();
            frm.busqueda = txtBuscar.Text;
            frm.borde = borde;
            frm.anterior = this;
            borde.Child = frm;
        }
	}
}