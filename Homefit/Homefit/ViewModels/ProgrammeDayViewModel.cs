using Homefit.Models;
using Homefit.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Homefit.ViewModels
{
    public class ProgrammeDayViewModel : BaseViewModel
    {
        string contentLabel = "Jour ";
        string dayNb;
        public string ContentLabel
        {
            get { return contentLabel; }
            set { SetProperty(ref contentLabel, value); }
        }

        public string DayNb
        {
            get { return dayNb; }
            set { SetProperty(ref dayNb, value); }
        }

        public ProgrammeDayViewModel(int dayNb, Utilisateur user)
        {
            this.dayNb = "";
            contentLabel += dayNb;
            this.dayNb = "Jour " + dayNb;
        }
    }
}
