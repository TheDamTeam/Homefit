using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Homefit.Models
{
    public class Entrainement
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("entrainement_name")]
        public string EntrainementName { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("id_niveau_id")]
        public int Niveau { get; set; }

        [JsonProperty("duree")]
        public TimeSpan Duree { get; set; }

        [JsonIgnore]
        public Categorie Categorie { get; set; }

        [JsonProperty("id_materiel_id")]
        public int? Materiel { get; set; }

        [JsonIgnore]
        public List<ProgrammeSportif> ProgrammeSportifs { get; set; }

        [JsonIgnore]
        public List<ParticiperEntrainement> ParticiperEntrainements { get; set; }

        public Entrainement() { }
    }
}