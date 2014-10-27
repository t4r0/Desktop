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
	/// Lógica de interacción para modGaleria.xaml
	/// </summary>
	public partial class modGaleria : UserControl
	{
        Connection.Objects.Clasificacion clas = new Connection.Objects.Clasificacion();
        public modGaleria()
		{
			this.InitializeComponent();
		}

        private void LayoutRoot_Loaded(object sender, RoutedEventArgs e)
        {
            cmbClasificacion.DisplayMemberPath = "name";
            cmbClasificacion.SelectedValuePath = "iso";
            //cmbClasificacion.ItemsSource = clas.regre
        }
	}
}