using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Homefit.Models
{
    [Table("Aliment")]
    public class Aliment
    {
        [PrimaryKey]
        public int Id { get; set; }
        public string AlimentName { get; set; }
        public float Calorie { get; set; }
        public float Proteine { get; set; }
        public float Glucide { get; set; }
        public float Quantite { get; set; }

        [Ignore]
        public List<Repas> repas { get; set; }

        public Aliment()
        {

        }
    }
}
