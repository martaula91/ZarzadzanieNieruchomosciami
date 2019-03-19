using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ZarzadzanieNieruchomosciami.Models;

namespace ZarzadzanieNieruchomosciami.ViewModels
{
    public class OddajGlosViewModel
    {
        //public Glosowanie Glosowanie { get; set; }
        public Glos Glos { get; set; }
        public IEnumerable<Glosowanie> Glosowanie { get; set; }
        public bool? Potwierdzenie { get; set; }
    }
}