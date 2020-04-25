﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Homefit.Models
{
    public class Niveau
    {

        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("libelle")]
        public string Libelle { get; set; }

        public List<Entrainement> Entrainements { get; set; }
        public List<ProgrammeSportif> ProgrammeSportifs { get; set; }

    }
}
