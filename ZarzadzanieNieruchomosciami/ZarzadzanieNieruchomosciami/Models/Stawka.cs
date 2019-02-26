using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ZarzadzanieNieruchomosciami.Models
{
    public class Stawka
    {
        [Key]
        public int StawkaID { get; set; }

        public string Okres { get; set; }
        public DateTime DataDodania { get; set; }


        public double StawkaCentralneOgrzewanie { get; set; }
        public double StawkaZWiSC { get; set; }
        public double StawkaCW { get; set; }
        public double StawkaEnergiaElekCzescWspolna { get; set; }
        public double StawkaWywozSmieci { get; set; }
        public double StawkaKosztyAdministrowania { get; set; }
        public double StawkaKosztyObslugiBankUbezp { get; set; }
        public double StawkaFunduszRemontowy { get; set; }

        public virtual ICollection<Rozliczenie> Rozliczenie { get; set; }

    }
}