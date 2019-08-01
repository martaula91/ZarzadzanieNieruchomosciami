using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ZarzadzanieNieruchomosciami.Models;

namespace ZarzadzanieNieruchomosciami.ViewModels
{
    public class AwarieAdresViewModel
    {
        public IEnumerable<Awaria> Awaria { get; set; }
        public IEnumerable<BlokMieszkalny> Budynek { get; set; }
    }
}