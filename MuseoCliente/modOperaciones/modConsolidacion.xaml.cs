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
        Mantenimiento mante1 = new Mantenimiento();
        Mantenimiento mante2 = new Mantenimiento();
        Mantenimiento mante3 = new Mantenimiento();
        Mantenimiento mante4 = new Mantenimiento();
        Mantenimiento mante5 = new Mantenimiento();
        Mantenimiento mante6 = new Mantenimiento();
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
            }
            if (rbLimpieza.IsChecked == true)
            {
                mante1.procedimiento = 1;
                mante1.metodoMaterial = txtLimpieza.Text;
                mante1.fecha = dpFechaLimpieza.SelectedDate.Value.Date;
                mante1.consolidacion = consolidacion.id;
                if (modificar == false)
                {
                    mante1.guardar();
                }
                else
                {
                    mante1.modificar();
                }
            }
            if (rbConsolidacion.IsChecked == true)
            {
                mante2.procedimiento = 2;
                mante2.metodoMaterial = txtConsolidacion.Text;
                mante2.fecha = dpFechaConsol.SelectedDate.Value.Date;
                mante2.consolidacion = consolidacion.id;
                if (modificar == false)
                {
                    mante2.guardar();
                }
                else
                {
                    mante2.modificar();
                }
            }
            if (rbEliminacion.IsChecked == true)
            {
                mante3.procedimiento = 3;
                mante3.metodoMaterial = txtEliminacion.Text;
                mante3.fecha = dpFechaEliminacion.SelectedDate.Value.Date;
                mante3.consolidacion = consolidacion.id;
                if (modificar == false)
                {
                    mante3.guardar();
                }
                else
                {
                    mante3.modificar();
                }
            }
            if (rbUnion.IsChecked == true)
            {
                mante4.procedimiento = 4;
                mante4.metodoMaterial = txtUnion.Text;
                mante4.fecha = dpFechaUnion.SelectedDate.Value.Date;
                mante4.consolidacion = consolidacion.id;
                if (modificar == false)
                {
                    mante4.guardar();
                }
                else
                {
                    mante4.modificar();
                }
            }
            if (rbOtro.IsChecked == true)
            {
                mante5.procedimiento = 5;
                mante5.metodoMaterial = txtOtro.Text;
                mante5.fecha = dpFechaOtro.SelectedDate.Value.Date;
                mante5.consolidacion = consolidacion.id;
                if (modificar == false)
                {
                    mante5.guardar();
                }
                else
                {
                    mante5.modificar();
                }
            }
            if (txtObservaciones.Text.Length > 10)
            {
                mante6.procedimiento = 6;
                mante6.metodoMaterial = txtObservaciones.Text;
                mante6.consolidacion = consolidacion.id;
                if (modificar == false)
                {
                    mante6.guardar();
                }
                else
                {
                    mante6.modificar();
                }
            }
            if (Connection.Objects.Error.isActivo())
            {
                MessageBox.Show(Connection.Objects.Error.descripcionError, Connection.Objects.Error.nombreError);
            }
            else
            {
                MessageBox.Show("Mantenimientos ingresados");
                borde.Child = anterior;
            }
        }
	}
}