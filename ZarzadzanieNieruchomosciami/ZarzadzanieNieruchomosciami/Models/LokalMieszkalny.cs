using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ZarzadzanieNieruchomosciami.Models
{
    public class LokalMieszkalny
    {
        [Key]
        public int LokalId { get; set; }
        //public int BlokMieszkalnyId { get; set; }

      //  [Required(ErrorMessage = "Wprowadz numer lokalu")]
     //   [StringLength(100)]
       // public int NumerLokalu { get; set; }
        public float PowierzchniaLokalu { get; set; }
        public int LiczbaIzb { get; set; }
        public float PowPiwnicy { get; set; }
        public int Pietro { get; set; }
        public Balkon Balkon { get; set; }

        //Liczniki
        public int WodaZimna { get; set; }
        public int WodaCiepla { get; set; }
        public int EnergiaElektryczna { get; set; }
        public int Gaz { get; set; }

                        
       // public virtual BlokMieszkalny BlokMieszkalny { get; set; }
    }

    public enum Balkon
    {
        loggia,
        tak,
        nie
    }
}