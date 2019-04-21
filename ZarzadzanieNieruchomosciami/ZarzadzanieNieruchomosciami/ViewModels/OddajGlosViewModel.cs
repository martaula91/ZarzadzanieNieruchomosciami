using System.Collections.Generic;
using ZarzadzanieNieruchomosciami.Models;
using ZarzadzanieNieruchomosciami.Models.Enums;

namespace ZarzadzanieNieruchomosciami.ViewModels
{
    public class OddajGlosViewModel
    {
        public OddajGlosViewModel()
        {
            Pytania = new List<PytanieViewModel>();
        }

        public string NumerUchwaly { get; set; }
        public string Nazwa { get; set; }
        public List<PytanieViewModel> Pytania { get; set; }
    }

    public class PytanieViewModel
    {
        public int PytanieId { get; set; }
        public string TrescPytania { get; set; }
        public EnumOdpowiedz Odpowiedz { get; set; }
    }

}