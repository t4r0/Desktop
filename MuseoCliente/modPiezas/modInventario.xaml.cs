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
	/// Lógica de interacción para modInventario.xaml
	/// </summary>
	public partial class modInventario : UserControl
	{
        Connection.Objects.Pieza piezas = new Connection.Objects.Pieza();
        public Border borde;
        public modInventario()
		{
			this.InitializeComponent();
		}

        private void LayoutRoot_Loaded(object sender, RoutedEventArgs e)
        {
            /*Falta consulta de piezas que estan en bodega y las que estan en exhibicion
            gvBodega.ItemsSource = ;
            gvExhibicion.ItemsSource = ;*/
        }

        private void btnNuevaPieza_Click(object sender, RoutedEventArgs e)
        {
            modPieza frm = new modPieza();
            frm.borde = borde;
            //frm.anterior = this;
            borde.Child = frm;
        }

        private void btnBuscar_Click(object sender, RoutedEventArgs e)
        {
            modResultadosPiezas frm = new modResultadosPiezas();
            frm.busqueda = txtBuscar.Text;
            frm.borde = borde;
            frm.anterior = this;
            borde.Child = frm;
        }

        private void btnNuevaClas_Click(object sender, RoutedEventArgs e)
        {
            modClasificacion frm = new modClasificacion();
            frm.borde = borde;
            frm.anterior = this;
            borde.Child = frm;
        }
	}
}