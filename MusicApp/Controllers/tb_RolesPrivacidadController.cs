using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MusicApp.Models;

namespace MusicApp.Controllers
{
    public class tb_RolesPrivacidadController : Controller
    {
        private BD_LOSS_SOUNDS2Entities db = new BD_LOSS_SOUNDS2Entities();

        // GET: tb_RolesPrivacidad
        public ActionResult Index()
        {
            return View(db.tb_RolesPrivacidad.ToList());
        }

        // GET: tb_RolesPrivacidad/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_RolesPrivacidad tb_RolesPrivacidad = db.tb_RolesPrivacidad.Find(id);
            if (tb_RolesPrivacidad == null)
            {
                return HttpNotFound();
            }
            return View(tb_RolesPrivacidad);
        }

        // GET: tb_RolesPrivacidad/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: tb_RolesPrivacidad/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_ROL,Rol")] tb_RolesPrivacidad tb_RolesPrivacidad)
        {
            if (ModelState.IsValid)
            {
                db.tb_RolesPrivacidad.Add(tb_RolesPrivacidad);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tb_RolesPrivacidad);
        }

        // GET: tb_RolesPrivacidad/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_RolesPrivacidad tb_RolesPrivacidad = db.tb_RolesPrivacidad.Find(id);
            if (tb_RolesPrivacidad == null)
            {
                return HttpNotFound();
            }
            return View(tb_RolesPrivacidad);
        }

        // POST: tb_RolesPrivacidad/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_ROL,Rol")] tb_RolesPrivacidad tb_RolesPrivacidad)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tb_RolesPrivacidad).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tb_RolesPrivacidad);
        }

        // GET: tb_RolesPrivacidad/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_RolesPrivacidad tb_RolesPrivacidad = db.tb_RolesPrivacidad.Find(id);
            if (tb_RolesPrivacidad == null)
            {
                return HttpNotFound();
            }
            return View(tb_RolesPrivacidad);
        }

        // POST: tb_RolesPrivacidad/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tb_RolesPrivacidad tb_RolesPrivacidad = db.tb_RolesPrivacidad.Find(id);
            db.tb_RolesPrivacidad.Remove(tb_RolesPrivacidad);
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
