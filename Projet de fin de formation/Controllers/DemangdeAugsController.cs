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
         public fermeturesSolutionsEntities db = new fermeturesSolutionsEntities();




      public ActionResult IndexFiltred()
        {
            EmployeeTable emp = db.EmployeeTables.Find(Constantes.IdUtilisateurEmploy);
            return View(db.DemangdeAugS.Where(m=>m.IdEmp == Constantes.IdUtilisateurEmploy));
        }



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


            EmployeeTable em = db.EmployeeTables.Find(Constantes.IdUtilisateurEmploy);
            if(em != null)
            {
                if (em.pointsEmp < 99) return RedirectToAction("NotAllowed");
                else
                {
                    ViewBag.IdEmp = new SelectList(db.EmployeeTables, "IdEmp", "PrenomEmp");
                    return View();
                }
            }
            return View();




        }
        public ActionResult NotAllowed()
        {
            return View();
        }

        // POST: DemangdeAugs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create( DemangdeAug demangdeAug)
        {
            DemangdeAug demande = db.DemangdeAugS.Where(m => m.IdEmp == Constantes.user.IdEmp).FirstOrDefault();

            if (demande != null)
            {
                if (demande.etat == "En cours") return View("~/Views/DemangdeAugs/DemandeDejaEnvoye.cshtml");
                else {
                    demangdeAug.IdEmp = Constantes.IdUtilisateurEmploy;
                    demangdeAug.etat = "En cours";
                    if (ModelState.IsValid)
                    {
                        db.DemangdeAugS.Add(demangdeAug);
                        db.SaveChanges();
                        return RedirectToAction("IndexFiltred");
                    }

                    ViewBag.IdEmp = new SelectList(db.EmployeeTables, "IdEmp", "PrenomEmp", demangdeAug.IdEmp);
                    return RedirectToAction("IndexFiltred");

                }
            }
            else
            {
                demangdeAug.IdEmp = Constantes.IdUtilisateurEmploy;
                demangdeAug.etat = "En cours";
                if (ModelState.IsValid)
                {
                    db.DemangdeAugS.Add(demangdeAug);
                    db.SaveChanges();
                    return RedirectToAction("IndexFiltred");
                }

                ViewBag.IdEmp = new SelectList(db.EmployeeTables, "IdEmp", "PrenomEmp", demangdeAug.IdEmp);
                return RedirectToAction("IndexFiltred");
            }


             
           
           
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
      
        [HttpPost]
        public ActionResult Augementer(DemangdeAug demande )
        {
                DemangdeAug de = db.DemangdeAugS.Find(demande.idDemande);
                de.etat = "Approuvé";
                EmployeeTable emp = db.EmployeeTables.Find(demande.IdEmp);
                emp.SalaireEmp += demande.MontantAug.GetValueOrDefault();
                db.SaveChanges();
       
            
          
            return RedirectToAction("Index", "EmployeeTables");
        }
        [HttpPost]
        public ActionResult Refuser(DemangdeAug demande)
        {
            DemangdeAug de = db.DemangdeAugS.Find(demande.idDemande);
            de.etat = "Refusé";
            db.SaveChanges();



            return RedirectToAction("Index", "EmployeeTables");
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
        public ActionResult Refuser(int id)
        {
            DemangdeAug de = db.DemangdeAugS.Find(id);
            de.etat = "Refusé";
            db.SaveChanges();

            return RedirectToAction("Index");
        }


    }
}
