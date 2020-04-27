using System;

namespace Homefit.Models
{
    public class ParticiperEntrainement
    {
        public int Id { get; set; }
        public DateTime DateParticipation { get; set; }
        public Utilisateur Utilisateur { get; set; }
        public Entrainement Entrainement { get; set; }
    }
}
