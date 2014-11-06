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
	/// Lógica de interacción para modVitrina.xaml
	/// </summary>
	public partial class modVitrina : UserControl
	{
        Connection.Objects.Vitrina vitrina = new Connection.Objects.Vitrina();
        Connection.Objects.Sala salas = new Connection.Objects.Sala();
        public UserControl anterior;
        public Border borde;
        public bool modificar = false;
        public int id;
        public modVitrina()
		{
			this.InitializeComponent();
		}

        private void LayoutRoot_Loaded(object sender, RoutedEventArgs e)
        {
            cmbSala.ItemsSource = salas.regresarTodos();
            cmbSala.DisplayMemberPath = "nombre";
            cmbSala.SelectedValuePath = "id";
            //Si es para modificar
            if (modificar == true)
            {
                lblOperaciones.Content = "Modificar Vitrina";
                vitrina.regresarObjeto(id);//Esta mal el retorno del objeto
                cmbSala.SelectedValue = vitrina.sala;
                txtNumero.Text = vitrina.numero;
            }
            else
            {
                lblOperaciones.Content = "Nueva Vitrina";
            }
        }

        private void btnGuardar_Click(object sender, RoutedEventArgs e)
        {
            //vitrina.sala = Convert.ToInt16(cmbSala.SelectedValue.ToString());
            vitrina.sala = (int)cmbSala.SelectedValue;
            vitrina.numero = txtNumero.Text;
            if (modificar == false)
            {
                vitrina.guardar();
            }
            else
            {
                vitrina.modificar();
            }
            if (Connection.Objects.Error.isActivo())
            {
                MessageBox.Show(Connection.Objects.Error.descripcionError, Connection.Objects.Error.nombreError);
            }
            else
            {
                MessageBox.Show("Se han guardado los datos correctamente");
                borde.Child = anterior;
            }
        }

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            borde.Child = anterior;
        }
	}
}