using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using Xamarin.Forms;

namespace Homefit.Views.Controls
{
    public class GradientColorStack : StackLayout
    {
        public Xamarin.Forms.Color StartColor { get; set; }
        public Xamarin.Forms.Color EndColor { get; set; }
    }
}
