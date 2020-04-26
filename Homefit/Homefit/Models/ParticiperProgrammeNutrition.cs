using Newtonsoft.Json;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

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
        public string ProgrammeNutrition{ get; set; }

}
}
