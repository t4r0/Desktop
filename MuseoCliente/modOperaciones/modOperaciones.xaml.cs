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
	/// Lógica de interacción para modOperaciones.xaml
	/// </summary>
	public partial class modOperaciones : UserControl
	{
        Consolidacion consolidaciones = new Consolidacion();
        public Border borde;
        public modOperaciones()
		{
			this.InitializeComponent();
		}

        private void LayoutRoot_Loaded(object sender, RoutedEventArgs e)
        {
            actualizar();
        }

        private void btnNuevaCons_Click(object sender, RoutedEventArgs e)
        {
            modConsolidacion frm = new modConsolidacion();
            frm.borde = borde;
            frm.anterior = this;
            borde.Child = frm;
        }

        private void btnEditar_Click(object sender, RoutedEventArgs e)
        {
            if (gvConsolidaciones.SelectedItem != null)
            {
                modConsolidacion frm = new modConsolidacion();
                frm.borde = borde;
                frm.anterior = this;
                frm.modificar = true;
                frm.id = (int)gvConsolidaciones.SelectedValue;
                borde.Child = frm;
                frm.DataContext = gvConsolidaciones.SelectedItem;
            }
            else
            {
                MessageBox.Show("Debe seleccionar una consolidación para editar","Advertencia");
            }
        }

        private void btnEliminarCons_Click(object sender, RoutedEventArgs e)
        {
            if (gvConsolidaciones.SelectedItem != null)
            {
                Consolidacion consT = new Consolidacion();
                consT = (Consolidacion)gvConsolidaciones.SelectedItem;
                consT.eliminar();
                if (Connection.Objects.Error.isActivo())
                {
                    MessageBox.Show(Connection.Objects.Error.descripcionError, Connection.Objects.Error.nombreError);
                }
                else
                {
                    MessageBox.Show("Se ha eliminado correctamente", "Correcto");
                    actualizar();
                }
            }
            else
            {
                MessageBox.Show("Debe seleccionar una clasificación antes de eliminar", "Advertencia");
            }
        }

        public void actualizar()
        {
            gvConsolidaciones.ItemsSource = consolidaciones.regresarTodo();
            gvConsolidaciones.SelectedValuePath = "id";
        }
	}
}