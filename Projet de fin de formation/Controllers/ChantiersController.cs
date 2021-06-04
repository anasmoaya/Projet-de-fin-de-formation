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
    public class ChantiersController : Controller
    {
        private fermeturesSolutionsEntities db = new fermeturesSolutionsEntities();

        // GET: Chantiers
        public ActionResult Index()
        {
            var chantiers = db.Chantiers.Include(c => c.EmployeeTable).Include(c => c.Client);
            return View(chantiers.ToList());
        }

        // GET: Chantiers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Chantier chantier = db.Chantiers.Find(id);
            if (chantier == null)
            {
                return HttpNotFound();
            }
            return View(chantier);
        }

        // GET: Chantiers/Create
        public ActionResult Create()
        {
            ViewBag.ChefProj = new SelectList(db.EmployeeTables, "IdEmp", "PrenomEmp");
            ViewBag.IdClient = new SelectList(db.Clients, "idClient", "NomClient");
            return View();
        }

        // POST: Chantiers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdChantier,NomChantier,AdresseChantier,DateDebChantier,DateFinProj,statut,ChefProj,IdClient")] Chantier chantier)
        {
            chantier.statut = "En cours";
            if (ModelState.IsValid)
            {
                db.Chantiers.Add(chantier);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ChefProj = new SelectList(db.EmployeeTables, "IdEmp", "PrenomEmp", chantier.ChefProj);
            ViewBag.IdClient = new SelectList(db.Clients, "idClient", "NomClient", chantier.IdClient);
            return View(chantier);
        }

        // GET: Chantiers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Chantier chantier = db.Chantiers.Find(id);
            if (chantier == null)
            {
                return HttpNotFound();
            }
            ViewBag.ChefProj = new SelectList(db.EmployeeTables, "IdEmp", "PrenomEmp", chantier.ChefProj);
            ViewBag.IdClient = new SelectList(db.Clients, "idClient", "NomClient", chantier.IdClient);
            return View(chantier);
        }

        // POST: Chantiers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdChantier,NomChantier,AdresseChantier,DateDebChantier,DateFinProj,statut,ChefProj,IdClient")] Chantier chantier)
        {
            if (ModelState.IsValid)
            {
                db.Entry(chantier).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ChefProj = new SelectList(db.EmployeeTables, "IdEmp", "PrenomEmp", chantier.ChefProj);
            ViewBag.IdClient = new SelectList(db.Clients, "idClient", "NomClient", chantier.IdClient);
            return View(chantier);
        }

        // GET: Chantiers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Chantier chantier = db.Chantiers.Find(id);
            if (chantier == null)
            {
                return HttpNotFound();
            }
            return View(chantier);
        }
        public ActionResult Terminer(int id)
        {
            Chantier ch = db.Chantiers.Find(id);
            ch.statut = "Terminé";
            ch.DateFinProj = DateTime.Now;
            db.SaveChanges();

            return RedirectToAction("Index");
        }
        [HttpPost]
        public ActionResult Recompenser(Chantier chantier)
        {
            Chantier ch = db.Chantiers.Find(chantier.IdChantier);
            ch.statut = "Terminé";
            ch.DateFinProj = DateTime.Now;
            EmployeeTable employe = db.EmployeeTables.Find(ch.ChefProj);
            employe.pointsEmp += chantier.pointsA.GetValueOrDefault();
            db.SaveChanges();

            return RedirectToAction("Index", "EmployeeTables");
        }
        // POST: Chantiers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Chantier chantier = db.Chantiers.Find(id);
            db.Chantiers.Remove(chantier);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
       
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
        public ActionResult IndexFiltred()
        {

            List<Chantier> chantiers = db.Chantiers.Where(m => m.IdClient == Constantes.useClientObject.idClient).ToList();
            return View(chantiers);

        }
    }
}
