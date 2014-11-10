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
using System.ComponentModel;
using MuseoCliente.Designer.Views;

namespace MuseoCliente.Designer.Views
{
	/// <summary>
	/// Lógica de interacción para OptionPanel.xaml
	/// </summary>
	public partial class OptionPanel : UserControl
	{
        
        
        public event RoutedEventHandler OptionAdded;
        
        public event RoutedEventHandler OptionRemoved;

        public delegate void CustomEventHandler(object sender, RoutedEventArgs e, int index);
        public event CustomEventHandler Edited;
        [Category("Custom Options")]
        public bool AutoFocusable
        {
            get;
            set;
        }

        [Category("Custom Options")]
        public bool AllowsNoOptions
        {
            get { return (bool)GetValue(AllowsNoOptionsProperty);}
            set { SetValue(AllowsNoOptionsProperty, value); }
        }

        public static readonly DependencyProperty AllowsNoOptionsProperty =
           DependencyProperty.Register("AllowsNoOptions", typeof(bool), typeof(OptionPanel),
               new FrameworkPropertyMetadata(true ));


        [Category("Custom Options")]
        public string Header
        {
            get { return (string)header.Content; }
            set { header.Content = value; }
        }

        List<OptionViewer> selectedOptions;
        [Category("Custom Options")]
        public List<OptionViewer> SelectedOptions
        {
            get { return selectedOptions; }
        }

        [Category("Custom Options")]
        public OptionViewer SelectedOption
        {
            get;
            set;
        }

        [Category("Custom Options")]
        public FormUtils.Selection SelectionType
        {
            get { return (FormUtils.Selection)GetValue(SelectionTypeProperty); }
            set { SetValue(SelectionTypeProperty, value); }
        }

        public static readonly DependencyProperty SelectionTypeProperty =
            DependencyProperty.Register("SelectionType", typeof(FormUtils.Selection), typeof(OptionPanel),
                new FrameworkPropertyMetadata(FormUtils.Selection.Single, new PropertyChangedCallback(OnSelectionTypeChanged)));

        public static void OnSelectionTypeChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
        }

        [Category("Custom Options")]
        public bool AllowsEdition
        {
            get { return (bool)GetValue(AllowsEditionProperty); }
            set { SetValue(AllowsEditionProperty, value); }
        }

        public static readonly DependencyProperty AllowsEditionProperty =
            DependencyProperty.Register("AllowsEdition", typeof(bool), typeof(OptionPanel),
                new FrameworkPropertyMetadata(true, new PropertyChangedCallback(OnAllowsEditionChanged)));

        public static void OnAllowsEditionChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            OptionPanel panel = d as OptionPanel;
            bool? value = e.NewValue as bool?;
            if(panel!=null && value!= null)
            {
                panel.UpdateEditableComponents((bool)value);
            }

        }

        public void UpdateEditableComponents(bool value)
        {
			addButton.Visibility = value ? Visibility.Visible: Visibility.Hidden;
            UIElementCollection options = optionsPane.Children;
            foreach (OptionViewer viewer in options)
                viewer.IsEditable = value;
        }

		public OptionPanel()
		{
			this.InitializeComponent();
            selectedOptions = new List<OptionViewer>();
		}


        public OptionPanel(List<string> opciones)
        {
            this.InitializeComponent();
            selectedOptions = new List<OptionViewer>();
            LoadOptions(opciones);
        }

        public void LoadOptions(List<string> opciones)
        {
            if (opciones.Count == 0)
                return;
            selectedOptions = new List<OptionViewer>();
            RemoveOptionAt(0);
            foreach (string opcion in opciones)
            {
                this.AddOption(opcion);
            }
        }

		private void OptionViewer_Edited(object sender, System.Windows.RoutedEventArgs e)
		{
            /*OptionViewer viewer = sender as OptionViewer;
            int index=optionsPane.Children.IndexOf(viewer as UIElement);
            this.Edited(viewer, new RoutedEventArgs(), index);*/
		}

		private void addViewer()
		{
			OptionViewer viewer = new OptionViewer();
			optionsPane.Children.Add(viewer);
            viewer.Focus();
            viewer.Edited += OptionViewer_Edited;
			viewer.ClosingRequested += OptionViewer_ClosingRequested;
            viewer.UpdateAction += OptionViewer_UpdateAction_1;
            if(this.OptionAdded != null)
                this.OptionAdded(viewer,new RoutedEventArgs());
		}

        private void addViewer(OptionViewer viewer)
        {
            optionsPane.Children.Add(viewer);
            viewer.Checked += OptionViewer_Checked_1;
            viewer.Edited += OptionViewer_Edited;
            viewer.ClosingRequested += OptionViewer_ClosingRequested;
            viewer.UpdateAction += OptionViewer_UpdateAction_1;
            if(this.OptionAdded != null)
                this.OptionAdded(viewer, new RoutedEventArgs());
        }

        public void AddOption(string option)
        {
            addViewer(new OptionViewer(){Option = option});
            UpdateEditableComponents(AllowsEdition);
        }

        public void RemoveOption(OptionViewer viewer, int index = 0)
        {
            if (optionsPane.Children.Contains(viewer as UIElement))
                optionsPane.Children.Remove(viewer);
            if (selectedOptions.Contains(viewer))
                selectedOptions.Remove(viewer);
            if (SelectedOption!=null && SelectedOption.Equals(viewer))
                SelectedOption = null;
             if(this.OptionRemoved != null)
                this.OptionRemoved(index, new RoutedEventArgs());
        }

        public void RemoveOptionAt(int index)
        {
            RemoveOption(optionsPane.Children[index] as OptionViewer, index);
        }

        public void EditOptionAt(int index, string option)
        {
            OptionViewer viewer = optionsPane.Children[index] as OptionViewer;
            viewer.Option = option;
        }

		private void OptionViewer_ClosingRequested(object sender, System.EventArgs e)
		{
            int index = optionsPane.Children.IndexOf((UIElement)sender);
            if (optionsPane.Children.Count <= 1 && !AllowsNoOptions)
                MessageBox.Show("Debe existir al menos una opción");
            else
            {                
                optionsPane.Children.Remove(sender as UIElement);
                if (index > 0)
                    optionsPane.Children[index - 1].Focus();
                else
                    optionsPane.Children[index].Focus();
            }
		}

		private void Button_Click(object sender, System.Windows.RoutedEventArgs e)
		{
		  addViewer();
		}

		private void optionsPane_Loaded(object sender, System.Windows.RoutedEventArgs e)
		{
            if(optionsPane.Children.Count > 0)
			    optionsPane.Children[0].Focus();
		}

        private void OptionViewer_UpdateAction_1(object sender, EventArgs e)
        {
            int index =optionsPane.Children.IndexOf((UIElement)sender);
            if (index == optionsPane.Children.Count - 1)
                addViewer();
            else
                optionsPane.Children[index + 1].Focus();
        }

        private void OptionViewer_Checked_1(object sender, RoutedEventArgs e)
        {
            
            OptionViewer viewer = sender as OptionViewer;
            switch (this.SelectionType)
            {
                case FormUtils.Selection.Multiple:
                {
                    AddSelectedOption(viewer);
                    break;
                }

                case FormUtils.Selection.Single:
                { 
                    viewer = sender as OptionViewer;
                    if(SelectedOption != null)
                        SelectedOption.IsSelected = false;
                    SelectedOption = viewer;
                    break;
                }
            }
        }

        public void AddSelectedOption(OptionViewer item)
        {
            this.selectedOptions.Add(item);           
        }

        public List<string> GetOptions()
        {
            List<string> opciones = new List<string>();
            foreach (OptionViewer viewer in optionsPane.Children)
            {
                if (viewer.Option != "")
                    opciones.Add(viewer.Option);
            }
            return opciones;
        }
	}
}