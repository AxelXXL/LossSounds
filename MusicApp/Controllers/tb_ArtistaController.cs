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
    public class tb_ArtistaController : Controller
    {
        private BD_LOSS_SOUNDS2Entities db = new BD_LOSS_SOUNDS2Entities();

        // GET: tb_Artista
        public ActionResult Index()
        {
            return View(db.tb_Artista.ToList());
        }

        // GET: tb_Artista/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_Artista tb_Artista = db.tb_Artista.Find(id);
            if (tb_Artista == null)
            {
                return HttpNotFound();
            }
            return View(tb_Artista);
        }

        // GET: tb_Artista/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: tb_Artista/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_ARTISTA,Nombre_Artista")] tb_Artista tb_Artista)
        {
            if (ModelState.IsValid)
            {
                db.tb_Artista.Add(tb_Artista);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tb_Artista);
        }

        // GET: tb_Artista/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_Artista tb_Artista = db.tb_Artista.Find(id);
            if (tb_Artista == null)
            {
                return HttpNotFound();
            }
            return View(tb_Artista);
        }

        // POST: tb_Artista/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_ARTISTA,Nombre_Artista")] tb_Artista tb_Artista)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tb_Artista).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tb_Artista);
        }

        // GET: tb_Artista/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_Artista tb_Artista = db.tb_Artista.Find(id);
            if (tb_Artista == null)
            {
                return HttpNotFound();
            }
            return View(tb_Artista);
        }

        // POST: tb_Artista/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tb_Artista tb_Artista = db.tb_Artista.Find(id);
            db.tb_Artista.Remove(tb_Artista);
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
