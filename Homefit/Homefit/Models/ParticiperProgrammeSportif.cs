using System;
using System.Collections.Generic;
using System.Text;

namespace Homefit.Models
{
    public class ParticiperProgrammeSportif
    {
        public int Id { get; set; }
        public DateTime DateParticipation { get; set; }
        public Utilisateur Utilisateur { get; set; }
        public ProgrammeSportif ProgrammeSportif { get; set; }
    }
}
