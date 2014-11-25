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

namespace MuseoCliente
{
	/// <summary>
	/// Lógica de interacción para modInstalaciones.xaml
	/// </summary>
	public partial class modInstalaciones : UserControl
	{
        Sala salas = new Sala();
        Caja cajas = new Caja();
        Vitrina vitrinas = new Vitrina();
        Pieza piezas = new Pieza();
        public Border borde;
        public modInstalaciones()
		{
			this.InitializeComponent();
		}

        private void LayoutRoot_Loaded(object sender, RoutedEventArgs e)
        {
            actualizarTablas();
        }

        private void btnNuevaSala_Click(object sender, RoutedEventArgs e)
        {
            modSala frm = new modSala();
            frm.borde = borde;
            frm.anterior = this;
            borde.Child = frm;
        }

        private void btnNuevaVitrina_Click(object sender, RoutedEventArgs e)
        {
            modVitrina frm = new modVitrina();
            frm.borde = borde;
            frm.anterior = this;
            borde.Child = frm;
        }

        private void btnNuevaCaja_Click(object sender, RoutedEventArgs e)
        {
            modCaja frm = new modCaja();
            frm.borde = borde;
            frm.anterior = this;
            borde.Child = frm;
        }

        private void btnTraslado_Click(object sender, RoutedEventArgs e)
        {
            modTraslado frm = new modTraslado();
            frm.borde = borde;
            frm.anterior = this;
            borde.Child = frm;
        }

        private void btnBuscar_Click(object sender, RoutedEventArgs e)
        {
            modResultadosInst frm = new modResultadosInst();
            frm.busqueda = txtBuscar.Text;
            frm.borde = borde;
            frm.anterior = this;
            borde.Child = frm;
        }

        private void btnEditarSala_Click(object sender, RoutedEventArgs e)
        {
            if (gvSalas.SelectedItem != null)
            {
                modSala frm = new modSala();
                frm.borde = borde;
                frm.anterior = this;
                frm.modificar = true;
                frm.DataContext = gvSalas.SelectedItem;
                borde.Child = frm;
            }
            else
            {
                MessageBox.Show("Debe seleccionar una sala para editar", "Advertencia");
            }
        }

        private void btnEditarCaja_Click(object sender, RoutedEventArgs e)
        {
            if (gvCajas.SelectedItem != null)
            {
                modCaja frm = new modCaja();
                frm.borde = borde;
                frm.anterior = this;
                frm.modificar = true;
                frm.id = Convert.ToInt16(gvCajas.SelectedValue.ToString());
                borde.Child = frm;
            }
            else
            {
                MessageBox.Show("Debe seleccionar una sala para editar", "Advertencia");
            }
        }

        private void btnEditarVitrina_Click(object sender, RoutedEventArgs e)
        {
            if (gvVitrinas.SelectedItem != null)
            {
                modVitrina frm = new modVitrina();
                frm.borde = borde;
                frm.anterior = this;
                frm.modificar = true;
                frm.id = Convert.ToInt16(gvVitrinas.SelectedValue.ToString());
                borde.Child = frm;
            }
            else
            {
                MessageBox.Show("Debe seleccionar una sala para editar", "Advertencia");
            }
        }

        private void btnEliminarSala_Click(object sender, RoutedEventArgs e)
        {
            if (gvSalas.SelectedItem != null)
            {
                Sala sala = new Sala();
                sala = (Sala)gvSalas.SelectedItem;
                sala.eliminar();
                if (Connection.Objects.Error.isActivo())
                {
                    MessageBox.Show(Connection.Objects.Error.descripcionError, Connection.Objects.Error.nombreError);
                }
                else
                {
                    MessageBox.Show("Se ha eliminado correctamente", "Correcto");
                    actualizarTablas();
                }
            }
            else
            {
                MessageBox.Show("Debe seleccionar una clasificación antes de eliminar", "Advertencia");
            }
        }

        public void actualizarTablas()
        {
            gvSalas.ItemsSource = salas.regresarTodos();
            gvCajas.ItemsSource = cajas.regresarTodo();
            gvVitrinas.ItemsSource = vitrinas.regresarTodos();
            gvPiezas.ItemsSource = piezas.buscarBodega();
            gvSalas.SelectedValuePath = "id";
            gvCajas.SelectedValuePath = "id";
            gvVitrinas.SelectedValuePath = "id";
        }

        private void btnEliminarCaja_Click(object sender, RoutedEventArgs e)
        {
            if (gvCajas.SelectedItem != null)
            {
                Caja caja = new Caja();
                caja = (Caja)gvCajas.SelectedItem;
                caja.eliminar();
                if (Connection.Objects.Error.isActivo())
                {
                    MessageBox.Show(Connection.Objects.Error.descripcionError, Connection.Objects.Error.nombreError);
                }
                else
                {
                    MessageBox.Show("Se ha eliminado correctamente", "Correcto");
                    actualizarTablas();
                }
            }
            else
            {
                MessageBox.Show("Debe seleccionar una clasificación antes de eliminar", "Advertencia");
            }
        }

        private void btnEliminarVitrina_Click(object sender, RoutedEventArgs e)
        {
            if (gvVitrinas.SelectedItem != null)
            {
                Vitrina vitrina = new Vitrina();
                vitrina = (Vitrina)gvVitrinas.SelectedItem;
                vitrina.eliminar();
                if (Connection.Objects.Error.isActivo())
                {
                    MessageBox.Show(Connection.Objects.Error.descripcionError, Connection.Objects.Error.nombreError);
                }
                else
                {
                    MessageBox.Show("Se ha eliminado correctamente", "Correcto");
                    actualizarTablas();
                }
            }
            else
            {
                MessageBox.Show("Debe seleccionar una clasificación antes de eliminar", "Advertencia");
            }
        }
	}
}