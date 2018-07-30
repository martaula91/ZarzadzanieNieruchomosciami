using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ZarzadzanieNieruchomosciami.Models
{
    public class Dokument
    {
        [Key]
        public int DokumentID { get; set; }
        public int KategoriaId { get; set; }
        
        public string NazwaDokumentu { get; set; }
        [Required(ErrorMessage = "Wprowadz nazwę dokumentu")]
        [StringLength(100)]
        public string TypDokumentu { get; set; } // zarzadzenie, informacja etc
        public string AutorDokumentu { get; set; } //Zarzad, firma zarzadzajaca, wspolnota, prywatny
       // public DateTime DataDodania { get; set; }
        // [StringLength(100)]
        public string NazwaPlikuDokumentu { get; set; }
        public string OpisDokumentu { get; set; }


        public virtual Kategoria Kategoria { get; set; }
        
    }
}