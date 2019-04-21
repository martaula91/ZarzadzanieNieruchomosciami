using System;
using System.ComponentModel.DataAnnotations;
using ZarzadzanieNieruchomosciami.Models.Enums;

namespace ZarzadzanieNieruchomosciami.Models
{
    public class Glos
    {
        [Key]
        public int GlosId { get; set; }
        public int PytanieId { get; set; }
        public string UserId { get; set; }
        public EnumOdpowiedz Odpowiedz { get; set; }
        public DateTime DataOddaniaGlosu { get; set; }

        public virtual Pytanie Pytanie { get; set; }
        public virtual ApplicationUser User { get; set; }
    }
}