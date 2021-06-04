using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Projet_de_fin_de_formation;

namespace Projet_de_fin_de_formation.Controllers
{
    public class UserTablesController : Controller
    {
        private fermeturesSolutionsEntities db = new fermeturesSolutionsEntities();

        // GET: UserTables
        public ActionResult Index()
        {
            var userTables = db.UserTables.Include(u => u.EmployeeTable);
            return View(userTables.ToList());
        }

        // GET: UserTables/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserTable userTable = db.UserTables.Find(id);
            if (userTable == null)
            {
                return HttpNotFound();
            }
            return View(userTable);
        }

        // GET: UserTables/Create
        public ActionResult Create()
        {
            ViewBag.IdEmp = new SelectList(db.EmployeeTables, "IdEmp", "PrenomEmp");
            return View();
        }

        // POST: UserTables/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdEmp,Pseudo,password,Admin")] UserTable userTable)
        {
            if (ModelState.IsValid)
            {
                db.UserTables.Add(userTable);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdEmp = new SelectList(db.EmployeeTables, "IdEmp", "PrenomEmp", userTable.IdEmp);
            return View(userTable);
        }

        // GET: UserTables/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserTable userTable = db.UserTables.Find(id);
            if (userTable == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdEmp = new SelectList(db.EmployeeTables, "IdEmp", "PrenomEmp", userTable.IdEmp);
            return View(userTable);
        }

        // POST: UserTables/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdEmp,Pseudo,password,Admin")] UserTable userTable)
        {
            if (ModelState.IsValid)
            {
                db.Entry(userTable).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdEmp = new SelectList(db.EmployeeTables, "IdEmp", "PrenomEmp", userTable.IdEmp);
            return View(userTable);
        }

        // GET: UserTables/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserTable userTable = db.UserTables.Find(id);
            if (userTable == null)
            {
                return HttpNotFound();
            }
            return View(userTable);
        }

        // POST: UserTables/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            UserTable userTable = db.UserTables.Find(id);
            db.UserTables.Remove(userTable);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Verifier(UserTable user)
        {
            UserTable utilisateur = db.UserTables.Where(m => (m.password == user.password && m.Pseudo == user.Pseudo)).FirstOrDefault();




            if (utilisateur != null)
            {
                Session["TypedeLogin"] = "Employé";
                Session["IdEmploye"] = utilisateur.IdEmp;
                Session["Admin"] = utilisateur.Admin;
                List<DemangdeAug> demande_salaire = db.DemangdeAugS.Where(m => m.IdEmp == utilisateur.IdEmp).ToList();
                Constantes.IdUtilisateurEmploy = utilisateur.IdEmp;
                Constantes.isAdmin= utilisateur.Admin;
                Constantes.typeLogin = "Employe";
                Constantes.user = utilisateur;
                if (utilisateur.Admin)
                    return RedirectToAction("Index", "EmployeeTables");
                else
                    return RedirectToAction("IndexEmploye", "EmployeeTables",utilisateur);
            }
            else
            {
               // user.LoginErrorMessage = "Mot de passe ou nom d'utilisateur icorrectes";
                return RedirectToAction("Login", "Login");


            }


        }
       
        
        public ActionResult Deconnexion()
        {
            Session.Abandon();
            return RedirectToAction("Login", "Login");
        }


        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
