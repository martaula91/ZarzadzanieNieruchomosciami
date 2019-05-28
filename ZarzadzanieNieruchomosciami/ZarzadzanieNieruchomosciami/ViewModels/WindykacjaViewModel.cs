using System.Collections.Generic;

namespace ZarzadzanieNieruchomosciami.ViewModels
{
    public class WindykacjaViewModel
    {
        public WindykacjaViewModel()
        {
            WindykacjaItems = new List<WindykacjaItem>();
        }

        public List<WindykacjaItem> WindykacjaItems { get; set; }
    }

    public class WindykacjaItem
    {
        public string LocalAddress { get; set; }
        public string FullName { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public double Saldo { get; set; }
    }
}