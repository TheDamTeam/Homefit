using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Homefit.Services.Navigation
{
    public interface INavigationService
    {
        void SetCurrentPage(Page page);
    }
}
