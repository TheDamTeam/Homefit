using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Homefit.Models
{
    public class Classement
    {
        public int Position { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        
        public string Name { 
            get{ return Prenom + " " + Nom; }
        }
        [JsonProperty("max(score)")]
        public int Score { get; set; }

        public Classement()
        {

        }
    }
}
