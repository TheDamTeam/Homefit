using System;
using System.Collections.Generic;
using System.Text;

namespace Homefit.Models
{
    public class ProgrammeNutrition
    {
        public int Id { get; set; }
        public string ProgrammeName { get; set; }
        public List<Repas> Repas { get; set; }
        public List<ParticiperProgrammeNutrition> ParticiperProgrammeNutritions { get; set; }
    }
}
