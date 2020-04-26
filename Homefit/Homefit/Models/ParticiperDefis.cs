using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Homefit.Models
{
    public class ParticiperDefis
    {

        [JsonIgnore]
        public int Id { get; set; }
        [JsonProperty("dateParticipation")]
        public DateTime DateParticipation { get; set; }
        [JsonProperty("utilisateur")]
        public string Utilisateur { get; set; }
        [JsonProperty("defis")]
        public string Defis { get; set; }
        [JsonProperty("score")]
        public int Score { get; set; }

        public ParticiperDefis(DateTime date, string utilisateur, string defis,int score)
        {
            Id = 0;
            DateParticipation = date;
            Utilisateur = utilisateur;
            Defis = defis;
            Score = score;
        }
    }
}
