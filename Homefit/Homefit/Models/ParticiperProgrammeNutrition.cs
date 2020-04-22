using System;
using System.Collections.Generic;
using System.Text;

namespace Homefit.Models
{
    public class ParticiperProgrammeNutrition
    {
        public int Id { get; set; }
        public Utilisateur Utilisateur { get; set; }
        public DateTime DateParticipation { get; set; }
        public ProgrammeNutrition ProgrammeNutrition{ get; set; }

}
}
