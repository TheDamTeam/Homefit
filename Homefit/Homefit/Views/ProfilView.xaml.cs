using Homefit.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Homefit.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProfilView : ContentPage
    {
        public ProfilView()
        {
            InitializeComponent();
            BindingContext = new ProfilViewModel() { Navigation = Navigation };
        }

    }
}