using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ZarzadzanieNieruchomosciami.Models
{
    public class BlokMieszkalny
    {
        [Key]
        public int BlokMieszkalnyId { get; set; }
        public string Ulica { get; set; }
        public int NumerBlokuMieszkalnego { get; set; } 
        public int PowierzchniaUzytkowa { get; set; }
        public int LiczbaLokali { get; set; }
        public int PowDzialki { get; set; }
        public int NrEwidDzialki { get; set; }

        //public virtual LokalMieszkalny lokalMieszkalny { get; set; }
       
        // public List<LokalMieszkalny> LokaleMieszkalne { get; set; }
        //public List<Dokument> Dokumenty { get; set; }
    }
}