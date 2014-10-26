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
        public modInstalaciones()
		{
			this.InitializeComponent();
            gvSalas.ItemsSource = salas.todasSalas();
		}
	}
}