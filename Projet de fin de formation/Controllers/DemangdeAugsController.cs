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
    public class DemangdeAugsController : Controller
    {
        private fermeturesSolutionsEntities db = new fermeturesSolutionsEntities();

        // GET: DemangdeAugs
        public ActionResult Index()
        {
            var demangdeAugS = db.DemangdeAugS.Include(d => d.EmployeeTable);
            return View(demangdeAugS.ToList());
        }

        // GET: DemangdeAugs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DemangdeAug demangdeAug = db.DemangdeAugS.Find(id);
            if (demangdeAug == null)
            {
                return HttpNotFound();
            }
            return View(demangdeAug);
        }

        // GET: DemangdeAugs/Create
        public ActionResult Create()
        {
            ViewBag.IdEmp = new SelectList(db.EmployeeTables, "IdEmp", "PrenomEmp");
            return View();
        }

        // POST: DemangdeAugs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdDemande,IdEmp,etat")] DemangdeAug demangdeAug)
        {
            if (ModelState.IsValid)
            {
                db.DemangdeAugS.Add(demangdeAug);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdEmp = new SelectList(db.EmployeeTables, "IdEmp", "PrenomEmp", demangdeAug.IdEmp);
            return View(demangdeAug);
        }

        // GET: DemangdeAugs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DemangdeAug demangdeAug = db.DemangdeAugS.Find(id);
            if (demangdeAug == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdEmp = new SelectList(db.EmployeeTables, "IdEmp", "PrenomEmp", demangdeAug.IdEmp);
            return View(demangdeAug);
        }

        // POST: DemangdeAugs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdDemande,IdEmp,etat")] DemangdeAug demangdeAug)
        {
            if (ModelState.IsValid)
            {
                db.Entry(demangdeAug).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdEmp = new SelectList(db.EmployeeTables, "IdEmp", "PrenomEmp", demangdeAug.IdEmp);
            return View(demangdeAug);
        }

        // GET: DemangdeAugs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DemangdeAug demangdeAug = db.DemangdeAugS.Find(id);
            if (demangdeAug == null)
            {
                return HttpNotFound();
            }
            return View(demangdeAug);
        }

        // POST: DemangdeAugs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DemangdeAug demangdeAug = db.DemangdeAugS.Find(id);
            db.DemangdeAugS.Remove(demangdeAug);
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
