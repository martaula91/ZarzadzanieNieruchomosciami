using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ZarzadzanieNieruchomosciami.Models
{
    public class Wlasnosc           //
    {
        public int WlasnoscId { get; set; }
        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }

        public string Komentarz { get; set; } 

        /// <summary>
        /// podejscie nr2
        /// </summary>
        //public List<PozycjaWlasnosci> PozycjeWlasnosci { get; set; }

        public virtual LokalMieszkalny lokal { get; set; }
        public virtual DaneUser user { get; set; }
    }
}