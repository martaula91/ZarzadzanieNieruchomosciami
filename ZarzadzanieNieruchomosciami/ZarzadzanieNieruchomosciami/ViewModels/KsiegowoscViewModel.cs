using System.Collections.Generic;
using ZarzadzanieNieruchomosciami.Models;

namespace ZarzadzanieNieruchomosciami.ViewModels
{
    public class KsiegowoscViewModel
    {
        public KsiegowoscViewModel()
        {
            Documents = new List<Ksiegowosc>();
        }

        public bool IsInUserRole { get; set; }
        public double Saldo { get; set; }
        public List<Ksiegowosc> Documents { get; set; }
    }
}