using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

namespace MuseoCliente.Designer
{
    /// <summary>
    ///  Realice los pasos 1a o 1b y luego 2 para usar este control personalizado en un archivo XAML.
    ///
    /// Paso 1a) Usar este control personalizado en un archivo XAML existente en el proyecto actual.
    /// Agregue este atributo XmlNamespace al elemento raíz del archivo de marcado en el que 
    /// se va a utilizar:
    ///
    ///     xmlns:MyNamespace="clr-namespace:Designer"
    ///
    ///
    /// Paso 1b) Usar este control personalizado en un archivo XAML existente en otro proyecto.
    /// Agregue este atributo XmlNamespace al elemento raíz del archivo de marcado en el que 
    /// se va a utilizar:
    ///
    ///     xmlns:MyNamespace="clr-namespace:Designer;assembly=Designer"
    ///
    /// Tendrá también que agregar una referencia de proyecto desde el proyecto en el que reside el archivo XAML
    /// hasta este proyecto y recompilar para evitar errores de compilación:
    ///
    ///     Haga clic con el botón secundario del mouse en el proyecto de destino en el Explorador de soluciones y seleccione
    ///     "Agregar referencia"->"Proyectos"->[Busque y seleccione este proyecto]
    ///
    ///
    /// Paso 2)
    /// Prosiga y utilice el control en el archivo XAML.
    ///
    ///     <MyNamespace:MaskedTextBox/>
    ///
    /// </summary>
    public class MaskedTextBox : TextBox
    {
        public enum MaskType
        { 
            Any, 
            Number,
            Date,
            EMail,
            TextOnly,
            Custom
        }

        private Brush OriginalBrush;
        private Brush OriginalForeground;

        public delegate void CustomEventHandler(object sender, TextCompositionEventArgs e, string message);
        public event CustomEventHandler ValidateInput;
        
        [Category("Miscelaneous")]
        public bool IsValid
        {
            get{return (bool)GetValue(IsValidProperty);}
            set { SetValue(IsValidProperty, value); }
        }

        public static readonly DependencyProperty IsValidProperty =
            DependencyProperty.Register("IsValid", typeof(bool), typeof(MaskedTextBox),
            new PropertyMetadata(true));

        [Category("Brushes")]
        public Brush InvalidBorderBrush
        {
            get { return (Brush)GetValue(InvalidBorderBrushProperty); }
            set { SetValue(InvalidBorderBrushProperty, value); }
        }

        public static readonly DependencyProperty InvalidBorderBrushProperty =
            DependencyProperty.Register("InvalidBorderBrush", typeof(Brush), typeof(MaskedTextBox),
             new PropertyMetadata(new SolidColorBrush(Color.FromRgb(255, 0, 0))));

        [Category("Brushes")]
        public Brush InvalidForegroundBrush
        {
            get { return (Brush)GetValue(InvalidForegroundBrushProperty); }
            set { SetValue(InvalidForegroundBrushProperty, value); }
        }

        public static readonly DependencyProperty InvalidForegroundBrushProperty =
          DependencyProperty.Register("InvalidForegroundBrush", typeof(Brush), typeof(MaskedTextBox),
           new PropertyMetadata(new SolidColorBrush(Color.FromRgb(255, 0, 0))));

        [Category("Validation")]
        public MaskType AllowedType
        {
            get{return (MaskType)GetValue(AllowedTypeProperty);}
            set{SetValue(AllowedTypeProperty, value);}
        }

        public static readonly DependencyProperty AllowedTypeProperty =
            DependencyProperty.Register("AllowedType",typeof(MaskType), typeof(MaskedTextBox),
            new PropertyMetadata(MaskType.Any));

        [Category("Validation")]
        public string Mask
        {
            get { return (string)GetValue(MaskProperty); }
            set 
            { 
                SetValue(MaskProperty, value);
                SetValue(AllowedTypeProperty, MaskType.Custom);
            }
        }

        public static readonly DependencyProperty MaskProperty =
            DependencyProperty.Register("Mask", typeof(string), typeof(MaskedTextBox),
            new PropertyMetadata(""));

        static MaskedTextBox()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(MaskedTextBox), new FrameworkPropertyMetadata(typeof(MaskedTextBox)));
        }

        public MaskedTextBox()
        {
        }
        
        protected override void OnPreviewTextInput(TextCompositionEventArgs e)
        {
            base.OnPreviewTextInput(e);
            switch(AllowedType)
            {
                case MaskType.Any:
                    break;
                case MaskType.Number:
                {
                    ValidateNumberInput(e);
                    break;
                }
                case MaskType.Date:
                    {
                        ValidateDateInput(e);
                        break;
                    }
                case MaskType.EMail:
                    {
                        ValidateRegex(e,@"^\S+@\S+\.\S+", "Ese no es un email valido");
                        break;
                    }
                case MaskType.TextOnly:
                    {
                        ValidateRegex(e, @"^\w*", "Asegurate de incluir solo texto");
                        break;
                    }
                case MaskType.Custom:
                    {
                        ValidateRegex(e, Mask, "Los datos ingresados no corresponden con el patron");
                        break;
                    }
                default:
                    break;
            }            
        }
        
        void RaiseInvalidInputEvent(TextCompositionEventArgs e, object sender, string message)
        {
            if(this.ValidateInput != null)
                this.ValidateInput(sender, e, message);
        }

        void RaiseValidInputEvent(TextCompositionEventArgs e, object sender)
        {
            if(this.ValidateInput != null)
            this.ValidateInput(sender, e, "");
        }

        protected void ValidateRegex(TextCompositionEventArgs e, string pattern, string Message)
        {
            Regex rx = new Regex(pattern);
            if (!rx.Match(this.Text).Success)
            {
                IsValid = false;
                RaiseInvalidInputEvent(e, this, Message);
            }
            else
            {
                IsValid = true;
                RaiseValidInputEvent(e, this);
            }
        }
       

        protected void ValidateNumberInput(TextCompositionEventArgs e)
        {
            try
            {
                Decimal.Parse(this.Text);
                IsValid = true;
                RaiseValidInputEvent(e, this);
            }
            catch (FormatException)
            {
                IsValid = false;
                RaiseInvalidInputEvent(e, this, "Ese no parece ser un número");
            }
        }

        protected void ValidateDateInput(TextCompositionEventArgs e)
        {
            try
            {
                System.DateTime.Parse(this.Text);
                IsValid = true;
                RaiseValidInputEvent(e, this);
            }
            catch (FormatException)
            {
                IsValid = false;
                RaiseInvalidInputEvent(e, this, "Esa no parece ser una fecha");
            }
        }

        
    }
}
