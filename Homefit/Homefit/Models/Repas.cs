using System;
using System.Collections.Generic;

namespace Homefit.Models
{
    public class Repas
    {
        public int Id { get; set; }
        public DateTime DateRepas { get; set; }
        public List<string> Aliments { get; set; }
        public List<string> MangerRepas { get; set; }
        public List<string> ProgrammeNutritions { get; set; }
        public string Categorie { get; set; }        
        public int Jour { get; set; }

        public Repas()
        {
            Aliments = new List<string>();
        }
    }
}
