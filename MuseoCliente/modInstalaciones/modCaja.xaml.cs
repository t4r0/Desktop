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
	/// Lógica de interacción para ucCaja.xaml
	/// </summary>
	public partial class modCaja : UserControl
	{
        Connection.Objects.Caja caja = new Connection.Objects.Caja();
        public UserControl anterior;
        public Border borde;
        public bool modificar = false;
        public int id;
        public modCaja()
		{
			this.InitializeComponent();
		}

        private void btnGuardar_Click(object sender, RoutedEventArgs e)
        {
            caja.codigo = txtCodigo.Text;
            if (modificar == false)
            {
                caja.guardar();
            }
            else
            {
                caja.modificar();
            }
            if (Connection.Objects.Error.isActivo())
            {
                MessageBox.Show(Connection.Objects.Error.nombreError, Connection.Objects.Error.descripcionError);
            }
            else
            {
                MessageBox.Show("Bien puto Ursaring");
            }
        }

        private void LayoutRoot_Loaded(object sender, RoutedEventArgs e)
        {
            //Si es para modificar
            if (modificar == true)
            {
                lblOperacion.Content = "Modificar Caja";
                //categ = categ.buscarPorID(id);
                txtCodigo.Text = "Pendiente";
            }
            else
            {
                lblOperacion.Content = "Nueva Caja";
            }
        }

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            borde.Child = anterior;
        }
	}
}