using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ZarzadzanieNieruchomosciami.Models;

namespace ZarzadzanieNieruchomosciami.ViewModels
{
    public class ListaViewModel
    {
        public IEnumerable<Kategoria> Kategorie { get; set; }
        public IEnumerable<BlokMieszkalny> BlokiMieszkalne { get; set; }
        public IEnumerable<LokalMieszkalny> LokaleMieszkalne { get; set; }
    }
}