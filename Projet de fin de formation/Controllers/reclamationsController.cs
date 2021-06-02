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
    public class reclamationsController : Controller
    {
        private fermeturesSolutionsEntities db = new fermeturesSolutionsEntities();

        // GET: reclamations
        public ActionResult Index()
        {
            var reclamations = db.reclamations.Include(r => r.Chantier).Include(r => r.Client);
            return View(reclamations.ToList());
        }

        // GET: reclamations/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            reclamation reclamation = db.reclamations.Find(id);
            if (reclamation == null)
            {
                return HttpNotFound();
            }
            return View(reclamation);
        }

        // GET: reclamations/Create
        public ActionResult Create()
        {
            ViewBag.idChantier = new SelectList(db.Chantiers, "IdChantier", "NomChantier");
            ViewBag.idClient = new SelectList(db.Clients, "idClient", "NomClient");
            return View();
        }

        // POST: reclamations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idReclamation,idClient,idChantier,dateRec,Remarque")] reclamation reclamation)
        {
            if (ModelState.IsValid)
            {
                db.reclamations.Add(reclamation);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idChantier = new SelectList(db.Chantiers, "IdChantier", "NomChantier", reclamation.idChantier);
            ViewBag.idClient = new SelectList(db.Clients, "idClient", "NomClient", reclamation.idClient);
            return View(reclamation);
        }

        // GET: reclamations/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            reclamation reclamation = db.reclamations.Find(id);
            if (reclamation == null)
            {
                return HttpNotFound();
            }
            ViewBag.idChantier = new SelectList(db.Chantiers, "IdChantier", "NomChantier", reclamation.idChantier);
            ViewBag.idClient = new SelectList(db.Clients, "idClient", "NomClient", reclamation.idClient);
            return View(reclamation);
        }

        // POST: reclamations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idReclamation,idClient,idChantier,dateRec,Remarque")] reclamation reclamation)
        {
            if (ModelState.IsValid)
            {
                db.Entry(reclamation).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idChantier = new SelectList(db.Chantiers, "IdChantier", "NomChantier", reclamation.idChantier);
            ViewBag.idClient = new SelectList(db.Clients, "idClient", "NomClient", reclamation.idClient);
            return View(reclamation);
        }

        // GET: reclamations/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            reclamation reclamation = db.reclamations.Find(id);
            if (reclamation == null)
            {
                return HttpNotFound();
            }
            return View(reclamation);
        }

        // POST: reclamations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            reclamation reclamation = db.reclamations.Find(id);
            db.reclamations.Remove(reclamation);
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
    }
}
