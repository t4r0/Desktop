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
	/// Lógica de interacción para modClasificaciones.xaml
	/// </summary>
	public partial class modClasificaciones : UserControl
	{
        Connection.Objects.Categoria categ = new Connection.Objects.Categoria();
        Connection.Objects.Coleccion colec = new Connection.Objects.Coleccion();
        public modClasificaciones()
		{
			this.InitializeComponent();
		}

        private void LayoutRoot_Loaded(object sender, RoutedEventArgs e)
        {
            gvCategorias.ItemsSource = categ.regresarTodo();
            gvColecciones.ItemsSource = colec.regresarTodo();
        }
	}
}