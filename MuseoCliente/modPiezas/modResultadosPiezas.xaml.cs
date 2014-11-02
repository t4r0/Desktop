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
	/// Lógica de interacción para modResultadosPiezas.xaml
	/// </summary>
	public partial class modResultadosPiezas : UserControl
	{
        public string busqueda = "";
        private Connection.Objects.Pieza piezas = new Connection.Objects.Pieza();
        public UserControl anterior;
        public Border borde;
        public modResultadosPiezas()
		{
			this.InitializeComponent();
		}

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            borde.Child = anterior;
        }

        private void LayoutRoot_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void rbTodas_Click(object sender, RoutedEventArgs e)
        {

        }

        private void rbTodas_Click_1(object sender, RoutedEventArgs e)
        {
            
        }

        private void rbClasif_Click(object sender, RoutedEventArgs e)
        {
            //Pendiente piezas por clasificacion
        }

        private void rbExhibicion_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void rbBodega_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void rbUltimas_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void rbTodas_Checked(object sender, RoutedEventArgs e)
        {
            /*Falta piezas por nombre
            if (piezas.consultarNombre(busqueda) != null)
            {
                gvResultados.SelectedValue = "id";
                gvResultados.ItemsSource = categ.consultarNombre(busqueda);
                MessageBox.Show(categ.consultarNombre(busqueda).Count.ToString());
            }
            else
            {
                MessageBox.Show("No hay categorias con el nombre");
            }*/
        }

        private void rbClasif_Checked(object sender, RoutedEventArgs e)
        {
            //Pendiente piezas por clasificacion
        }

        private void rbExhibicion_Checked(object sender, RoutedEventArgs e)
        {
            //Pendiente piezas en exhibicion
        }

        private void rbBodega_Checked(object sender, RoutedEventArgs e)
        {
            //Pendiente piezas en bodega
        }

        private void rbUltimas_Checked(object sender, RoutedEventArgs e)
        {
            //Pendiente ultimas piezas
        }

        private void btnEditar_Click(object sender, RoutedEventArgs e)
        {
            modPieza frm = new modPieza();
            frm.borde = borde;
            //frm.anterior = this;
            //frm.id = Convert.ToInt16(gvResultados.SelectedValue.ToString());
            borde.Child = frm;
        }
	}
}