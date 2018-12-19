using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ZarzadzanieNieruchomosciami.Models
{
    public class Dzial
    {
        [Key]
        public int KatID { get; set; }
        public string NazwaKat { get; set; }

        //public virtual ICollection<BlokMieszkalny> BlokMieszkalny { get; set; }
        //public virtual ICollection<Dokument> Dokument { get; set; }
        //public virtual ICollection<LokalMieszkalny> LokalMieszkalny { get; set; }
        
    }
}