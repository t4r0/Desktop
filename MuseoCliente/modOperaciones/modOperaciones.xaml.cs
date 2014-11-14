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
            gvConsolidaciones.ItemsSource = consolidaciones.regresarTodo();
            gvConsolidaciones.SelectedValuePath = "id";
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
            modConsolidacion frm = new modConsolidacion();
            frm.borde = borde;
            frm.anterior = this;
            frm.modificar = true;
            frm.id = (int)gvConsolidaciones.SelectedValue;
            borde.Child = frm;
            frm.DataContext = gvConsolidaciones.SelectedItem;
        }
	}
}