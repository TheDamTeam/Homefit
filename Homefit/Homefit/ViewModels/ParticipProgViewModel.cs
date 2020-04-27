using Homefit.Models;
using Homefit.ViewModels.Base;
using Homefit.Views;
using System;
using System.Collections.Generic;
using System.Windows.Input;
using Xamarin.Forms;

namespace Homefit.ViewModels
{
    public class ParticipProgViewModel : BaseViewModel
    {
        #region Properties       
        public INavigation Navigation { get; set; }

        private List<ProgrammeNutrition> progNutritionList;
        public List<ProgrammeNutrition> ProgNutritionList
        {
            get { return progNutritionList; }
            set
            {
                SetProperty(ref progNutritionList, value);
                Height = (ProgNutritionList.Count * 40);
            }
        }

        private ProgrammeNutrition progSelectec;
        public ProgrammeNutrition ProgSelected
        {
            get { return progSelectec; }
            set
            {
                SetProperty(ref progSelectec, value);
                if (value != null)
                {
                }
            }
        }

        private int height;
        public int Height
        {
            get { return height; }
            set { SetProperty(ref height, value); }
        }

        private int dayNumber = 0;
        public int DayNumber
        {
            get { return dayNumber; }
            set { SetProperty(ref dayNumber, value); }
        }
        #endregion

        #region Commands
        public ICommand GetSelectedProg => new Command(LoadSelectedProg);
        #endregion

        public ParticipProgViewModel(int dayNb)
        {
            ProgNutritionList = new List<ProgrammeNutrition>();
            DayNumber = dayNb;
            LoadProgrammeList();
        }

        #region ExecuteCommands
        public async void LoadProgrammeList()
        {
            var apiResponse = await App.Client.GetProgNutritionsAsync();
            if (apiResponse.Counter > 0)
            {
                var programmes = apiResponse.Programme;
                ProgNutritionList = programmes;
            }
        }       

        async void LoadSelectedProg()
        {
            var currentprog = ProgSelected;
            if (currentprog != null)
            {
                Utilisateur utilisateur = await App.DataBase.GetUtilisateurIsConnect();
                var pp = new ParticiperProgrammeNutrition() { DateParticipation = DateTime.Now, Utilisateur = "/api/utilisateurs/" + utilisateur.Id, ProgrammeNutrition = "/api/programme_nutritions/" + currentprog.Id };
                var apiResponse = await App.Client.SaveParticipeProgNutritionAsync(pp);
                if (apiResponse)
                {
                    await Application.Current.MainPage.DisplayAlert("Participer à un programme", "Votre demande à bien été prise en compte !", "Ok");
                    Navigation.RemovePage(Navigation.NavigationStack[Navigation.NavigationStack.Count - 1]);
                    await Navigation.PushAsync(new ProgDayView(dayNumber));
                }
            }
            else
            {
                await Application.Current.MainPage.DisplayAlert("Participer à un programme", "Veuillez sélectionner un programme !", "Ok");
            }
        }
        #endregion

    }
}
