using Newtonsoft.Json;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

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

        public int IsConnect { get; set; }

        [Ignore]
        public List<string> Materiels { get; set; }

        [Ignore]
        public List<string> ParticiperEntrainements{get; set;}
        
        [Ignore]
        public List<string> ParticiperProgrammeNutritions { get; set; }

        [Ignore]
        public List<string> MangerRepas { get; set; }
        
        [Ignore]
        public List<string> ParticiperProgrammeSportifs { get; set; }

        public string Photo { get; set; } 
        public Utilisateur()
        {
            Materiels = new List<string>();
            Photo = "";
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
            Photo = "";
            ParticiperProgrammeNutritions = new List<string>();
        }
        public Utilisateur(string email, string password, string nom, string prenom, DateTime dateNaiss, float poids, int taille,string sexe)
        {
            Email = email;
            Password = password;
            Nom = nom;
            Prenom = prenom;
            DateNaiss = dateNaiss;
            Poids = poids;
            Taille = taille;
            Sexe = sexe;
            Photo = "";
        }
    }
}
