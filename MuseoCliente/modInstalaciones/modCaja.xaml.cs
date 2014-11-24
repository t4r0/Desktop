using System.Windows;
using System.Windows.Controls;

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

        private void btnGuardar_Click( object sender, RoutedEventArgs e )
        {
            caja.codigo = txtCodigo.Text;
            if (!txtCodigo.Text.Equals(""))
            {
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
                    MessageBox.Show("Se ha guardado exitosamente");
                    borde.Child = anterior;
                }
            }
            
        }

        private void LayoutRoot_Loaded( object sender, RoutedEventArgs e )
        {
            //Si es para modificar
            if( modificar == true )
            {
                lblOperacion.Content = "Modificar Caja";
                caja.regresarObjeto(id);
                txtCodigo.Text = caja.codigo;
            }
            else
            {
                lblOperacion.Content = "Nueva Caja";
            }
        }

        private void btnCancelar_Click( object sender, RoutedEventArgs e )
        {
            borde.Child = anterior;
        }
    }
}