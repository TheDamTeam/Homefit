using Homefit.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Homefit.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ParticpeProgView : ContentPage
    {
        public ParticpeProgView(int dayNb)
        {
            InitializeComponent();
            BindingContext = new ParticipProgViewModel(dayNb) { Navigation = Navigation };
        }
    }
}