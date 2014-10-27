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
	/// Lógica de interacción para modInstalaciones.xaml
	/// </summary>
	public partial class modInstalaciones : UserControl
	{
        Connection.Objects.Sala salas = new Connection.Objects.Sala();
        Connection.Objects.Caja cajas = new Connection.Objects.Caja();
        Connection.Objects.Vitrina vitrinas = new Connection.Objects.Vitrina();
        public modInstalaciones()
		{
			this.InitializeComponent();
		}

        private void LayoutRoot_Loaded(object sender, RoutedEventArgs e)
        {
            //gvSalas.ItemsSource = salas.regresarTodos();
            //gvCajas.ItemsSource = cajas.regresarTodo();
            //gvVitrinas.ItemsSource = vitrinas.regresarTodos();
        }
	}
}