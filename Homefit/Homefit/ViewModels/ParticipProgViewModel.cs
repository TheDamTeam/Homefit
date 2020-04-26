using Homefit.Models;
using Homefit.ViewModels.Base;
using Homefit.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace Homefit.ViewModels
{
    public class ParticipProgViewModel : BaseViewModel
    {
        List<ProgrammeNutrition> progNutritionList;

        public INavigation Navigation { get; set; }

        public List<ProgrammeNutrition> ProgNutritionList
        {
            get { return progNutritionList; }
            set { SetProperty(ref progNutritionList, value); }
        }

        int dayNumber = 0;
        public ParticipProgViewModel(int dayNb)
        {
            progNutritionList = new List<ProgrammeNutrition>();
            dayNumber = dayNb;
            loadProgrammeList();
        }

        public async void loadProgrammeList()
        {
            var apiResponse = await App.Client.GetProgNutritionsAsync();
            if(apiResponse.Counter > 0)
            {
                var programmes = apiResponse.Programme;
                ProgNutritionList = programmes;
            }
        }

        ProgrammeNutrition progSelectec;

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

        public ICommand GetSelectedProg => new Command(LoadSelectedProg);
        async void LoadSelectedProg()
        {
            var currentprog = ProgSelected;
            if(currentprog != null)
            {
                Utilisateur utilisateur = await App.DataBase.GetUtilisateurIsConnect();
                var pp = new ParticiperProgrammeNutrition() { DateParticipation = DateTime.Now, Utilisateur = "/api/utilisateurs/" + utilisateur.Id, ProgrammeNutrition = "/api/programme_nutritions/" + currentprog.Id };
                var apiResponse = await App.Client.SaveParticipeProgNutritionAsync(pp);
                if (apiResponse)
                {
                    await Application.Current.MainPage.DisplayAlert("Participer à un programme", "Votre demande à bien été prise en compte !", "Ok");
                    await Navigation.PushAsync(new ProgDayView(dayNumber));
                }
            }
            else
            {
                await Application.Current.MainPage.DisplayAlert("Participer à un programme", "Veuillez sélectionner un programme !", "Ok");
            }
        }


    }
}
