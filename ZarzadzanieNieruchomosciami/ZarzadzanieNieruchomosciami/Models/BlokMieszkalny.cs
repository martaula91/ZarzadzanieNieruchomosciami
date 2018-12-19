using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ZarzadzanieNieruchomosciami.Models
{
    public class BlokMieszkalny
    {
        
        public int BlokMieszkalnyId { get; set; }
        

        public string Ulica { get; set; }
        public int NumerBlokuMieszkalnego { get; set; }
        public string Adres { get; set; }
        public double PowierzchniaUzytkowa { get; set; }
        public int LiczbaLokali { get; set; }
        public double PowDzialki { get; set; }
        public int NrEwidDzialki { get; set; }

        public virtual ICollection<LokalMieszkalny> Lokal { get; set; }
        public virtual ICollection<Dokument> Dokument { get; set; }


    }
}