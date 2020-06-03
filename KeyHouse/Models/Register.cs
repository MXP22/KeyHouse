using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace KeyHouse.Models
{
    public class Register
    {
        [Display(Name = "Civilité:")]
        public string sex { get; set; }

        public string Nom { get; set; }

        public string Prenom { get; set; }

        [Required(ErrorMessage ="Enter votre E-Mail")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Enter votre E-Mail")]
        [Compare(nameof(Email),ErrorMessage ="Pas les memes")]
        public string EmailCOnfi { get; set; }

       
        public string Telephone { get; set; }

        public string Adresse { get; set; }

        public string Codepostal { get; set; }

        public string Ville { get; set; }

        public string Pays { get; set; }

        [Display(Name = "Mot de passe")]
        public string MotdePasse { get; set; }
        [Display(Name = "Confirmation de mot de passe:")]
        public string MotdePasseconfer { get; set; }







    }


}