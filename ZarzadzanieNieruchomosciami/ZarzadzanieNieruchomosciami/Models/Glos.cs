using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ZarzadzanieNieruchomosciami.Models
{
    public class Glos
    {
        [Key]
        public int GlosId { get; set; }
        public int GlosowanieId { get; set; }

        public DateTime DataOddaniaGlosu { get; set; }

        public Odpowiedz Odpowiedz1 { get; set; }
        public Odpowiedz Odpowiedz2 { get; set; }
        public Odpowiedz Odpowiedz3 { get; set; }
        public Odpowiedz Odpowiedz4 { get; set; }
        public Odpowiedz Odpowiedz5 { get; set; }
        public Odpowiedz Odpowiedz6 { get; set; }
        public Odpowiedz Odpowiedz7 { get; set; }
        public Odpowiedz Odpowiedz8 { get; set; }
        public Odpowiedz Odpowiedz9 { get; set; }
        public Odpowiedz Odpowiedz10 { get; set; }

        public virtual Glosowanie Glosowanie { get; set; }
    }

    public enum Odpowiedz
    {
        Tak,
        Nie,
        Wstrzymany,
    }
}