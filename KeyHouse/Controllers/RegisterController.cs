using KeyHouse.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace KeyHouse.Controllers
{
    [Authorize]
    public class RegisterController : Controller
    {
        private readonly KeyHouseEntities db = new KeyHouseEntities();

        [AllowAnonymous]
        // GET: Register
        public ActionResult Register()
        {
           
            List<string> civilitie = new List<string>() { "Madame", "Monsieur", "Mlle" };
            ViewBag.list = civilitie;
            return View();
        }
        [AllowAnonymous]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Register(Register register)
        {
            List<string> civilitie = new List<string>() { "Madame", "Monsieur", "Mlle" };
            ViewBag.list = civilitie;

            if (ModelState.IsValid)
            {

                Uitilsateur utilsateuradd = new Uitilsateur();


                utilsateuradd.civilite = register.sex;
                utilsateuradd.Nom = register.Nom;
                utilsateuradd.Prenom = register.Prenom;

                if (register.Email == register.EmailCOnfi)
                {
                    utilsateuradd.Email = register.Email;
                }
                utilsateuradd.Telephone = register.Telephone;
                utilsateuradd.Adresse = register.Adresse;



                utilsateuradd.CodePostal = register.Codepostal;

                utilsateuradd.Ville = register.Ville;

                utilsateuradd.Pays = register.Pays;
                utilsateuradd.idRole = 2;


                db.Uitilsateur.Add(utilsateuradd);
                db.SaveChanges();



            }
            return Redirect("~/Login/Login");
            return View(); 
        }



    }
}