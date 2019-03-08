using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ZarzadzanieNieruchomosciami.Models
{
    public class Pytanie
    {
        [Key]

        public int PytanieId { get; set; }
        public int GlosowanieId { get; set; }

        public string TrescPytania { get; set; }
        //public string Odpowiedz { get; set; }
        public Odpowiedz Odpowiedz { get; set; }

        public virtual Glosowanie Glosowanie { get; set; }


    }
    public enum Odpowiedz
    {
        Tak,
        Nie,
        Wstrzymany,
    }

}