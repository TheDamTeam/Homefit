using Homefit.Models;
using Homefit.Models.ApiResponse;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Homefit.Services.Http
{
    public class HttpService : IHttpService
    {
        HttpClient _client;
        public  HttpService()
        {
            _client = new HttpClient();
        }

        public async Task<MaterielResponse> GetMaterielsAsync()
        {
            var response = await _client.GetAsync($"https://thedamteam.fr/api/materiels");
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<MaterielResponse>(content);
            }
            return null;
        }

        public async Task<MaterielResponse> GetUtilisateurMaterielsAsync(int id)
        {
            var response = await _client.GetAsync($"https://thedamteam.fr/api/utilisateurs/{id}/materiels");
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<MaterielResponse>(content);
            }
            return null;
        }

        public async Task<UtilisateurResponse> GetUtilisateursAsync()
        {
            var response = await _client.GetAsync($"https://thedamteam.fr/api/utilisateurs");
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<UtilisateurResponse>(content);
            }
            return null;
        }

        public async Task<bool> SaveUtilisateurAsync(Utilisateur utilisateur, bool isNew = false,int id = 0)
        {
            var json = JsonConvert.SerializeObject(utilisateur);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            HttpResponseMessage response = null;
            if (isNew)
            {
                response = await _client.PostAsync($"https://thedamteam.fr/api/utilisateurs", content);
            }
            else
            {
                response = await _client.PutAsync($"https://thedamteam.fr/api/utilisateurs/{id}", content);
            }
            return response.IsSuccessStatusCode;
        }


        public async Task<RepasResponse> GetRepasAsync()
        {
            var response = await _client.GetAsync($"https://thedamteam.fr/api/repas");
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<RepasResponse>(content);
            }
            return null;
        }

        //"/api/repas_categories/1"
        public async Task<RepasCategorieResponse> GetRepasCategorieAsync(int id)
        {
            var response = await _client.GetAsync($"https://thedamteam.fr/api/repas/{id}/categorie");
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<RepasCategorieResponse>(content);
            }
            return null;
        }
        public async Task<ProgrammeSportifResponse> GetProgrammeSportifAsync()
        {
            try
            {

                var result = await _client.GetAsync($"https://www.thedamteam.fr/api/programme_sportifs/");
                var serializedResponse = await result.Content.ReadAsStringAsync();

                // var result = await client.GetStringAsync("http://www.thedamteam.fr/api/programme_sportifs/");


                var APIResponse = JsonConvert.DeserializeObject<ProgrammeSportifResponse>(serializedResponse);
                return APIResponse;

            }
            catch (Exception ey)
            {
                return null;
            }

        }



        public async Task<EntrainementResponse> GetEntrainementAsync(int idSelected)
        {
            try
            {

                var result = await _client.GetAsync($" https://www.thedamteam.fr/api/programme_sportif/" + idSelected + "/entrainements");
                var serializedResponse = await result.Content.ReadAsStringAsync();

                // var result = await client.GetStringAsync("http://www.thedamteam.fr/api/programme_sportifs/");


                return JsonConvert.DeserializeObject<EntrainementResponse>(serializedResponse);


            }
            catch (Exception ey)
            {
                return null;

            }

        }


        public async Task<DefisResponse> GetDefisAsync()
        {
            var response = await _client.GetAsync($"https://thedamteam.fr/api/defis");
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<DefisResponse>(content);
            }
            return null;
        }

    }
}
