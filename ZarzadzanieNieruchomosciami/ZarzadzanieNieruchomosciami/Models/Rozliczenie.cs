using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ZarzadzanieNieruchomosciami.Models
{
    public class Rozliczenie
    {
        [Key]
        public int RozliczenieId { get; set; }
        //public int KategoriaId { get; set; }
        public int StawkaID { get; set; }
        public int LokalID { get; set; }


        public string Nazwa { get; set; }

        public double CentralneOgrzewanie { get; set; }
        public double ZWiSCLicznik { get; set; }
        public double CWLicznik { get; set; }
        public double EnergiaElekCzescWspolna { get; set; }
        public double WywozSmieci { get; set; }
        public double KosztyAdministrowania { get; set; }
        public double KosztyObslugiBankUbezp { get; set; }
        public double FunduszRemontowy { get; set; }


        public double StanObecny { get; set; }
        public double OgolemDoZaplaty { get; set; }
        public DateTime StanNaDzien { get; set; }

        public virtual Stawka Stawka { get; set; }
        public virtual LokalMieszkalny Lokal { get; set; }
    }
}