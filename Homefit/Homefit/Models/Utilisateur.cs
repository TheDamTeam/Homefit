using Newtonsoft.Json;
using SQLite;
using System;
using System.Collections.Generic;

namespace Homefit.Models
{
    [Table("Utilisateur")]
    public class Utilisateur
    {
        [PrimaryKey]
        public int Id { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }
        [JsonProperty("password")]
        public string Password { get; set; }
        [JsonProperty("nom")]
        public string Nom { get; set; }
        [JsonProperty("prenom")]
        public string Prenom { get; set; }
        [JsonProperty("dateNaiss")]
        public DateTime DateNaiss { get; set; }
        [JsonProperty("poids")]
        public float Poids { get; set; }
        [JsonProperty("taille")]
        public int Taille { get; set; }// taille en cm
        [JsonProperty("sexe")]
        public string Sexe { get; set; }
        [JsonProperty("objectifs")]
        public string Ojectifs { get; set; }

        [JsonIgnore]
        public int IsConnect { get; set; }

        [JsonIgnore, Ignore]
        public List<Materiel> MyMateriels { get; set; }

        [Ignore, JsonProperty("materiels")]
        public List<string> Materiels { get; set; }

        [Ignore, JsonProperty("participerEntrainements")]
        public List<string> ParticiperEntrainements { get; set; }

        [Ignore, JsonProperty("participerProgrammeNutrition")]
        public List<string> ParticiperProgrammeNutritions { get; set; }

        [Ignore, JsonProperty("mangerRepas")]
        public List<string> MangerRepas { get; set; }

        [Ignore, JsonProperty("participerProgrammeSportifs")]
        public List<string> ParticiperProgrammeSportifs { get; set; }

        public Utilisateur()
        {
            Materiels = new List<string>();
            ParticiperProgrammeSportifs = new List<string>();
            ParticiperEntrainements = new List<string>();
            MangerRepas = new List<string>();
            ParticiperProgrammeNutritions = new List<string>();
        }
        public Utilisateur(string email, string motDePasse)
        {
            Email = email;
            Password = motDePasse;
            IsConnect = 0;
            Materiels = new List<string>();
            ParticiperProgrammeSportifs = new List<string>();
            ParticiperEntrainements = new List<string>();
            MangerRepas = new List<string>();
            ParticiperProgrammeNutritions = new List<string>();
        }
        public Utilisateur(string email, string password, string nom, string prenom, DateTime dateNaiss, float poids, int taille, string sexe, string objectif)
        {
            Email = email;
            Password = password;
            Nom = nom;
            Prenom = prenom;
            DateNaiss = dateNaiss;
            Poids = poids;
            Taille = taille;
            Sexe = sexe;
            Ojectifs = objectif;
            Materiels = new List<string>();
            ParticiperProgrammeSportifs = new List<string>();
            ParticiperEntrainements = new List<string>();
            MangerRepas = new List<string>();
            ParticiperProgrammeNutritions = new List<string>();
        }
    }
}
