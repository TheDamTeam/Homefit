using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Homefit.Models
{
    public class AlimentResponse
    {
        [JsonProperty("@context")]
        public string Context { get; set; }

        [JsonProperty("@id")]
        public string Id { get; set; }

        [JsonProperty("@type")]
        public string Type { get; set; }

        [JsonProperty("alimentName")]
        public string AlimentName { get; set; }
        [JsonProperty("calorie")]
        public float Calorie { get; set; }
        [JsonProperty("proteine")]
        public float Proteine { get; set; }
        [JsonProperty("glucide")]
        public float Glucide { get; set; }
        [JsonProperty("quantite")]
        public float Quantite { get; set; }



        [JsonProperty("hydra:member")]
        public List<Repas> Repas { get; set; }


        [JsonProperty("hydra:totalItems")]
        public int Counter { get; set; }


    }
}
