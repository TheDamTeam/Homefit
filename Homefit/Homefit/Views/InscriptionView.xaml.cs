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
    public partial class InscriptionView : ContentPage
    {

        public InscriptionView()
        {
            InitializeComponent();
            BindingContext = new InscriptionViewModel();
        }
    }
}