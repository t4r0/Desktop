using System;
using System.ComponentModel;
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


namespace MuseoCliente.Designer.Views
{
	/// <summary>
	/// Lógica de interacción para FieldViewer.xaml
	/// </summary>
	public partial class FieldViewer : UserControl
	{
        private Campo campo = new Campo();
        [Category("Custom Options")]
        public bool IsEditable
        {
            get { return (bool)GetValue(IsEditableProperty); }
            set { SetValue(IsEditableProperty, value); }
        }

        public static readonly DependencyProperty IsEditableProperty = DependencyProperty.Register("IsEditable", typeof(bool), typeof(FieldViewer),
            new FrameworkPropertyMetadata(true, new PropertyChangedCallback(OnIsEditableChanged)));
        
        public static void OnIsEditableChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            bool? value = (bool?)e.NewValue;
            FieldViewer viewer = d as FieldViewer;
            if (value != null && viewer != null)
                viewer.UpdateVisibility((bool)value);
        }

        public void SetField(Campo campo)
        {
            this.campo = campo;
            LoadField();
        }

        public Campo GetField()
        {
            return campo;
        }

        private void UpdateVisibility(bool value)
        {
            editButton.Visibility = value ? Visibility.Visible : Visibility.Hidden;
            cancelButton.Visibility = value ? Visibility.Visible : Visibility.Hidden;
            content.IsEnabled = !value;
        }

        public FieldViewer(Campo campo)
        {
            this.InitializeComponent();
            this.campo = campo;
            LoadField();
        }

        private void LoadField()
        {
            content.Child = null;
            lblNombre.Content = campo.id + ". " + campo.nombre;
            lblDescripcion.Content = campo.descripcion;
             MaskedTextBox txt = new MaskedTextBox()
             {
                            MinHeight = 27,
                            HorizontalAlignment = System.Windows.HorizontalAlignment.Stretch,
                            VerticalAlignment = System.Windows.VerticalAlignment.Stretch,
                            Margin = new Thickness(0, 5, 0, 5)
             };
            switch (campo.tipo)
            {
                case Campo.TiposDeCampo.Texto:
                    {                       
                        PutATextBoxThere(txt);
                        break;
                    }
                case Campo.TiposDeCampo.TextoLargo:
                    {
                        txt.MinHeight = 150;
                        PutATextBoxThere(txt);
                        break;
                    }
                case Campo.TiposDeCampo.Fecha:
                    {
                        PutADatePickerThere();
                        break;
                    }
                case Campo.TiposDeCampo.Numerico:
                    {
                        txt.AllowedType = MaskedTextBox.MaskType.Number;
                        PutATextBoxThere(txt);
                        break;
                    }
                case Campo.TiposDeCampo.OpcionMultiple:
                    {
                        PutAnOptionPanelThere();
                        break;
                    }
                case Campo.TiposDeCampo.OpcionesExclusivas:
                    {
                        PutAComboBoxThere();
                        break;
                    }
            }
        }

        private void PutAComboBoxThere()
        {
            ComboBox combobox = new ComboBox() { MinHeight = 25, Margin = new Thickness(0,5,0,5) };
            combobox.Style = Application.Current.Resources["CustomComboBox"] as Style;
            combobox.ItemsSource = campo.opciones;
            content.Child = combobox;
        }

        private void PutAnOptionPanelThere()
        {
            OptionPanel opt = new OptionPanel(campo.opciones)
            {
                AllowsEdition = false
            };
            opt.SelectionType = campo.tipo == Campo.TiposDeCampo.OpcionesExclusivas ?
                FormUtils.Selection.Single : FormUtils.Selection.Multiple;
            content.Child = opt;
        }
        private void PutATextBoxThere(MaskedTextBox txt)
        {
            txt.Style = Application.Current.Resources["CustomMaskedTextBox"] as Style;
            this.content.Child = txt;
        }

        private void PutADatePickerThere()
        {
            DatePicker dtPicker = new DatePicker()
            {
                DisplayDate = System.DateTime.Now,
                MinHeight = 25,
                Margin = new Thickness(0, 5, 0, 5)
            };
            this.content.Child = dtPicker;
        }
		public FieldViewer()
		{
			this.InitializeComponent();
		}

        private void editButton_Click(object sender, RoutedEventArgs e)
        {
           
        }

        private void editButton_Checked(object sender, System.Windows.RoutedEventArgs e)
        {
            editor.SetField(campo);
        }

        private void editor_Closed(object sender, RoutedEventArgs e)
        {
            if (editor.Edited)
            {
                this.campo = editor.campo;
                this.LoadField();
            }
            editButton.IsChecked = false;
        }
	}
}