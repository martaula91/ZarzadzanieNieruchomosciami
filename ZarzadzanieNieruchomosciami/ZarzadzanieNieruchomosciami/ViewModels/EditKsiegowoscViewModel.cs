using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ZarzadzanieNieruchomosciami.Models;

namespace ZarzadzanieNieruchomosciami.ViewModels
{
    public class EditKsiegowoscViewModel
    {
        public Ksiegowosc Ksiegowosc { get; set; }
        public IEnumerable<LokalMieszkalny> LokalMieszkalny { get; set; }
        public bool? Potwierdzenie { get; set; }
    }
}