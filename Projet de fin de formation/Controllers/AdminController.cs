using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNetCore.Mvc;

namespace Projet_de_fin_de_formation.Controllers
{
    public class AdminController : System.Web.Mvc.Controller
    {


        
        // GET: Admin
        public System.Web.Mvc.ActionResult Index()
        {
            return View();
        }
    }
}

   