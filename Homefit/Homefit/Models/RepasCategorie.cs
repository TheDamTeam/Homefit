using System;
using System.Collections.Generic;
using System.Text;

namespace Homefit.Models
{
    public class RepasCategorie
    {
        public int Id { get; set; }
        public string Libelle { get; set; }

        public List<Repas> Repas { get; set; }
    }
}
