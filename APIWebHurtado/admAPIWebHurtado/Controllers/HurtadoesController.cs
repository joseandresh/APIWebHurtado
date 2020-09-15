using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using admAPIWebHurtado.Models;

namespace admAPIWebHurtado.Controllers
{
    public class HurtadoesController : Controller
    {
        private DataContext db = new DataContext();

        // GET: Hurtadoes
        [Authorize]
        public ActionResult Index()
        {
            return View(db.Hurtadoes.ToList());
        }

        // GET: Hurtadoes/Details/5
        [Authorize]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Hurtado hurtado = db.Hurtadoes.Find(id);
            if (hurtado == null)
            {
                return HttpNotFound();
            }
            return View(hurtado);
        }

        // GET: Hurtadoes/Create
        [Authorize]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Hurtadoes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "HurtadoID,FriendofHurtado,Place,Email,Birthdate")] Hurtado hurtado)
        {
            if (ModelState.IsValid)
            {
                db.Hurtadoes.Add(hurtado);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(hurtado);
        }

        // GET: Hurtadoes/Edit/5
        [Authorize]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Hurtado hurtado = db.Hurtadoes.Find(id);
            if (hurtado == null)
            {
                return HttpNotFound();
            }
            return View(hurtado);
        }

        // POST: Hurtadoes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "HurtadoID,FriendofHurtado,Place,Email,Birthdate")] Hurtado hurtado)
        {
            if (ModelState.IsValid)
            {
                db.Entry(hurtado).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(hurtado);
        }

        // GET: Hurtadoes/Delete/5
        [Authorize]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Hurtado hurtado = db.Hurtadoes.Find(id);
            if (hurtado == null)
            {
                return HttpNotFound();
            }
            return View(hurtado);
        }

        // POST: Hurtadoes/Delete/5
        [Authorize]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Hurtado hurtado = db.Hurtadoes.Find(id);
            db.Hurtadoes.Remove(hurtado);
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
