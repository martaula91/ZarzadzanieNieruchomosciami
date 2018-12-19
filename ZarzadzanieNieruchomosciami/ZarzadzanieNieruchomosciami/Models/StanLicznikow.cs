using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ZarzadzanieNieruchomosciami.Models
{
    public class StanLicznikow
    {
        public int StanLicznikowID { get; set; }
        public int LokalMieszkalnyID { get; set; }

        public int WodaZimna { get; set; }
        public int WodaCiepla { get; set; }
        public int EnergiaElektryczna { get; set; }
        public int Gaz { get; set; }

        public DateTime StanNaDzien { get; set; }

        public virtual LokalMieszkalny LokalMieszkalny { get; set; }
    }
}