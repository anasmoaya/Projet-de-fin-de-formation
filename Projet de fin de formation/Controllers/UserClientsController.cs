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
    public class UserClientsController : Controller
    {
        private fermeturesSolutionsEntities db = new fermeturesSolutionsEntities();

        // GET: UserClients
        public ActionResult Index()
        {
            var userClients = db.UserClients.Include(u => u.Client);
            return View(userClients.ToList());
        }

        // GET: UserClients/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserClient userClient = db.UserClients.Find(id);
            if (userClient == null)
            {
                return HttpNotFound();
            }
            return View(userClient);
        }

        // GET: UserClients/Create
        public ActionResult Create()
        {
            ViewBag.idClient = new SelectList(db.Clients, "idClient", "NomClient");
            return View();
        }

        // POST: UserClients/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "pseudo,password,idClient")] UserClient userClient)
        {
            if (ModelState.IsValid)
            {
                db.UserClients.Add(userClient);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idClient = new SelectList(db.Clients, "idClient", "NomClient", userClient.idClient);
            return View(userClient);
        }

        // GET: UserClients/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserClient userClient = db.UserClients.Find(id);
            if (userClient == null)
            {
                return HttpNotFound();
            }
            ViewBag.idClient = new SelectList(db.Clients, "idClient", "NomClient", userClient.idClient);
            return View(userClient);
        }

        // POST: UserClients/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "pseudo,password,idClient")] UserClient userClient)
        {
            if (ModelState.IsValid)
            {
                db.Entry(userClient).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idClient = new SelectList(db.Clients, "idClient", "NomClient", userClient.idClient);
            return View(userClient);
        }

        // GET: UserClients/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserClient userClient = db.UserClients.Find(id);
            if (userClient == null)
            {
                return HttpNotFound();
            }
            return View(userClient);
        }

        // POST: UserClients/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            UserClient userClient = db.UserClients.Find(id);
            db.UserClients.Remove(userClient);
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
