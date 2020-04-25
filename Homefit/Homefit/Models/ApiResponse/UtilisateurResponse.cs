﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Homefit.Models.ApiResponse
{
    public class UtilisateurResponse
    {
        [JsonProperty("@context")]
        public string Context { get; set; }

        [JsonProperty("@id")]
        public string Id { get; set; }

        [JsonProperty("@type")]
        public string Type { get; set; }

        [JsonProperty("hydra:member")]
        public List<Utilisateur> Utilisateurs { get; set; }


        [JsonProperty("hydra:totalItems")]
        public int Counter { get; set; }


    }
}
