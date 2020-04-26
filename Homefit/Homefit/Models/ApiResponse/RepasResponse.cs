﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Homefit.Models
{
    public class RepasResponse
    {
        [JsonProperty("@context")]
        public string Context { get; set; }

        [JsonProperty("@id")]
        public string Id { get; set; }

        [JsonProperty("@type")]
        public string Type { get; set; }


        [JsonProperty("@libelle")]
        public string Libelle { get; set; }


        [JsonProperty("hydra:member")]
        public List<Repas> Repas { get; set; }


        [JsonProperty("hydra:totalItems")]
        public int Counter { get; set; }


    }
}
