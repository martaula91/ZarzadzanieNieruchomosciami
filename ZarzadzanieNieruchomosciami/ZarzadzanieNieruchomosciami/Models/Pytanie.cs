using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ZarzadzanieNieruchomosciami.Models
{
    public class Pytanie
    {
        public Pytanie()
        {
            Glos = new List<Glos>();
        }

        [Key]
        public int PytanieId { get; set; }
        public int GlosowanieId { get; set; }
        public string TrescPytania { get; set; }

        public virtual Glosowanie Glosowanie { get; set; }
        public virtual ICollection<Glos> Glos { get; set; }
    }
}