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
	/// Lógica de interacción para modResultadosInv.xaml
	/// </summary>
	public partial class modResultadosInv : UserControl
	{
        public string busqueda = "";
        private Connection.Objects.Investigacion investigaciones = new Connection.Objects.Investigacion();
        public UserControl anterior;
        public Border borde;
        public modResultadosInv()
		{
			this.InitializeComponent();
		}

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            borde.Child = anterior;
        }

        private void rbTodas_Click(object sender, RoutedEventArgs e)
        {
            gvResultados.ItemsSource = investigaciones.regresarTodo();
        }

        private void rbAutor_Click(object sender, RoutedEventArgs e)
        {
            //Pendiente
        }

        private void rbEditor_Checked(object sender, RoutedEventArgs e)
        {
            //Pendiente
        }

        private void rbUltimas_Checked(object sender, RoutedEventArgs e)
        {
            //Pendiente
        }

        private void btnEditar_Click(object sender, RoutedEventArgs e)
        {
            if (gvResultados.SelectedItem != null)
            {
                modInvestigacion frm = new modInvestigacion();
                frm.borde = borde;
                frm.anterior = this;
                frm.DataContext = gvResultados.SelectedItem;
                borde.Child = frm;
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            buscarInvestigaciones(txtBuscar.Text);
        }
        private async void buscarInvestigaciones(string titulo)
        {
            Task<ArrayList> task = Task<ArrayList>.Factory.StartNew(() => investigaciones.buscarTitulo(titulo));
            await task;
            gvResultados.ItemsSource = task.Result;
        }

        private void txtBuscar_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txtBuscar.Text.Length > 3)
            {
                buscarInvestigaciones(txtBuscar.Text);
            }
            else
            {
                gvResultados.ItemsSource = null;
            }
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
	}
}