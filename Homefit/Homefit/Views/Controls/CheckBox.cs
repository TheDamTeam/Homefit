using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Homefit.Views.Controls
{
    public class CheckBox : View
    {
        public bool IsChecked
        {
            get { return (bool)GetValue(IsCheckedProperty); }
            set { SetValue(IsCheckedProperty, value); }
        }

        public Color Color
        {
            get { return (Color)GetValue(ColorProperty); }
            set { SetValue(ColorProperty, value); }
        }
        public static readonly BindableProperty ColorProperty = BindableProperty.Create(nameof(Color), typeof(Color), typeof(CheckBox), null, propertyChanged: (bindable, oldValue, newvalue) =>
        {
            if (newvalue is Color color && bindable is CheckBox)
            {
                ((CheckBox)bindable).Color = (Color)newvalue;
            }
        });
        public static readonly BindableProperty CheckedProperty = BindableProperty.Create(nameof(Checked), typeof(Command), typeof(CheckBox), null, propertyChanged: (bindable, oldValue, newvalue) =>
        {
            if (newvalue is Command check && bindable is CheckBox)
            {
                ((CheckBox)bindable).Checked = (Command)newvalue;
            }
        });
        public static readonly BindableProperty IsCheckedProperty = BindableProperty.Create(nameof(IsChecked), typeof(bool), typeof(CheckBox), null, propertyChanged: (bindable, oldValue, newvalue) =>
        {
            if (newvalue is bool isChecked && bindable is CheckBox)
            {
                ((CheckBox)bindable).IsChecked = (bool)newvalue;
            }
        });
        public Command Checked
        {
            get { return (Command)GetValue(CheckedProperty); }
            set
            {
                SetValue(CheckedProperty, value);
            }
        }
    }
}
