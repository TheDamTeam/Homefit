using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Homefit.Models
{
    public class ParticipeProgNutritifResponse
    {
        [JsonProperty("@context")]
        public string Context { get; set; }

        [JsonProperty("@id")]
        public string Id { get; set; }

        [JsonProperty("@type")]
        public string Type { get; set; }

        [JsonProperty("hydra:member")]
        public List<ParticiperProgrammeNutrition> Participe { get; set; }

        [JsonProperty("hydra:totalItems")]
        public int Counter { get; set; }


    }
}
