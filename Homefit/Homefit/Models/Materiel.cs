using Newtonsoft.Json;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Homefit.Models
{
    public class Materiel
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("materielName")]
        public string MaterielName { get; set; }

        [JsonIgnore]
        public bool AvoirMateriel { get; set; }

        [JsonIgnore]
        public string ToStr
        {
            get
            {
                return MaterielName +" "+AvoirMateriel;
            }
        }

        [JsonIgnore]
        public List<Entrainement> Entrainements { get; set; }
        
        [JsonIgnore]
        public List<Utilisateur> Utilisateurs { get; set; }

        public Materiel()
        {
            AvoirMateriel = false;
        }
    }
}
