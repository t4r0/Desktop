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
        Traslado traslado = new Traslado();
        Pieza piezas = new Pieza(); //Para buscar una pieza
        Caja cajas = new Caja();
        Sala salas = new Sala();
        Vitrina vitrinas = new Vitrina();
        Pieza pieza = new Pieza(); //Pieza que se va a trasladar
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
            //Modificar
            if (traslado.regresarPiezas(pieza.codigo).Count > 0)
            {
                MessageBox.Show("Modificar");
            }
            else //Nuevo
            {
                traslado.pieza = pieza.codigo;
                traslado.responsable = "Migue4";
                traslado.fecha = System.DateTime.Today;
                if (rbBodega.IsChecked == true)
                {
                    traslado.bodega = true;
                    traslado.caja = (int)cmbCaja.SelectedValue;
                    traslado.vitrina = null;
                    pieza.exhibicion = false;
                }
                else
                {
                    traslado.bodega = false;
                    traslado.caja = null;
                    pieza.exhibicion = true;
                    traslado.vitrina = (int)cmbVitrina.SelectedValue;
                }
                traslado.guardar();
                if (Connection.Objects.Error.isActivo())
                {
                    MessageBox.Show(Connection.Objects.Error.descripcionError, Connection.Objects.Error.nombreError);
                }
                else
                {
                    MessageBox.Show("Se ha guardado exitosamente");
                    borde.Child = anterior;
                }
                pieza.modificar();
            }
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
                txtCodigo.Text = "";
                txtNombrePieza.Text = "";
                rbVitrina.IsChecked = false;
                rbBodega.IsChecked = false;
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

        private void btnSeleccionar_Click(object sender, RoutedEventArgs e)
        {
            if (gvPiezas.SelectedItem != null)
            {
                pieza = (Pieza)gvPiezas.SelectedItem;
                txtCodigo.Text = pieza.codigo;
                txtNombrePieza.Text = pieza.nombre;
                if (pieza.exhibicion == true)
                {
                    rbVitrina.IsChecked = true;
                    rbBodega.IsChecked = false;
                }
                else
                {
                    rbVitrina.IsChecked = false;
                    rbBodega.IsChecked = true;
                }
                //Si ya existe el traslado
                if (traslado.regresarPiezas(pieza.codigo).Count > 0)
                {
                    traslado = (Traslado)traslado.regresarPiezas(pieza.codigo)[0];
                    if (traslado.bodega == true)
                    {
                        rbBodega.IsChecked = true;
                        cmbCaja.SelectedValue = traslado.caja;
                    }
                    else
                    {
                        rbVitrina.IsChecked = true;
                        Vitrina vitrina = new Vitrina();
                        int idV = (int)traslado.vitrina;
                        vitrina.regresarObjeto(idV);
                        cmbSala.SelectedValue = vitrina.sala;
                        int j;
                    }
                }// Si no existe, lo crea
            }
            else
            {
                txtCodigo.Text = "";
                txtNombrePieza.Text = "";
            }
        }
	}
}