using Newtonsoft.Json;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Homefit.Models
{
    public class Aliment
    {
        public int Id { get; set; }
        [JsonProperty("alimentName")]
        public string AlimentName { get; set; }
        public float Calorie { get; set; }
        public float Proteine { get; set; }
        public float Glucide { get; set; }
        public float Quantite { get; set; }

        [JsonIgnore]
        public List<Repas> repas { get; set; }

        public Aliment()
        {

        }
    }
}
