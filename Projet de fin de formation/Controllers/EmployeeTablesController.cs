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
    public class EmployeeTablesController : Controller
    {
        private fermeturesSolutionsEntities db = new fermeturesSolutionsEntities();

        // GET: EmployeeTables
        public ActionResult Index()
        {
            var employeeTables = db.EmployeeTables.Include(e => e.Depatement);
            return View(employeeTables.ToList());
        }

        // GET: EmployeeTables/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmployeeTable employeeTable = db.EmployeeTables.Find(id);
            if (employeeTable == null)
            {
                return HttpNotFound();
            }
            return View(employeeTable);
        }

        // GET: EmployeeTables/Create
        public ActionResult Create()
        {
            ViewBag.idDepartement = new SelectList(db.Depatements, "idDepartement", "nomDepartement");
            return View();
        }

        // POST: EmployeeTables/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdEmp,PrenomEmp,NomEmp,MailEmp,TelEmp,Address,DateNEmp,SexeEmp,DateRecEmp,idDepartement,PosteEmp,SalaireEmp,pointsEmp")] EmployeeTable employeeTable)
        {
            if (ModelState.IsValid)
            {
                EmployeeTable em = db.EmployeeTables.Find(employeeTable.IdEmp);

                if (em == null)
                {
                db.EmployeeTables.Add(employeeTable);
                db.SaveChanges();
                }
                
                return RedirectToAction("Index");

       
               
            }

            ViewBag.idDepartement = new SelectList(db.Depatements, "idDepartement", "nomDepartement", employeeTable.idDepartement);
            return View(employeeTable);
        }

        // GET: EmployeeTables/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmployeeTable employeeTable = db.EmployeeTables.Find(id);
            if (employeeTable == null)
            {
                return HttpNotFound();
            }
            ViewBag.idDepartement = new SelectList(db.Depatements, "idDepartement", "nomDepartement", employeeTable.idDepartement);
            return View(employeeTable);
        }

        // POST: EmployeeTables/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdEmp,PrenomEmp,NomEmp,MailEmp,TelEmp,Address,DateNEmp,SexeEmp,DateRecEmp,idDepartement,PosteEmp,SalaireEmp,pointsEmp")] EmployeeTable employeeTable)
        {
            if (ModelState.IsValid)
            {
                db.Entry(employeeTable).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idDepartement = new SelectList(db.Depatements, "idDepartement", "nomDepartement", employeeTable.idDepartement);
            return View(employeeTable);
        }

        // GET: EmployeeTables/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmployeeTable employeeTable = db.EmployeeTables.Find(id);
            if (employeeTable == null)
            {
                return HttpNotFound();
            }
            return View(employeeTable);
        }


        public ActionResult IndexEmploye(UserTable user)
        {
            EmployeeTable emp = db.EmployeeTables.Find(user.IdEmp);
            return View(emp);
        }
            

        // POST: EmployeeTables/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            EmployeeTable employeeTable = db.EmployeeTables.Find(id);
            db.EmployeeTables.Remove(employeeTable);
            db.SaveChanges();
            return RedirectToAction("Index");
        }



        public ActionResult EditEmploye(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmployeeTable employeeTable = db.EmployeeTables.Find(id);
            if (employeeTable == null)
            {
                return HttpNotFound();
            }
            ViewBag.idDepartement = new SelectList(db.Depatements, "idDepartement", "nomDepartement", employeeTable.idDepartement);
            return View(employeeTable);
        }

        // POST: EmployeeTables/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditEmploye([Bind(Include = "IdEmp,PrenomEmp,NomEmp,MailEmp,TelEmp,Address,DateNEmp,SexeEmp,DateRecEmp,idDepartement,PosteEmp,SalaireEmp,pointsEmp")] EmployeeTable employeeTable)
        {
            if (ModelState.IsValid)
            {
                db.Entry(employeeTable).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("IndexEmploye");
            }
            ViewBag.idDepartement = new SelectList(db.Depatements, "idDepartement", "nomDepartement", employeeTable.idDepartement);
            return View(employeeTable);
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
