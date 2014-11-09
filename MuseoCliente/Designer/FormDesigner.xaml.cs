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
using Microsoft.Win32;
using MuseoCliente.Connection.Objects.Estructura;
using MuseoCliente.Designer.Views;

namespace MuseoCliente.Designer
{
	/// <summary>
	/// Lógica de interacción para FormDesigner.xaml
	/// </summary>
	public partial class FormDesigner : UserControl
	{
        public bool IsEditing { get; set; }
        public bool saved { get; set; }
        private int items = 1;
		public FormDesigner()
		{
			this.InitializeComponent();
            IsEditing = false;
            saved = false;
		}

        string path = "";
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
            saved = false;
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

        private void MenuItem_Click_6(object sender, RoutedEventArgs e)
        {
            MuseoCliente.Connection.Objects.Ficha ficha =  ((MuseoCliente.Connection.Objects.Ficha)DataContext);
            SetFields(ficha);
            SaveFileDialog dialog = new SaveFileDialog();
            if (dialog.ShowDialog() == true)
            {
                ficha.SerializeToFile(dialog.FileName);
                MessageBox.Show("Todo guardado");
            }
             
        }

        public void Load(MuseoCliente.Connection.Objects.Ficha ficha)
        {
            this.DataContext = ficha;            
            fields.Children.Clear();
            LoadFields(ficha);
        }

        private void MenuItem_Click_7(object sender, RoutedEventArgs e)
        {
            MuseoCliente.Connection.Objects.Ficha ficha = new MuseoCliente.Connection.Objects.Ficha();
            OpenFileDialog dialog = new OpenFileDialog();
            if (dialog.ShowDialog() == true)
            {
                path = dialog.FileName;
                ficha = ficha.DeserializeFromFile(path);
                Load(ficha);
                saved = true;
            }

        }

        private void LoadFields(MuseoCliente.Connection.Objects.Ficha ficha)
        {
            foreach (Campo campo in ficha.estructura.campos)
            {
                items++;
                fields.Children.Add(new FieldViewer(campo));
                
            }
        }

        private void SetFields(MuseoCliente.Connection.Objects.Ficha ficha)
        {
            Estructura est = ficha.estructura;
            est.campos.Clear();
            foreach (FieldViewer viewer in fields.Children)
            {
                est.campos.Add(viewer.GetField());
            }
        }

        private void MenuItem_Click_8(object sender, RoutedEventArgs e)
        {
            MuseoCliente.Connection.Objects.Ficha ficha = (MuseoCliente.Connection.Objects.Ficha)DataContext;
            if (path != "")
            {
                SetFields(ficha);
                ficha.SerializeToFile(path);
                saved = true;
            }
            else
            {
                MenuItem_Click_6(sender, e);
            }
        }

        private void MenuItem_Click_9(object sender, RoutedEventArgs e)
        {

            MessageBoxResult result= MessageBox.Show("¿Deseas Guardar tu trabajo?",
                 "Atención", MessageBoxButton.YesNo);
            if (result == MessageBoxResult.Yes)
                MenuItem_Click_6(sender, e);
            Load(new Connection.Objects.Ficha());
            items = 1;
        }

        private void MenuItem_Click_10(object sender, RoutedEventArgs e)
        {
            Connection.Objects.Ficha ficha = (Connection.Objects.Ficha)DataContext;
            if (IsEditing)
            {
                ficha.modificar();
            }
            else
            {
                ficha.guardar();
            }
            if (Connection.Objects.Error.isActivo())
                MessageBox.Show(Connection.Objects.Error.descripcionError,
                    Connection.Objects.Error.nombreError);
         
        }
	}
}