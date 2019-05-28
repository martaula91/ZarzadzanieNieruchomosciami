using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ZarzadzanieNieruchomosciami.Models;

namespace ZarzadzanieNieruchomosciami.ViewModels
{
    public class EditRozliczenieViewModel
    {
        public Rozliczenie Rozliczenie { get; set; }
       public IEnumerable<LokalMieszkalny> LokalMieszkalny { get; set; }
        public IEnumerable<Stawka> Stawka { get; set; }
        public bool? Potwierdzenie { get; set; }
    }
}