using System.Collections.Generic;
using ZarzadzanieNieruchomosciami.Models.Enums;

namespace ZarzadzanieNieruchomosciami.ViewModels
{
    public class WynikGlosowaniaViewModel
    {
        public WynikGlosowaniaViewModel()
        {
            Pytania = new List<PytanieWynikiViewModel>();
        }

        public string NumerUchwaly { get; set; }
        public string Nazwa { get; set; }
        public List<PytanieWynikiViewModel> Pytania { get; set; }
    }

    public class PytanieWynikiViewModel
    {
        public PytanieWynikiViewModel()
        {
            Odpowiedzi = new Dictionary<string, int>();
        }

        public int PytanieId { get; set; }
        public string TrescPytania { get; set; }
        public Dictionary<string, int> Odpowiedzi { get; set; }
    }
}