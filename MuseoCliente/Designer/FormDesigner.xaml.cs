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
using MuseoCliente.Connection.Objects.Estructura;
using MuseoCliente.Designer.Views;

namespace MuseoCliente.Designer
{
	/// <summary>
	/// Lógica de interacción para FormDesigner.xaml
	/// </summary>
	public partial class FormDesigner : UserControl
	{
        private int items = 1;
		public FormDesigner()
		{
			this.InitializeComponent();
		}

        private void MenuItem_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            FieldViewer viewer = new FieldViewer(new Campo()
            {
                nombre = "campo " + items,
                descripcion = "descripcion",
                id = items,
                tipo = Campo.TiposDeCampo.Texto
            });
            fields.Children.Add(viewer);
            viewer.Focus();
            items++;
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            FieldViewer viewer = new FieldViewer(new Campo()
            {
                nombre = "campo " + items,
                descripcion = "descripcion",
                id = items,
                tipo = Campo.TiposDeCampo.TextoLargo
            });
            fields.Children.Add(viewer);
            viewer.Focus();
            items++;
        }

        private void MenuItem_Click_2(object sender, RoutedEventArgs e)
        {
            FieldViewer viewer = new FieldViewer(new Campo()
            {
                nombre = "campo " + items,
                descripcion = "descripcion",
                id = items,
                tipo = Campo.TiposDeCampo.Fecha
            });
            fields.Children.Add(viewer);
            viewer.Focus();
            items++;
        }

        private void MenuItem_Click_3(object sender, RoutedEventArgs e)
        {
            FieldViewer viewer = new FieldViewer(new Campo()
            {
                nombre = "campo " + items,
                descripcion = "descripcion",
                id = items,
                tipo = Campo.TiposDeCampo.Numerico
            });
            fields.Children.Add(viewer);
            viewer.Focus();
            items++;
        }

        private void MenuItem_Click_4(object sender, RoutedEventArgs e)
        {
            FieldViewer viewer = new FieldViewer(new Campo()
            {
                nombre = "campo " + items,
                descripcion = "descripcion",
                id = items,
                tipo = Campo.TiposDeCampo.OpcionesExclusivas
            });
            fields.Children.Add(viewer);
            viewer.Focus();
            items++;
        }

        private void MenuItem_Click_5(object sender, RoutedEventArgs e)
        {
            FieldViewer viewer = new FieldViewer(new Campo()
            {
                nombre = "campo " + items,
                descripcion = "descripcion",
                id = items,
                tipo = Campo.TiposDeCampo.OpcionMultiple
            });
            fields.Children.Add(viewer);
            viewer.Focus();
            items++;
        }
	}
}