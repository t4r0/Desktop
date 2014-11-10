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
	/// Lógica de interacción para modInvestigaciones.xaml
	/// </summary>
	public partial class modInvestigaciones : UserControl
	{
        Connection.Objects.Investigacion investigaciones = new Connection.Objects.Investigacion();
        public Border borde;
        public modInvestigaciones()
		{
			this.InitializeComponent();
		}

        private void btnBuscar_Click(object sender, RoutedEventArgs e)
        {
            modResultadosInv frm = new modResultadosInv();
            frm.busqueda = "";
            frm.borde = borde;
            frm.anterior = this;
            borde.Child = frm;
        }

        private void btnNueva_Click(object sender, RoutedEventArgs e)
        {
            modInvestigacion frm = new modInvestigacion();
            frm.borde = borde;
            frm.anterior = this;
            borde.Child = frm;
        }

        private void LayoutRoot_Loaded(object sender, RoutedEventArgs e)
        {
            cargarInvestigaciones();
        }
        private async void cargarInvestigaciones()
        {
            Task<ArrayList> task = Task<ArrayList>.Factory.StartNew(() => investigaciones.regresarTodo());
            await task;
            gvResultados.ItemsSource = task.Result;
        }
        private void btnEditarInvestigacion_Click(object sender, RoutedEventArgs e)
        {
            if (gvResultados.SelectedItem != null)
            {
                modInvestigacion frm = new modInvestigacion();
                frm.borde = borde;
                frm.anterior = this;
                frm.DataContext = gvResultados.SelectedItem;
                frm.modificar = true;
                borde.Child = frm;
            }
        }

        private void btnBuscarInvestigacion_Click(object sender, RoutedEventArgs e)
        {
            buscarInvestigaciones(txtBuscar.Text);
        }
        private async void buscarInvestigaciones(string titulo)
        {
            Task<ArrayList> task = Task<ArrayList>.Factory.StartNew(() => investigaciones.buscarTitulo(titulo));
            await task;
            gvResultados.ItemsSource = task.Result;
        }
        private void btnNuevaInvestigacion_Click(object sender, RoutedEventArgs e)
        {
            modInvestigacion frm = new modInvestigacion();
            frm.borde = borde;
            frm.anterior = this;
            borde.Child = frm;
        }

        private void txtBuscar_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txtBuscar.Text.Length > 3)
            {
                buscarInvestigaciones(txtBuscar.Text);
            }
            else
            {
                cargarInvestigaciones();
            }
        }
	}
}