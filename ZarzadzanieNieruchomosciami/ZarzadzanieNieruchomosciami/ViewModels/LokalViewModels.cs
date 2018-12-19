using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ZarzadzanieNieruchomosciami.Models;

namespace ZarzadzanieNieruchomosciami.ViewModels
{
    public class LokalViewModels
    {
        public LokalMieszkalny Lokal { get; set; }
        public IEnumerable<BlokMieszkalny> BlokiMieszkalne { get; set; }
    }
}