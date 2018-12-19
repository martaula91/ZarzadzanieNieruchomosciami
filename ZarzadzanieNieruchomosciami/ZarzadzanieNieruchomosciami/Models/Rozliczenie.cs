using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ZarzadzanieNieruchomosciami.Models
{
    public class Rozliczenie
    {
        public int RozliczenieId { get; set; }
        //public int KategoriaId { get; set; }


        public int CentralneOgrzewanie { get; set; }
        public int StawkaCentralneOgrzewanie { get; set; }

        public int ZWiSCLicznik { get; set; }
        public int StawkaZWiSC { get; set; }

        public int CWLicznik { get; set; }
        public int StawkaCW { get; set; }

        public int EnergiaElekCzescWspolna { get; set; }
        public int StawkaEnergiaElekCzescWspolna { get; set; }

        public int WywozSmieci { get; set; }
        public int StawkaWywozSmieci { get; set; }

        public int KosztyAdministrowania { get; set; }
        public int StawkaKosztyAdministrowania { get; set; }

        public int KosztyObslugiBankUbezp { get; set; }
        public int StawkaKosztyObslugiBankUbezp { get; set; }

        public int FunduszRemontowy { get; set; }
        public int StawkaFunduszRemontowy { get; set; }

        public int StanObecny { get; set; }
        public int OgolemDoZaplaty { get; set; }
    }
}