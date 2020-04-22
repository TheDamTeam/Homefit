using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Homefit.Views.CustomRenderer
{
    public class GradientColorButton : Button
    {
        public Color StartColor { get; set; }
        public Color EndColor { get; set; }
    }
}
