using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Homefit.Models
{
    public class ProgrammeSportif
    {
        
        public int Id { get; set; }

        public string ProgrammeName { get; set; }
        public string Niveau { get; set; }
        public Categorie Categorie { get; set; }
        public List<string> Entrainements { get; set; }
        public List<string> ParticiperProgrammeSportifs { get; set; }

    }
}
