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
	/// Lógica de interacción para modResultadosInv.xaml
	/// </summary>
	public partial class modResultadosInv : UserControl
	{
        public string busqueda = "";
        private Connection.Objects.Investigacion investigaciones = new Connection.Objects.Investigacion();
        public UserControl anterior;
        public Border borde;
        public modResultadosInv()
		{
			this.InitializeComponent();
		}

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            borde.Child = anterior;
        }

        private void rbTodas_Click(object sender, RoutedEventArgs e)
        {
            gvResultados.ItemsSource = investigaciones.regresarTodo();
        }

        private void rbAutor_Click(object sender, RoutedEventArgs e)
        {
            //Pendiente
        }

        private void rbEditor_Checked(object sender, RoutedEventArgs e)
        {
            //Pendiente
        }

        private void rbUltimas_Checked(object sender, RoutedEventArgs e)
        {
            //Pendiente
        }

        private void btnEditar_Click(object sender, RoutedEventArgs e)
        {
            modInvestigacion frm = new modInvestigacion();
            frm.borde = borde;
            frm.anterior = this;
            frm.id = Convert.ToInt16(gvResultados.SelectedValue.ToString());
            borde.Child = frm;
        }
	}
}