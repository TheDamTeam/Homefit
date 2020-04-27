using System.Collections.Generic;

namespace Homefit.Models
{
    public class ProgrammeNutrition
    {
        public int Id { get; set; }
        public string ProgrammeName { get; set; }
        public List<string> Repas { get; set; }
        public List<string> ParticiperProgrammeNutritions { get; set; }
    }
}
