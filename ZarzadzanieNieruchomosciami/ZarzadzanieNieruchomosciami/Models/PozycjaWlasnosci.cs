using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ZarzadzanieNieruchomosciami.Models
{
    public class PozycjaWlasnosci
    {
        public int PozycjaWlasnosciId { get; set; }
        public int WlasnoscID { get; set; }
        public int LokalId { get; set; }
        public int LiczbaWlascicieli { get; set; }
        public string Komentarz { get; set; }

        public virtual LokalMieszkalny lokal { get; set; }
       // public virtual Wlasnosc wlasnosc { get; set; }
    }
}