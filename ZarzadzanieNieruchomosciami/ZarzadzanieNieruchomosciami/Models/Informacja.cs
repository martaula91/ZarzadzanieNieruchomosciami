using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ZarzadzanieNieruchomosciami.Models
{
    public class Informacja
    {

        [Key]
        public int InformacjaID { get; set; }
        //public int BlokMieszkalnyId { get; set; }

        public string Tytul { get; set; }
        public string Wstep { get; set; }
        public string Tresc { get; set; }
        public DateTime DataDodania { get; set; }
        public bool Ukryty { get; set; }


        //public virtual BlokMieszkalny BlokMieszkalny { get; set; }
    }
}