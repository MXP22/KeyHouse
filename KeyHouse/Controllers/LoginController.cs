using KeyHouse.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace KeyHouse.Controllers
{
    public class LoginController : Controller
    {
        private readonly KeyHouseEntities db = new KeyHouseEntities();



        // GET: Login
        public ActionResult Login()
        {
            Uitilsateur uitilsateur = new Uitilsateur();


            KeyHouse.Models.Login loginuser = new KeyHouse.Models.Login() { Authentifie = HttpContext.User.Identity.IsAuthenticated };

            if (HttpContext.User.Identity.IsAuthenticated)
            {
                loginuser.Loginapp = HttpContext.User.Identity.Name;


            }
            else
            {



            }

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(KeyHouse.Models.Login login, string returnurl)
        {
            Uitilsateur user = new Uitilsateur();
            if (ModelState.IsValid)
            {

                 

                if (usera != null)
                {

                    FormsAuthentication.SetAuthCookie(user.idUtilisateur.ToString(), false);
                    if (!string.IsNullOrEmpty(returnurl) && Url.IsLocalUrl(returnurl))
                    {
                        return Redirect(returnurl);
                       
                    }

                    ModelState.AddModelError(usera.Email, "Utilisateur incorrecte");
                }

            }

            return View(login);

        }

    }
}