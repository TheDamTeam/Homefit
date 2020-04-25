using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace Homefit.Enum
{
    public enum Objectif 
    {

        [Display(Description = "Perte de poids")]
        One,
        [Display(Description = "Prise de masse")]
        Two,
        [Display(Description = "Remise en forme")]
        Three,
        [Display(Description = "Amélioration performance")]
        Four   
    }
}
