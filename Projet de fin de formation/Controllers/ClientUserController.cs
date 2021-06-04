using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Projet_de_fin_de_formation.Controllers
{
    public class ClientUserController : Controller
    {
        fermeturesSolutionsEntities db = new fermeturesSolutionsEntities();
        // GET: ClientUser
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Verifier(UserClient userClient)
        {

            UserClient user = db.UserClients.Where(m => m.pseudo == userClient.pseudo && m.password == userClient.password).FirstOrDefault();
            if(user == null)
            {
                return RedirectToAction("Index");
            }
            else
            {
                Session["TypedeLogin"] = "Client";
                Session["IdEmploye"] = user.idClient ;
                Constantes.useClientObject = user;
                Constantes.typeLogin = "Employe";
                return RedirectToAction("IndexFiltred", "Chantiers");
            }
        }
       
    }
}