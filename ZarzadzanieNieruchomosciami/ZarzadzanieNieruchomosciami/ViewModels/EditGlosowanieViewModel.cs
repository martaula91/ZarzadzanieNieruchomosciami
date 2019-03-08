using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ZarzadzanieNieruchomosciami.Models;

namespace ZarzadzanieNieruchomosciami.ViewModels
{
    public class EditGlosowanieViewModel
    {
        public Glosowanie Glosowanie { get; set; }
        public IEnumerable<BlokMieszkalny> BlokiMieszkalne { get; set; }
        public bool? Potwierdzenie { get; set; }
    }
}