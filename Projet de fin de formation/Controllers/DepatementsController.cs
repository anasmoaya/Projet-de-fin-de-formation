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
    public class DepatementsController : Controller
    {
        private fermeturesSolutionsEntities db = new fermeturesSolutionsEntities();

        // GET: Depatements
        public ActionResult Index()
        {
            return View(db.Depatements.ToList());
        }

        // GET: Depatements/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Depatement depatement = db.Depatements.Find(id);
            if (depatement == null)
            {
                return HttpNotFound();
            }
            return View(depatement);
        }

        // GET: Depatements/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Depatements/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idDepartement,nomDepartement")] Depatement depatement)
        {
            if (ModelState.IsValid)
            {
                db.Depatements.Add(depatement);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(depatement);
        }

        // GET: Depatements/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Depatement depatement = db.Depatements.Find(id);
            if (depatement == null)
            {
                return HttpNotFound();
            }
            return View(depatement);
        }

        // POST: Depatements/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idDepartement,nomDepartement")] Depatement depatement)
        {
            if (ModelState.IsValid)
            {
                db.Entry(depatement).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(depatement);
        }

        // GET: Depatements/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Depatement depatement = db.Depatements.Find(id);
            if (depatement == null)
            {
                return HttpNotFound();
            }
            return View(depatement);
        }

        // POST: Depatements/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Depatement depatement = db.Depatements.Find(id);
            db.Depatements.Remove(depatement);
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
