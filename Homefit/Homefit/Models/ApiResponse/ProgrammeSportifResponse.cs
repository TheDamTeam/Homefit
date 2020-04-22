using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Homefit.Models.ApiResponse
{
    public class ProgrammeSportifResponse
    {
        [JsonProperty("@context")]
        public string Context { get; set; }

        [JsonProperty("@id")]
        public string Id { get; set; }

        [JsonProperty("@type")]
        public string Type { get; set; }

        [JsonProperty("hydra:member")]
        public List<ProgrammeSportif> ProgrammeSportifs { get; set; }


        [JsonProperty("hydra:totalItems")]
        public int Counter { get; set; }
    }
}
