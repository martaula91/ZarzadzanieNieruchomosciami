using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ZarzadzanieNieruchomosciami.Models
{
    public class Glosowanie
    {
        [Key]
        public int GlosowanieId { get; set; }
        public int BlokMieszkalnyId { get; set; }

        public string NumerUchwaly { get; set; }
        public string Nazwa { get; set; }
        
        //public List<Pytanie> Pytania { get; set; }
        public virtual ICollection<Pytanie> Pytanie { get; set; }
        public virtual BlokMieszkalny BlokMieszkalny { get; set; }

    }
}