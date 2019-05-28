using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ZarzadzanieNieruchomosciami.Models
{
    public class Ksiegowosc
    {
        [Key]
        public int KsiegowoscID { get; set; }
        public int LokalMieszkalnyID { get; set; }

        public string Nazwa { get; set; } //Naliczenie styczen 2018
        public OpisDokumentu OpisDokumentu { get; set; }
        public DateTime DataDodania { get; set; }

        public double Wartosc { get; set; }

        public virtual LokalMieszkalny LokalMieszkalny { get; set; }

       
    }
    public enum OpisDokumentu
    {
        Naliczenie,
        Wplata,
        Odsetki,
    }
}