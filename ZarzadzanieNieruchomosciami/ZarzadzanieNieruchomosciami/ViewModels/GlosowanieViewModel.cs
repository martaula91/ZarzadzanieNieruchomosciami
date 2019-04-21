using System;
using System.Collections.Generic;

namespace ZarzadzanieNieruchomosciami.ViewModels
{
    public class GlosowanieViewModel
    {
        public GlosowanieViewModel()
        {
            Glosowania = new List<GlosowanieExtendedModel>();
        }

        public List<GlosowanieExtendedModel> Glosowania { get; set; }
    }

    public class GlosowanieExtendedModel
    {
        public int GlosowanieId { get; set; }
        public int BlokMieszkalnyId { get; set; }
        public string NumerUchwaly { get; set; }
        public string Nazwa { get; set; }
        public DateTime DataUtworzeniaGlosowania { get; set; }
        public DateTime DataKoncaGlosowania { get; set; }

        public bool CzyMozeUserMozeGlosowac { get; set; }
        public bool CzyZakonczone { get; set; }
    }
}