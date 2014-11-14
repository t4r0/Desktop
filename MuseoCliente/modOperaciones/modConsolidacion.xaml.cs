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
        public int id;
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
                txtCodigoPieza.Text = "";
                txtNombrePieza.Text = "";
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
            consolidacion.pieza = txtCodigoPieza.Text;
            consolidacion.responsable = "Migue4";
            //////////////////////Mantenimientos//////////////////////////////
            List<Mantenimiento> mantens = new List<Mantenimiento>();
            //Limpieza
            if (rbLimpieza.IsChecked == true)
            {
                mante1.procedimiento = 1;
                mante1.metodoMaterial = txtLimpieza.Text;
                mante1.fecha = dpFechaLimpieza.SelectedDate.Value.Date;
            }
            else
            {
                mante1.procedimiento = 2;
                mante1.metodoMaterial = "";
                mante1.fecha = System.DateTime.Now;
            }
            mantens.Add(mante1);
            //Consolidación
            if (rbConsolidacion.IsChecked == true)
            {
                mante2.procedimiento = 3;
                mante2.metodoMaterial = txtConsolidacion.Text;
                mante2.fecha = dpFechaConsol.SelectedDate.Value.Date;
            }
            else
            {
                mante2.procedimiento = 4;
                mante2.metodoMaterial = "";
                mante2.fecha = System.DateTime.Now;
            }
            mantens.Add(mante2);
            //Eliminación
            if (rbEliminacion.IsChecked == true)
            {
                mante3.procedimiento = 5;
                mante3.metodoMaterial = txtEliminacion.Text;
                mante3.fecha = dpFechaEliminacion.SelectedDate.Value.Date;
            }
            else
            {
                mante3.procedimiento = 6;
                mante3.metodoMaterial = "";
                mante3.fecha = System.DateTime.Now;
            }
            mantens.Add(mante3);
            //Unión
            if (rbUnion.IsChecked == true)
            {
                mante4.procedimiento = 7;
                mante4.metodoMaterial = txtUnion.Text;
                mante4.fecha = dpFechaUnion.SelectedDate.Value.Date;
            }
            else
            {
                mante4.procedimiento = 8;
                mante4.metodoMaterial = "";
                mante4.fecha = System.DateTime.Now;
            }
            mantens.Add(mante4);
            //Otro
            if (rbOtro.IsChecked == true)
            {
                mante5.procedimiento = 9;
                mante5.metodoMaterial = txtOtro.Text;
                mante5.fecha = dpFechaOtro.SelectedDate.Value.Date;
            }
            else
            {
                mante5.procedimiento = 10;
                mante5.metodoMaterial = "";
                mante5.fecha = System.DateTime.Now;
            }
            mantens.Add(mante5);
            //Observaciones
            if (txtObservaciones.Text.Length > 10)
            {
                mante6.procedimiento = 11;
                mante6.metodoMaterial = txtObservaciones.Text;
                mante6.fecha = System.DateTime.Now;
            }
            else
            {
                mante6.procedimiento = 12;
                mante6.metodoMaterial = "";
                mante6.fecha = System.DateTime.Now;
            }
            mantens.Add(mante6);
            consolidacion.ingresarMantenimiento(mantens);
            //Modificar o Guardar
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
        }

        private void LayoutRoot_Loaded(object sender, RoutedEventArgs e)
        {
            if (modificar == true)
            {
                lblOperacion.Content = "Modificar Consolidación";
                //Obtener Consolidacion
                Consolidacion temp = new Consolidacion();
                temp.regresarObjeto(id);
                txtCodigoPieza.Text = temp.pieza;
                Pieza temp2 = new Pieza();
                temp2.regresarObjeto(temp.pieza);
                txtNombrePieza.Text = temp2.nombre;
                if (temp.limpieza == false)
                {
                    rbLimpieza.IsChecked = false;
                    rbRestaurar.IsChecked = true;
                }
                //Mantenimientos
                List<Mantenimiento> mantenimientos = new List<Mantenimiento>();
                mantenimientos = temp.mantenimientos;
                for (int i = 0; i < mantenimientos.Count; i++)
                {
                    //Limpieza
                    if (mantenimientos[i].procedimiento == 1)
                    {
                        rbLimpieza.IsChecked = true;
                        rbNN1.IsChecked = false;
                        txtLimpieza.Text = mantenimientos[i].metodoMaterial;
                        dpFechaLimpieza.SelectedDate = mantenimientos[i].fecha;
                        mante1 = mantenimientos[i];
                    }
                    if (mantenimientos[i].procedimiento == 2)
                    {
                        rbLimpieza.IsChecked = false;
                        rbNN1.IsChecked = true;
                        txtLimpieza.Text = "";
                        dpFechaLimpieza.SelectedDate = null;
                        mante1 = mantenimientos[i];
                    }
                    //Consolidación
                    if (mantenimientos[i].procedimiento == 3)
                    {
                        rbConsolidacion.IsChecked = true;
                        rbNN2.IsChecked = false;
                        txtConsolidacion.Text = mantenimientos[i].metodoMaterial;
                        dpFechaConsol.SelectedDate = mantenimientos[i].fecha;
                        mante2 = mantenimientos[i];
                    }
                    if (mantenimientos[i].procedimiento == 4)
                    {
                        rbConsolidacion.IsChecked = false;
                        rbNN2.IsChecked = true;
                        txtConsolidacion.Text = "";
                        dpFechaConsol.SelectedDate = null;
                        mante2 = mantenimientos[i];
                    }
                    //Eliminación
                    if (mantenimientos[i].procedimiento == 5)
                    {
                        rbEliminacion.IsChecked = true;
                        rbNN3.IsChecked = false;
                        txtEliminacion.Text = mantenimientos[i].metodoMaterial;
                        dpFechaEliminacion.SelectedDate = mantenimientos[i].fecha;
                        mante3 = mantenimientos[i];
                    }
                    if (mantenimientos[i].procedimiento == 6)
                    {
                        rbEliminacion.IsChecked = false;
                        rbNN3.IsChecked = true;
                        txtEliminacion.Text = "";
                        dpFechaEliminacion.SelectedDate = null;
                        mante3 = mantenimientos[i];
                    }
                    //Unión
                    if (mantenimientos[i].procedimiento == 7)
                    {
                        rbUnion.IsChecked = true;
                        rbNN4.IsChecked = false;
                        txtUnion.Text = mantenimientos[i].metodoMaterial;
                        dpFechaUnion.SelectedDate = mantenimientos[i].fecha;
                        mante4 = mantenimientos[i];
                    }
                    if (mantenimientos[i].procedimiento == 8)
                    {
                        rbUnion.IsChecked = false;
                        rbNN4.IsChecked = true;
                        txtUnion.Text = "";
                        dpFechaUnion.SelectedDate = null;
                        mante4 = mantenimientos[i];
                    }
                    //Otros
                    if (mantenimientos[i].procedimiento == 9)
                    {
                        rbOtro.IsChecked = true;
                        rbNN5.IsChecked = false;
                        txtOtro.Text = mantenimientos[i].metodoMaterial;
                        dpFechaOtro.SelectedDate = mantenimientos[i].fecha;
                        mante5 = mantenimientos[i];
                    }
                    if (mantenimientos[i].procedimiento == 10)
                    {
                        rbOtro.IsChecked = false;
                        rbNN5.IsChecked = true;
                        txtOtro.Text = "";
                        dpFechaOtro.SelectedDate = null;
                        mante5 = mantenimientos[i];
                    }
                    //Observaciones
                    if (mantenimientos[i].procedimiento == 11)
                    {
                        txtObservaciones.Text = mantenimientos[i].metodoMaterial;
                        mante6 = mantenimientos[i];
                    }
                    if (mantenimientos[i].procedimiento == 12)
                    {
                        txtObservaciones.Text = "";
                        mante6 = mantenimientos[i];
                    }
                }
            }
            else
            {
                lblOperacion.Content = "Nueva Consolidación";
            }
        }
	}
}