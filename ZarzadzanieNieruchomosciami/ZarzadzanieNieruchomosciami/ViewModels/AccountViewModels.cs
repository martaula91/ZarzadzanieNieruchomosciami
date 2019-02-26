using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ZarzadzanieNieruchomosciami.ViewModels
{
    public class LoginViewModel
    {
        // [Required(ErrorMessage = "Musisz wprowadzić e-mail")]
        //  [EmailAddress]
        // public string Email { get; set; }

        [Required]
        [Display(Name = "UserName")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Musisz wprowadzić hasło")]
        [DataType(DataType.Password)]
        [Display(Name = "Hasło")]
        public string Password { get; set; }

        [Display(Name = "Zapamiętaj mnie")]
        public bool RememberMe { get; set; }
    }

    public class RegisterViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [StringLength(30, ErrorMessage = "{0} musi mieć co najmniej {2} znaków.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = " Hasło ")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Potwierdz Hasło ")]
        [System.ComponentModel.DataAnnotations.Compare("Password", ErrorMessage = "Hasło i potwierdzenie hasła nie pasują do siebie.")]
        public string ConfirmPassword { get; set; }

        [Required]
        [Display(Name = "Rola użytkownika")]
        public string SelectedRoleName { get; set; }

        public List<IdentityRole> AvailableRoles { get; set; }

        [Display(Name = "Lokal")]
        public int SelectedApartmentId { get; set; }

        public List<AvailableApartment> AvailableApartments { get; set; }
    }

    public class AvailableApartment
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
