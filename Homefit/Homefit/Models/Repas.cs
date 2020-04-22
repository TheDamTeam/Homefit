using System;
using System.Collections.Generic;

namespace Homefit.Models
{
    public class Repas
    {
        public int Id { get; set; }
        
        public DateTime DateRepas { get; set; }

        public List<Aliment> Aliments { get; set; }
        
        public List<MangerRepas> MangerRepas { get; set; }
        public List<ProgrammeNutrition> ProgrammeNutritions { get; set; }

        public RepasCategorie RepasCategorie { get; set; }
        public Repas()
        {
            Aliments = new List<Aliment>();
        }
    }
}
