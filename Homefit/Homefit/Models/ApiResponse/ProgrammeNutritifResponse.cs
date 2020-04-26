using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Homefit.Models
{
    public class ProgrammeNutritifResponse
    {
        [JsonProperty("@context")]
        public string Context { get; set; }

        [JsonProperty("@id")]
        public string Id { get; set; }

        [JsonProperty("@type")]
        public string Type { get; set; }

        [JsonProperty("programmeName")]
        public string ProgrammeName { get; set; }

        [JsonProperty("id")]
        public int id { get; set; }

        [JsonProperty("repas")]
        public List<Repas> Repas { get; set; }

        [JsonProperty("ParticiperProgrammeNutrition")]
        public List<ParticiperProgrammeNutrition> ParticiperProgrammeNutrition { get; set; }

    }

    public class ProgrammeNutritifResponses
    {
        [JsonProperty("@context")]
        public string Context { get; set; }

        [JsonProperty("@id")]
        public string Id { get; set; }

        [JsonProperty("@type")]
        public string Type { get; set; }

        [JsonProperty("hydra:member")]
        public List<ProgrammeNutrition> Programme { get; set; }

        [JsonProperty("hydra:totalItems")]
        public int Counter { get; set; }




    }
}
