using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Homefit.Models
{
    public class Categorie
    {
        [PrimaryKey]
        public int Id { get; set; }
        public string Libelle { get; set; }

        [Ignore]
        public List<Entrainement> entrainements { get; set; }

        [Ignore]
        public List<ProgrammeSportif> programmeSportifs { get; set; }

    }
}
