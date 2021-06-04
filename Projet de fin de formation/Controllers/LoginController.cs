using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Web.Mvc;


namespace Projet_de_fin_de_formation.Controllers

{
    public class LoginController : Controller
    {
        // GET: Login


        public ActionResult Login()
        {

            return View();
        }
     
        [HttpPost]
        public ActionResult Verify(string pseudo,string mdp)
        {
            //if (!string.IsNullOrEmpty(pseudo) && string.IsNullOrEmpty(pseudo))
            //{
            //    return RedirectToAction("Dashboard");
            //}
            //ClaimsIdentity identity = null;
            //try
            //{
            //    utilisateur u = us.utilisateurs.Where(e => (e.idUtilisateur == pseudo && e.mdp == mdp)).First();
            //    if(u.typeu == "Administrateur")
            //    {
            //        identity = new ClaimsIdentity(new[]
            //        {
            //            new Claim(ClaimTypes.Name,u.typeu),
            //            new Claim(ClaimTypes.Role,"Administrateur")
            //        }, CookieAuthenticationDefaults.AuthenticationScheme);
                    

            //    }
            //   else if (u.typeu == "Super Administrateur")
            //    {
            //        identity = new ClaimsIdentity(new[]
            //        {
            //            new Claim(ClaimTypes.Name,u.typeu),
            //            new Claim(ClaimTypes.Role,"Super Administrateur")
            //        }, CookieAuthenticationDefaults.AuthenticationScheme);
                    
            //    }
            //    else if (u.typeu == "Employe")
            //    {
            //        identity = new ClaimsIdentity(new[]
            //        {
            //            new Claim(ClaimTypes.Name,u.typeu),
            //            new Claim(ClaimTypes.Role,"Employe")
            //        }, CookieAuthenticationDefaults.AuthenticationScheme);
            //        ;
            //    }
                return RedirectToAction("Index", "EmployeeTables");


            //}
            //catch (Exception exep)
            //{
            //    return RedirectToAction("Dashboard");
            //}
           
        }
        public ActionResult Dashboard()
        {
            return View();
        }
    }
}