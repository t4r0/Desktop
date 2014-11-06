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
using System.Windows.Shapes;
using MuseoCliente.Connection.Objects.Estructura;

namespace MuseoCliente.Designer.Views
{
	/// <summary>
	/// Lógica de interacción para FieldEditor.xaml
	/// </summary>
	public partial class FieldEditor : UserControl
	{
		public delegate void CustomEventHandler(object sender, RoutedEventArgs e);
		public event CustomEventHandler Closed;
        public Campo campo;

        public bool Edited { get; set; }
		public FieldEditor()
		{
			this.InitializeComponent();
            campo = new Campo();
			// A partir de este punto se requiere la inserción de código para la creación del objeto.
		}

        public FieldEditor(Campo campo)
        {
            this.InitializeComponent();
            this.campo = campo;
            Reload();
        }
        public void SetField(Campo campo)
        {
            this.campo = campo;
            this.DataContext = campo;
            Reload();
        }
        private void Reload()
        {
            cmbTipo.SelectedIndex = (int)campo.tipo;
            if (campo.tipo == Campo.TiposDeCampo.OpcionesExclusivas ||
                campo.tipo == Campo.TiposDeCampo.OpcionMultiple)
            {
                LoadOptions(new OptionPanel());
            }
        }

        private void LoadOptions(OptionPanel viewer)
        {
            foreach (string options in campo.opciones)
            {
                viewer.AddOption(options);
            }
            optionsViewer.Child = viewer;
        }
		private void ComboBox_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
		{
			ComboBox cb = (ComboBox) sender;
			switch(cb.SelectedIndex)
			{
				case 4:
				case 5:
				{
                    LoadOptions(new OptionPanel(campo.opciones));
                    optionsViewer.Visibility = Visibility.Visible;
                    break;
				}
				
				default:
				{
					optionsViewer.Visibility = Visibility.Collapsed;
                    break;
				}
			}
		}

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            campo.tipo = (Campo.TiposDeCampo)cmbTipo.SelectedIndex;
            if (cmbTipo.SelectedIndex == 4 || cmbTipo.SelectedIndex == 5)
                campo.opciones = ((OptionPanel)optionsViewer.Child).GetOptions();
            Edited = true;
            if(this.Closed != null)
                this.Closed(this, e);
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Edited = false;
            if (this.Closed != null)
                this.Closed(this, e);
        }
	}
}