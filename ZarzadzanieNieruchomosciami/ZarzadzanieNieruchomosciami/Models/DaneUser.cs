using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ZarzadzanieNieruchomosciami.Models
{
    public class DaneUser   ///AspNetUsers
    {
        //[Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        // This Id is equal to the Id in the AspNetUser table and it's manually set.
        //public override int Id { get; set; }
       public int UzytkownikId { get; set; }
        public int KategoriaId { get; set; }
        public int LokalId { get; set; }


        public string Imie { get; set; }
        public string Nazwisko { get; set; }
        public string Adres { get; set; }
        public string Miasto { get; set; }
        public string KodPocztowy { get; set; }

        [RegularExpression(@"(\+\d{2})*[\d\s-]+", ErrorMessage = "Błędny format numeru telefonu.")]
        public string Telefon { get; set; }

        [EmailAddress(ErrorMessage = "Błędny format adresu e-mail.")]
        public string Email { get; set; }

        // public virtual ICollection<LokalMieszkalny> LokalMieszkalny{ get; set; }

        //public virtual Kategoria Kategoria { get; set; }

            /// <summary>
            /// podejscie 2
            /// </summary>
       // public List<Wlasnosc> PozycjeWlasnosci { get; set; }
    }


}