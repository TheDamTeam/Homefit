using Homefit.Models;
using Homefit.Services;
using Homefit.ViewModels.Base;
using Homefit.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Homefit.ViewModels
{
    public class ProgrammeAlimentaireViewModel : BaseViewModel
    {
        public INavigation Navigation { get; set; }


        //Utilisateur utilisateur = await App.DataBase.GetUtilisateurIsConnect();

        public ICommand GetProgramme => new Command(LoadDailyProgram);
        async void LoadDailyProgram()
        {
            Utilisateur utilisateur = await App.DataBase.GetUtilisateurIsConnect();
            int dayNumber = 1;

            await Navigation.PushAsync(new ProgDayView(dayNumber, utilisateur));
        }

        List<Days> days = new List<Days>();
        public List<Days> ListDays
        {
            get { return days; }
            set { SetProperty(ref days, value); }
        }
        public ProgrammeAlimentaireViewModel()
        {
            ListDays = new List<Days>()
            {
                new Days("Jour 1","Jour 2","Jour 3"),
                new Days("Jour 4","Jour 5","Jour 6"),
                new Days("Jour 7","Jour 8","Jour 9"),
                new Days("Jour 10","Jour 11","Jour 12"),
                new Days("Jour 13","Jour 14","Jour 15"),
                new Days("Jour 16","Jour 17","Jour 18"),
                new Days("Jour 19","Jour 20","Jour 21"),
                new Days("Jour 22","Jour 23","Jour 24"),
                new Days("Jour 25","Jour 26","Jour 27"),
                new Days("Jour 28","Jour 29","Jour 30"),
            };
        }

        Days daysSelectec;

        public Days DaysSelected
        {
            get { return daysSelectec; }
            set
            {
                SetProperty(ref daysSelectec, value);
                if (value != null)
                {
                }
            }
        }
    }
}
