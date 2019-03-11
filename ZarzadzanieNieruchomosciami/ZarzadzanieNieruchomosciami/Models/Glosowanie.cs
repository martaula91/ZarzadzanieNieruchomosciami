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
        public DateTime DataUtworzeniaGlosowania { get; set; }
        public DateTime DataKoncaGlosowania { get; set; }


        public string Pytanie1 { get; set; }
        public string Pytanie2 { get; set; }
        public string Pytanie3 { get; set; }
        public string Pytanie4 { get; set; }
        public string Pytanie5 { get; set; }
        public string Pytanie6 { get; set; }
        public string Pytanie7 { get; set; }
        public string Pytanie8 { get; set; }
        public string Pytanie9 { get; set; }
        public string Pytanie10 { get; set; }


        //public List<Pytanie> Pytania { get; set; }
        public virtual ICollection<Pytanie> Pytanie { get; set; }
        public virtual ICollection<Glos> Glos { get; set; }
        public virtual BlokMieszkalny BlokMieszkalny { get; set; }

    }
}