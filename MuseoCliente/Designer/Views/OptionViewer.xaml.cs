using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.ComponentModel;
using MuseoCliente.Designer;
namespace MuseoCliente.Designer.Views
{
	/// <summary>
	/// Lógica de interacción para OptionViewer.xaml
	/// </summary>
	public partial class OptionViewer : BulletDecorator
	{
       

        public delegate void CustomEventHandler(object sender, EventArgs e);
        public event  CustomEventHandler ClosingRequested;
        public event CustomEventHandler UpdateAction;

        public event RoutedEventHandler Checked;

        int backspaceCount = 0;
        public event RoutedEventHandler Edited;

		public OptionViewer()
		{
			this.InitializeComponent();
		}

        private bool FirstTimeEdited = true;

        [Category("Custom Options")]
        public FormUtils.Selection SelectionType
        {
            get { return (FormUtils.Selection)GetValue(SelectionTypeProperty); }
            set { SetValue(SelectionTypeProperty, value); }
        }

        public static readonly DependencyProperty SelectionTypeProperty =
            DependencyProperty.Register("SelectionType", typeof(FormUtils.Selection), typeof(OptionViewer),
                new FrameworkPropertyMetadata(FormUtils.Selection.Single, new PropertyChangedCallback(OnSelectionTypeChanged)));
        
        public static void OnSelectionTypeChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
        }

        [Category("Custom Options")]
        public bool? IsSelected
        {
            get { return selectedPart.IsChecked; }
            set { selectedPart.IsChecked = value; }
        }

        [Category("Custom Options")]
        public String Option
        {
            get { return content.Text; }
            set { content.Text = value; }
        }

        [Category("Custom Options")]
	    public bool IsEditable
	    {
            get { return (bool)GetValue(IsEditableProperty); }
            set{SetValue(IsEditableProperty,value);}
	    }

        public static readonly DependencyProperty IsEditableProperty =
                                DependencyProperty.Register("IsEditable", typeof(bool), typeof(OptionViewer),
                                new FrameworkPropertyMetadata(true, new PropertyChangedCallback(OnEditableChanged)));
        private static void OnEditableChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            OptionViewer viewer = d as OptionViewer;
            bool? value = e.NewValue as bool?;
            if (value != null && viewer != null)
            {
                viewer.ChangeEditionStatus((bool)value);
            }
        }

        public void ChangeEditionStatus(bool value)
        {
            content.IsEnabled = value; 
			closeButton.Visibility = value ? Visibility.Visible: Visibility.Collapsed;
            bullet.Visibility = value ? Visibility.Visible : Visibility.Collapsed;
            selectedPart.Visibility = value ? Visibility.Collapsed : Visibility.Visible;
        }

        private void closeButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            if(this.ClosingRequested!=null)
        	    this.ClosingRequested(this, new EventArgs());
        }

        private void UserControl_GotFocus(object sender, RoutedEventArgs e)
        {
            content.Focus();
            content.SelectAll();
        }

        private void content_TextInput(object sender, TextCompositionEventArgs e)
        {
          
        }

        private void content_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter || e.Key == Key.Tab)
            {
                this.UpdateAction(this, new EventArgs());
            }
        }

        private void content_KeyUp(object sender, KeyEventArgs e)
        {
            if (content.Text.Equals("") && backspaceCount >=2)
                this.ClosingRequested(this, new EventArgs());
            if (e.Key == Key.Back || e.Key == Key.Delete)
                backspaceCount++;
            if (IsEditable && this.Edited != null)
                Edited(this, new RoutedEventArgs());
        }

        private void UserControl_LostFocus(object sender, RoutedEventArgs e)
        {
            backspaceCount = 0;
        }

        private void selectedPart_Checked(object sender, RoutedEventArgs e)
        {
            if(this.Checked != null && !this.IsEditable)
                this.Checked(sender, e);
        }

    }
}