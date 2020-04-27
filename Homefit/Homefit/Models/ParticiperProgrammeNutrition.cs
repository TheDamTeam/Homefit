using Newtonsoft.Json;
using System;

namespace Homefit.Models
{
    public class ParticiperProgrammeNutrition
    {
        [JsonIgnore]
        public int Id { get; set; }
        [JsonProperty("utilisateur")]
        public string Utilisateur { get; set; }
        [JsonProperty("dateParticipation")]
        public DateTime DateParticipation { get; set; }
        [JsonProperty("programmeNutrition")]
        public string ProgrammeNutrition { get; set; }

    }
}
