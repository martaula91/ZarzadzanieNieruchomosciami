using System.Collections.Generic;
using ZarzadzanieNieruchomosciami.Models;

namespace ZarzadzanieNieruchomosciami.ViewModels
{
    public class EditGlosowanieViewModel
    {
        public EditGlosowanieViewModel()
        {
            Pytania = new List<PytanieViewModel>();
        }

        public Glosowanie Glosowanie { get; set; }
        public IEnumerable<BlokMieszkalny> BlokiMieszkalne { get; set; }
        public bool? Potwierdzenie { get; set; }
        public List<PytanieViewModel> Pytania { get; set; }
    }
}