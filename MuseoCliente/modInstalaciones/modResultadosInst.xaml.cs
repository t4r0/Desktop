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
	/// Lógica de interacción para modResultadosInst.xaml
	/// </summary>
	public partial class modResultadosInst : UserControl
	{
        public string busqueda = "";
        private Connection.Objects.Caja cajas = new Connection.Objects.Caja();
        private Connection.Objects.Vitrina vitrinas = new Connection.Objects.Vitrina();
        private Connection.Objects.Sala salas = new Connection.Objects.Sala();
        public UserControl anterior;
        public Border borde;
        public modResultadosInst()
		{
			this.InitializeComponent();
		}

        private void LayoutRoot_Loaded(object sender, RoutedEventArgs e)
        {
            //Cargar resultados
        }

        private void rbCajas_Checked(object sender, RoutedEventArgs e)
        {
            //Pendiente
        }

        private void rbSalas_Checked(object sender, RoutedEventArgs e)
        {
            //Pendiente
        }

        private void rbVitrinas_Checked(object sender, RoutedEventArgs e)
        {
            //Pendiente
        }

        private void btnEditar_Click(object sender, RoutedEventArgs e)
        {
            if (rbCajas.IsChecked == true)
            {
                modCaja frm = new modCaja();
                frm.borde = borde;
                frm.anterior = this;
                frm.id = Convert.ToInt16(gvResultados.SelectedValue.ToString());
                MessageBox.Show(gvResultados.SelectedValue.ToString());
                borde.Child = frm;
            }
            if (rbSalas.IsChecked == true)
            {
                modSala frm = new modSala();
                frm.borde = borde;
                frm.anterior = this;
                frm.id = Convert.ToInt16(gvResultados.SelectedValue.ToString());
                MessageBox.Show(gvResultados.SelectedValue.ToString());
                borde.Child = frm;
            }
            if (rbVitrinas.IsChecked == true)
            {
                modVitrina frm = new modVitrina();
                frm.borde = borde;
                frm.anterior = this;
                frm.id = Convert.ToInt16(gvResultados.SelectedValue.ToString());
                MessageBox.Show(gvResultados.SelectedValue.ToString());
                borde.Child = frm;
            }
        }

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            borde.Child = anterior;
        }
	}
}