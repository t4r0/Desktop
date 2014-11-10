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
using MuseoCliente.Connection.Objects;
using System.Collections;
using System.Threading.Tasks;
using MuseoCliente.Properties;

namespace MuseoCliente
{
	/// <summary>
	/// Lógica de interacción para modConsolidacion.xaml
	/// </summary>
	public partial class modConsolidacion : UserControl
	{
        //Consolidacion
        Consolidacion consolidacion = new Consolidacion();
        Pieza piezas = new Pieza();
        Pieza pieza = new Pieza(); //Pieza para consolidacion
        //Mantenimientos

        //
        public UserControl anterior;
        public Border borde;
        public bool modificar = false;
        public modConsolidacion()
		{
			this.InitializeComponent();
		}

        private void btnTratamientos_Click(object sender, RoutedEventArgs e)
        {
            //
        }

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            borde.Child = anterior;
        }

        private void txtCodigo_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txtCodigo.Text.Length > 3)
            {
                buscarPiezas(txtCodigo.Text);
            }
            else
            {
                gvPiezas.ItemsSource = null;
                rbLimpieza.IsChecked = false;
                rbRestaurar.IsChecked = false;
                dpInicio.SelectedDate = null;
                dpFin.SelectedDate = null;
            }
        }

        private async void buscarPiezas(string codigo)
        {
            Task<ArrayList> task = Task<ArrayList>.Factory.StartNew(() => piezas.buscarNombre(codigo));
            await task;
            gvPiezas.ItemsSource = task.Result;
        }

        private void btnSeleccionar_Click(object sender, RoutedEventArgs e)
        {
            if (gvPiezas.SelectedItem != null)
            {
                pieza = (Pieza)gvPiezas.SelectedItem;
                txtCodigoPieza.Text = pieza.codigo;
                txtNombrePieza.Text = pieza.nombre;
            }
            else
            {
                txtCodigo.Text = "";
                txtNombrePieza.Text = "";
            }
        }

        private void Expander_Expanded(object sender, RoutedEventArgs e)
        {
            //bdrContent.Child = new modTratamientos();
        }

        private void btnGuardar_Click(object sender, RoutedEventArgs e)
        {
            consolidacion = (Consolidacion)this.DataContext;
            consolidacion.responsable = "Migue4";
            if (modificar == false)
            {
                consolidacion.guardar();
            }
            else
            {
                consolidacion.modificar();
            }
            if (Connection.Objects.Error.isActivo())
            {
                MessageBox.Show(Connection.Objects.Error.descripcionError, Connection.Objects.Error.nombreError);
            }
            else
            {
                MessageBox.Show("Consolidación correcta");
                borde.Child = anterior;
            }
            if (rbLimpieza.IsChecked == true)
            {
                Mantenimiento mante1 = new Mantenimiento();
                mante1.procedimiento = 1;
            }
        }
	}
}