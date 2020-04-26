using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Homefit.Views.Controls
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RoundedImage : ContentView
    {
        public static readonly BindableProperty ImageProperty = BindableProperty.Create(nameof(Image), typeof(ImageSource), typeof(RoundedImage), null, propertyChanged: (bindable, oldValue, newvalue) =>
        {
            if (newvalue is ImageSource image && bindable is RoundedImage)
            {
                ((RoundedImage)bindable).image.Source = (ImageSource)newvalue;
            }
        });
        public static readonly BindableProperty SizeProperty = BindableProperty.Create(nameof(Size), typeof(Size), typeof(RoundedImage), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            if (newValue is Size size && bindable is RoundedImage)
            {
                ((RoundedImage)bindable).frame.HeightRequest = size.Height;
                ((RoundedImage)bindable).frame.WidthRequest = size.Width;
                ((RoundedImage)bindable).frame.CornerRadius = (float)size.Height / 2;
            }
        });

        public Size Size
        {
            get { return (Size)GetValue(SizeProperty); }
            set { SetValue(SizeProperty, value); }
        }
        public ImageSource Image
        {
            get { return (ImageSource)GetValue(ImageProperty); }
            set { SetValue(ImageProperty, value); }
        }
        public RoundedImage()
        {
            InitializeComponent();
        }
    }
}