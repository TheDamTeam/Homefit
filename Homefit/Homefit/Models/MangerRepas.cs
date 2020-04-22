using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Homefit.Models
{
    public class MangerRepas
    {
        public int Id { get; set; }
        public DateTime DateManger { get; set; }
        public Utilisateur Utilisateur { get; set; }
        public Repas Repas { get; set; }
        
    }
}
