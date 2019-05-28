using System.Collections.Generic;
using ZarzadzanieNieruchomosciami.Models;

namespace ZarzadzanieNieruchomosciami.ViewModels
{
    public class StatystykaViewModel
    {
        public StatystykaViewModel()
        {
            Awarie = new List<AwariaGroupedModel>();
            AwarieLokal = new List<AwariaLokalGroupedModel>();
        }

        public List<AwariaGroupedModel> Awarie { get; set; }
        public List<AwariaLokalGroupedModel> AwarieLokal { get; set; }
    }

    public class AwariaLokalGroupedModel
    {
        public AwariaLokalGroupedModel()
        {
            Typ = new List<Typ>();
        }

        public string Lokal { get; set; }
        public List<Typ> Typ { get; set; }
    }

    public class AwariaGroupedModel
    {
        public Status Status { get; set; }
        public int Liczba { get; set; }
    }
}