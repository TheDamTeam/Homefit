using Homefit.Models;
using Homefit.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Homefit.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProgDayView : ContentPage
    {
        public ProgDayView(int dayNb)
        {
            InitializeComponent();
            BindingContext = new ProgrammeDayViewModel(dayNb);
        }
    }
}