using System;
using System.Collections.Generic;
using System.Text;

namespace Homefit.Models
{
    public class ParticiperDefis
    {
        public int Id { get; set; }
        public DateTime DateParticipation { get; set; }
        public Utilisateur Utilisateur { get; set; }
        public Defis Defis { get; set; }
        public int Score { get; set; }
    }
}
