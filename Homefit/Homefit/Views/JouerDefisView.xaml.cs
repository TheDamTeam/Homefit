using Homefit.Models;
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
    public partial class JouerDefisView : ContentPage
    {
        public JouerDefisView()
        {
            InitializeComponent();
        }
        public JouerDefisView(Defis defis)
        {
            InitializeComponent();
            BindingContext = new JouerDefisViewModel(defis) { Navigation = Navigation };
            NavigationPage.SetHasBackButton(this,false);
        }
     
    }
}