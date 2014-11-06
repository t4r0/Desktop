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
using System.Threading;
using MuseoCliente.Connection.Objects;
using System.Collections;
using System.ComponentModel;
namespace MuseoCliente
{
	/// <summary>
	/// Lógica de interacción para modTraslado.xaml
	/// </summary>
	public partial class modTraslado : UserControl
	{
        Pieza piezas = new Pieza();
        Caja cajas = new Caja();
        Sala salas = new Sala();
        Vitrina vitrinas = new Vitrina();
        public UserControl anterior;
        public Border borde;
        string nombreP = "";
        private BackgroundWorker CargarPiezas = new BackgroundWorker();
        public modTraslado()
		{
			this.InitializeComponent();
		}

        private void btnGuardar_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            borde.Child = anterior;
        }

        private void LayoutRoot_Loaded(object sender, RoutedEventArgs e)
        {
            //Cajas
            cmbCaja.ItemsSource = cajas.regresarTodo();
            cmbCaja.DisplayMemberPath = "codigo";
            cmbCaja.SelectedValuePath = "id";
            //Salas
            cmbSala.ItemsSource = salas.regresarTodos();
            cmbSala.DisplayMemberPath = "nombre";
            cmbSala.SelectedValuePath = "id";
        }

        private void rbBodega_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void cmbSala_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int idS = (int)cmbSala.SelectedValue;
            //Vitrinas
            cmbVitrina.ItemsSource = vitrinas.regresarPorSala(idS);
            cmbVitrina.DisplayMemberPath = "numero";
            cmbVitrina.SelectedValuePath = "id";
        }

        private void txtCodigoPieza_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txtCodigoPieza.Text.Length > 3 && !CargarPiezas.IsBusy)
            {
                nombreP = txtCodigoPieza.Text;
                InitializePiezasLoader();
                CargarPiezas.RunWorkerAsync(piezas);
            }
            else
            {
                gvPiezas.ItemsSource = null;
            }
        }

        private void InitializePiezasLoader()
        {
            CargarPiezas.DoWork += CargarPiezas_DoWork;
            CargarPiezas.RunWorkerCompleted += CargarPiezas_RunWorkerCompleted;
        }

        void CargarPiezas_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            ArrayList lista = (ArrayList)e.Result;
            gvPiezas.ItemsSource = lista;
            gvPiezas.SelectedValuePath = "codigo";
        }

        void CargarPiezas_DoWork(object sender, DoWorkEventArgs e)
        {
            Pieza pieza = (Pieza)e.Argument;
            e.Result = pieza.buscarNombre(nombreP);
        }
	}
}