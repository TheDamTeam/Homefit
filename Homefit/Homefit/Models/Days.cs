using System;
using System.Collections.Generic;
using System.Text;

namespace Homefit.Models
{
    public class Days
    {
        public string day1 { get; set; }
        public string day2 { get; set; }
        public string day3 { get; set; }

        public Days(string d1,string d2,string d3)
        {
            this.day1 = d1;
            this.day2 = d2;
            this.day3 = d3;
        }
    }
}
