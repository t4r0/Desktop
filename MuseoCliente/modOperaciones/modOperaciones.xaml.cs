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
	/// Lógica de interacción para modOperaciones.xaml
	/// </summary>
	public partial class modOperaciones : UserControl
	{
        Connection.Objects.Eventos eventos = new Connection.Objects.Eventos();
        public Border borde;
        public modOperaciones()
		{
			this.InitializeComponent();
		}
	}
}