using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ZarzadzanieNieruchomosciami.Models;

namespace ZarzadzanieNieruchomosciami.ViewModels
{
    public class EditLokalViewModel
    {
        public LokalMieszkalny Lokal { get; set; }
       // public IEnumerable<AspNetUsers> DaneUsera { get; set; }
         public IEnumerable<BlokMieszkalny> BlokiMieszkalne { get; set; }
        public bool? Potwierdzenie { get; set; }
    }
}