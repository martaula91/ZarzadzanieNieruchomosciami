using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ZarzadzanieNieruchomosciami.Models;

namespace ZarzadzanieNieruchomosciami.ViewModels
{
    public class EditBudynekViewModel
    {
        public BlokMieszkalny Budynek { get; set; }
        // public IEnumerable<LokalMieszkalny> Lokale { get; set; }
        public bool? Potwierdzenie { get; set; }
    }
}