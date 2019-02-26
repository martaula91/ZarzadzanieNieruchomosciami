using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ZarzadzanieNieruchomosciami.Models
{
    public class LokalMieszkalny
    {
        [Key]
        public int LokalID { get; set; }
        public int BlokMieszkalnyID { get; set; }
        //public string UserID { get; set; }
        //public virtual ApplicationUser User { get; set; }

        public string Adres { get; set; }
        //  [Required(ErrorMessage = "Wprowadz numer lokalu")]
        public int NumerLokalu { get; set; }
        //  [Required(ErrorMessage = "Wprowadz powierzchnie lokalu")]
        public double PowierzchniaLokalu { get; set; }
        //  [Required(ErrorMessage = "Wprowadz liczbe izb lokalu")]
        public int LiczbaIzb { get; set; }
        //  [Required(ErrorMessage = "Wprowadz powierzchnie piwnicy przynaleznej do lokalu")]
        public double PowPiwnicy { get; set; }
        //  [Required(ErrorMessage = "Wprowadz pietro")]
        public int Pietro { get; set; }
        public bool Ukryty { get; set; }

        //DO ROZLICZEN
        public int LiczbaLokatorow { get; set; }
        public double LiczbaWodyZimnej { get; set; }
        public double LiczbaWodyCieplej { get; set; }

        public virtual BlokMieszkalny BlokMieszkalny { get; set; }
        public virtual ICollection<StanLicznikow> StanLicznikow { get; set; }
        public virtual ICollection<Ksiegowosc> Ksiegowosc { get; set; }
        public virtual ICollection<Rozliczenie> Rozliczenie { get; set; }

        //public Balkon Balkon { get; set; }
    }

    public enum Balkon
    {
        loggia,
        tak,
        nie
    }
}