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
            frm.busqueda = txtBuscar.Text;
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
            gvResultados.ItemsSource = investigaciones.regresarTodo();
        }
	}
}