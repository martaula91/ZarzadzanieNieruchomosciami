using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ZarzadzanieNieruchomosciami.Models
{
    public class Glosowanie
    {
        public Glosowanie()
        {
            Pytania = new List<Pytanie>();
        }

        [Key]
        public int GlosowanieId { get; set; }
        public int BlokMieszkalnyId { get; set; }
        public string NumerUchwaly { get; set; }
        public string Nazwa { get; set; }
        public DateTime DataUtworzeniaGlosowania { get; set; }
        public DateTime DataKoncaGlosowania { get; set; }

        public virtual BlokMieszkalny BlokMieszkalny { get; set; }
        public virtual ICollection<Pytanie> Pytania { get; set; }
    }
}