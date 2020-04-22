using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Homefit.Models
{
    public class Materiel
    {
        public int Id { get; set; }
        public string MaterielName { get; set; }

        public List<Entrainement> Entrainements { get; set; }
        public List<Utilisateur> Utilisateurs { get; set; }

        public Materiel()
        {

        }
    }
}
