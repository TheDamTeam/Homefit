﻿using Homefit.Models;
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
    public class HttpService 
    {
        HttpClient _client;
        public  HttpService()
        {
            _client = new HttpClient();
        }

        public async Task<APIResponse<Materiel>> GetMaterielsAsync()
        {
            var response = await _client.GetAsync($"https://thedamteam.fr/api/materiels");
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<APIResponse<Materiel>>(content);
            }
            return null;
        }

        public async Task<APIResponse<Materiel>> GetUtilisateurMaterielsAsync(int id)
        {
            var response = await _client.GetAsync($"https://thedamteam.fr/api/utilisateurs/{id}/materiels");
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<APIResponse<Materiel>>(content);
            }
            return null;
        }

        public async Task<APIResponse<Utilisateur>> GetUtilisateursAsync()
        {
            var response = await _client.GetAsync($"https://thedamteam.fr/api/utilisateurs");
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<APIResponse<Utilisateur>>(content);
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
        public async Task<bool> SaveParticiperDefisAsync(ParticiperDefis defis)
        {
            var json = JsonConvert.SerializeObject(defis);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await _client.PostAsync($"https://thedamteam.fr/api/participer_defis", content);

            return response.IsSuccessStatusCode;
        }

        public async Task<APIResponse<Repas>> GetRepasAsync()
        {
            var response = await _client.GetAsync($"https://thedamteam.fr/api/repas");
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<APIResponse<Repas>>(content);
            }
            return null;
        }

        //"/api/repas_categories/1"
        public async Task<APIResponse<RepasCategorie>> GetRepasCategorieAsync(int id)
        {
            var response = await _client.GetAsync($"https://thedamteam.fr/api/repas/{id}/categorie");
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<APIResponse<RepasCategorie>>(content);
            }
            return null;
        }
        public async Task<APIResponse<ProgrammeSportif>> GetProgrammeSportifAsync()
        {
            try
            {

                var result = await _client.GetAsync($"https://www.thedamteam.fr/api/programme_sportifs/");
                var serializedResponse = await result.Content.ReadAsStringAsync();

                // var result = await client.GetStringAsync("http://www.thedamteam.fr/api/programme_sportifs/");


                var APIResponse = JsonConvert.DeserializeObject<APIResponse<ProgrammeSportif>>(serializedResponse);
                return APIResponse;

            }
            catch (Exception ey)
            {
                return null;
            }

        }
        public async Task<ParticipeProgNutritifResponse> GetParticipeProgNutritifAsync()
        {
            var response = await _client.GetAsync($"https://thedamteam.fr/api/participer_programme_nutritions");
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<ParticipeProgNutritifResponse>(content);
            }
            return null;
        }
        public async Task<UserProgNutritionResponse> GetUserProgNutritionAsync(int id)
        {
            var response = await _client.GetAsync($"https://thedamteam.fr/api/utilisateurs/" + id + "/programme_nutritions");
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<UserProgNutritionResponse>(content);
            }
            return null;
        }
        public async Task<bool> SaveParticipeProgNutritionAsync(ParticiperProgrammeNutrition prog)
        {
            var json = JsonConvert.SerializeObject(prog);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            HttpResponseMessage response = null;

            response = await _client.PostAsync($"https://thedamteam.fr/api/participer_programme_nutritions", content);

            return response.IsSuccessStatusCode;
        }
        public async Task<ProgrammeNutritifResponse> GetProgNutritionAsync(int id)
        {
            var response = await _client.GetAsync($"https://thedamteam.fr/api/programme_nutritions/" + id);
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<ProgrammeNutritifResponse>(content);
            }
            return null;
        }

        public async Task<ProgrammeNutritifResponses> GetProgNutritionsAsync()
        {
            var response = await _client.GetAsync($"https://thedamteam.fr/api/programme_nutritions");
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<ProgrammeNutritifResponses>(content);
            }
            return null;
        }

        public async Task<APIResponse<Entrainement>> GetEntrainementAsync(int idSelected)
        {
            try
            {

                var result = await _client.GetAsync($" https://www.thedamteam.fr/api/programme_sportif/" + idSelected + "/entrainements");
                var serializedResponse = await result.Content.ReadAsStringAsync();

                // var result = await client.GetStringAsync("http://www.thedamteam.fr/api/programme_sportifs/");


                return JsonConvert.DeserializeObject<APIResponse<Entrainement>>(serializedResponse);


            }
            catch (Exception ey)
            {
                return null;

            }

        }


        public async Task<APIResponse<Defis>> GetDefisAsync()
        {
            var response = await _client.GetAsync($"https://thedamteam.fr/api/defis");
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<APIResponse<Defis>>(content);
            }
            return null;
        }
        public async Task<AlimentResponse> GetAlimentAsync(string id)
        {
            var response = await _client.GetAsync($"https://thedamteam.fr/api/aliments/"+id );
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<AlimentResponse>(content);
            }
            return null;
        }
        public async Task<APIResponse<Aliment>> GetRepasAlimentAsync(int id)
        {
            var response = await _client.GetAsync($"https://thedamteam.fr/api/repas/{id}/aliments");
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<APIResponse<Aliment>>(content);
            }
            return null;
        }
        public async Task<APIResponse<Classement>> GetClassement(int idDefis)
        {
            var response = await _client.GetAsync($"https://thedamteam.fr/api/defis/{idDefis}/classement");
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<APIResponse<Classement>>(content);
            }
            return null;
        }

        public async Task<bool> ParticipeProgrammeSportifAsync(ParticiperProgrammeSportif participerProgrammeSportif)
        {
            try
            {
                var json = JsonConvert.SerializeObject(participerProgrammeSportif);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                HttpResponseMessage response = null;
                response = await _client.PostAsync($"https://thedamteam.fr/api/participer_programme_sportifs", content);
                return response.IsSuccessStatusCode;

            }
            catch (Exception ey)
            {

                return false;


            }

        }
    }
}
