using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ZarzadzanieNieruchomosciami.Models;

namespace ZarzadzanieNieruchomosciami.ViewModels
{
    public class StartViewModel
    {
       public IEnumerable<Kategoria> Kategoria { get; set; }
        
    }
}