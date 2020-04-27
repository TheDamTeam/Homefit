using Newtonsoft.Json;
using System;

namespace Homefit.Models
{
    public class Defis
    {
        public int Id { get; set; }
        public string Libelle { get; set; }
        public DateTime Duree { get; set; }
        public string Description { get; set; }
        [JsonIgnore]
        public string Devise
        {
            get
            {
                if (Duree.Minute < 1)
                {
                    return "secondes";
                }
                return "minutes";
            }
        }
    }
}
