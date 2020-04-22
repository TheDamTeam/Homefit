using Xamarin.Forms;

namespace Homefit.Services.Navigation
{
    public class NavigationService : INavigationService
    {
        public void SetCurrentPage(Page view)
        {
            Application.Current.MainPage = view;
        }
    }
}
