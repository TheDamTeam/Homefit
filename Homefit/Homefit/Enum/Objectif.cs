using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace Homefit.Enum
{
    public enum Objectif 
    {

        [Display(Description = "Perte de poids")]
        One = 1,
        [Display(Description = "Prise de masse")]
        Two = 2,
        [Display(Description = "Remise en forme")]
        Three = 3,
        [Display(Description = "Amélioration performance")]
        Four = 4   
    }
}
