using System.Collections.Generic;

namespace Homefit.Models
{
    public class RepasCategorie
    {
        public int Id { get; set; }
        public string Libelle { get; set; }
        public List<string> Repas { get; set; }
    }
}
