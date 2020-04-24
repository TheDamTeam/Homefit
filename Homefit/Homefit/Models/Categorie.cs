using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Homefit.Models
{
    public class Categorie
    {
        public int Id { get; set; }
        public string Libelle { get; set; }

        public List<Entrainement> Entrainements { get; set; }

        public List<ProgrammeSportif> ProgrammeSportifs { get; set; }

    }
}
