using System;
using System.Collections.Generic;

namespace Homefit.Models
{
    public class Entrainement
    {
        public int Id { get; set; }
        public string EntrainementName { get; set; }
        public string Description { get; set; }

        public Niveau Niveau { get; set; }

        public TimeSpan Duree { get; set; }

        public Categorie Categorie { get; set; }
        
        public Materiel Materiel { get; set; }

        public List<ProgrammeSportif> ProgrammeSportifs { get; set; }
       
        public List<ParticiperEntrainement> ParticiperEntrainements { get; set; }
        
        public Entrainement()
        {

        }
    }
}
