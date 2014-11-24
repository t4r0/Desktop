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
            cargarEventosProximos();
            cargarEventosConcluidos();
        }

        private async void cargarEventosProximos()
        {
            Task<ArrayList> task = Task<ArrayList>.Factory.StartNew(() => eventos.regresarEventosProximos());
            await task;
            gvProximos.ItemsSource = task.Result;
        }
        private async void cargarEventosConcluidos()
        {
            Task<ArrayList> task = Task<ArrayList>.Factory.StartNew(() => eventos.regresarEventosFinalizados());
            await task;
            gvConcluidos.ItemsSource = task.Result;
        }
        private async void buscarEventos(string nombre)
        {
            Task<ArrayList> task = Task<ArrayList>.Factory.StartNew(() => eventos.consultarNombre(nombre));
            await task;
            gvProximos.ItemsSource = task.Result;
        }

        private void btnNuevoEvento_Click(object sender, RoutedEventArgs e)
        {
            modEvento frm = new modEvento();
            frm.borde = borde;
            frm.anterior = this;
            borde.Child = frm;
        }

        private void btnEditarEvento_Click(object sender, RoutedEventArgs e)
        {
            modEvento frm = new modEvento();
            frm.borde = borde;
            frm.anterior = this;
            if (gvProximos.SelectedItem != null)
            {
                frm.modificar = true;
                frm.DataContext = gvProximos.SelectedItem;
            }
            borde.Child = frm;
            
        }

        private void txtBuscarEventos_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txtBuscarEventos.Text.Length > 3)
                buscarEventos(txtBuscarEventos.Text);
            else
                cargarEventosProximos();
        }

        private void btnBuscarEventos_Click(object sender, RoutedEventArgs e)
        {
            buscarEventos(txtBuscarEventos.Text);
        }
	}
}