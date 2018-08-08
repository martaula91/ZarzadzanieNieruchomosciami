using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ZarzadzanieNieruchomosciami.Models
{
    public class Kategoria
    {
        public int KategoriaId { get; set; }
        public string nazwaKategori { get; set; }

        public virtual ICollection<BlokMieszkalny> BlokMieszkalny { get; set; }
        public virtual ICollection<Dokument> Dokument { get; set; }
        public virtual ICollection<LokalMieszkalny> LokalMieszkalny { get; set; }
        public virtual ICollection<DaneUzytkownika> DaneUzytkownika { get; set; }
    }
}