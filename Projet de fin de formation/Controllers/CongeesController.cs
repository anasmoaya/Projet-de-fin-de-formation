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
    public class CongeesController : Controller
    {
        private fermeturesSolutionsEntities db = new fermeturesSolutionsEntities();

        // GET: Congees
        public ActionResult Index()
        {
            var congees = db.Congees.Include(c => c.EmployeeTable);
            return View(congees.ToList());
        }

        // GET: Congees/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Congee congee = db.Congees.Find(id);
            if (congee == null)
            {
                return HttpNotFound();
            }
            return View(congee);
        }

        // GET: Congees/Create
        public ActionResult Create()
        {
            ViewBag.IdEmp = new SelectList(db.EmployeeTables, "IdEmp", "PrenomEmp");
            return View();
        }

        // POST: Congees/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "StartDate,EndDate,Reason")] Congee congee)
        {
            Congee cg = db.Congees.Where(m => m.IdEmp == Constantes.user.IdEmp).FirstOrDefault();
            if (cg!=null)
            {
                if (cg.Status == "En cours") return View("~/Views/DemangdeAugs/DemandeDejaEnvoye.cshtml");
                else
                {

                    if (ModelState.IsValid)
                    {

                        congee.IdEmp = Constantes.IdUtilisateurEmploy;
                        congee.Status = "En cours";
                        db.Congees.Add(congee);
                        db.SaveChanges();
                        return RedirectToAction("IndexFiltred");
                    }

                    ViewBag.IdEmp = new SelectList(db.EmployeeTables, "IdEmp", "PrenomEmp", congee.IdEmp);
                    return View(congee);
                }
                
            }
            else
            {

                if (ModelState.IsValid)
                {

                    congee.IdEmp = Constantes.IdUtilisateurEmploy;
                    congee.Status = "En cours";
                    db.Congees.Add(congee);
                    db.SaveChanges();
                    return RedirectToAction("IndexFiltred");
                }

                ViewBag.IdEmp = new SelectList(db.EmployeeTables, "IdEmp", "PrenomEmp", congee.IdEmp);
                return View(congee);
            }

        }

        // GET: Congees/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Congee congee = db.Congees.Find(id);
            if (congee == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdEmp = new SelectList(db.EmployeeTables, "IdEmp", "PrenomEmp", congee.IdEmp);
            return View(congee);
        }

        // POST: Congees/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idConge,IdEmp,StartDate,EndDate,Reason,Status")] Congee congee)
        {
            if (ModelState.IsValid)
            {
                db.Entry(congee).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdEmp = new SelectList(db.EmployeeTables, "IdEmp", "PrenomEmp", congee.IdEmp);
            return View(congee);
        }
        
        public ActionResult Approuver(int id )
        {
            Congee congee = db.Congees.Find(id);
            congee.Status = "Approuvé";
            db.SaveChanges();
            return RedirectToAction("Index");
       
        }

        // GET: Congees/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Congee congee = db.Congees.Find(id);
            if (congee == null)
            {
                return HttpNotFound();
            }
            return View(congee);
        }

        // POST: Congees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Congee congee = db.Congees.Find(id);
            db.Congees.Remove(congee);
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
            List<Congee> Liste_Congees = db.Congees.Where(m => m.IdEmp == Constantes.user.IdEmp).ToList();
            if (Liste_Congees == null)
            {
                return HttpNotFound();
            }else 
            return View(Liste_Congees);
        }
    }
}
