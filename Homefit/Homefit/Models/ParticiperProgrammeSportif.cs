using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Homefit.Models
{
    public class ParticiperProgrammeSportif
    {
        [JsonIgnore]
        public int Id { get; set; }
        [JsonProperty("dateParticipation")]
        public DateTime DateParticipation { get; set; }

        [JsonProperty("utilisateur")]
        public string Utilisateur { get; set; }
        [JsonProperty("programmeSportif")]
        public string ProgrammeSportif { get; set; }


        public ParticiperProgrammeSportif(DateTime DateParticipation, string Utilisateur, string ProgrammeSportif)
        {
            this.DateParticipation = DateParticipation;
            this.Utilisateur = Utilisateur;
            this.ProgrammeSportif = ProgrammeSportif;
        }
    }

}
