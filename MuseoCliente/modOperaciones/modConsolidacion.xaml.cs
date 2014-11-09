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
	/// Lógica de interacción para modConsolidacion.xaml
	/// </summary>
	public partial class modConsolidacion : UserControl
	{
        public UserControl anterior;
        public Border borde;
        public bool modificar = false;
        public modConsolidacion()
		{
			this.InitializeComponent();
		}

        private void btnTratamientos_Click(object sender, RoutedEventArgs e)
        {
            //
        }
	}
}