using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace KeyHouse.Models
{
    public class Login
    {
        [Required]
        [Display(Name="Identifiant :")]
        public string Loginapp { get; set; }
        [Display(Name ="Mot de passe :")]
        [DataType(DataType.Password)]
        [Required]
        public string Motdepasse { get; set; }

        public bool Remomber { get; set; }

        public bool Authentifie { get; set; }

    }
}