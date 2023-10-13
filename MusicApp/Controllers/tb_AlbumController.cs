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
    public class tb_AlbumController : Controller
    {
        private BD_LOSS_SOUNDS2Entities db = new BD_LOSS_SOUNDS2Entities();

        // GET: tb_Album
        public ActionResult Index()
        {
            var tb_Album = db.tb_Album.Include(t => t.tb_Artista);
            return View(tb_Album.ToList());
        }

        // GET: tb_Album/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_Album tb_Album = db.tb_Album.Find(id);
            if (tb_Album == null)
            {
                return HttpNotFound();
            }
            return View(tb_Album);
        }

        // GET: tb_Album/Create
        public ActionResult Create()
        {
            ViewBag.ID_ARTISTA = new SelectList(db.tb_Artista, "ID_ARTISTA", "Nombre_Artista");
            return View();
        }

        // POST: tb_Album/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_ALBUM,ID_ARTISTA,Nombre_album,Genero,Año_Album")] tb_Album tb_Album)
        {
            if (ModelState.IsValid)
            {
                db.tb_Album.Add(tb_Album);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_ARTISTA = new SelectList(db.tb_Artista, "ID_ARTISTA", "Nombre_Artista", tb_Album.ID_ARTISTA);
            return View(tb_Album);
        }

        // GET: tb_Album/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_Album tb_Album = db.tb_Album.Find(id);
            if (tb_Album == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_ARTISTA = new SelectList(db.tb_Artista, "ID_ARTISTA", "Nombre_Artista", tb_Album.ID_ARTISTA);
            return View(tb_Album);
        }

        // POST: tb_Album/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_ALBUM,ID_ARTISTA,Nombre_album,Genero,Año_Album")] tb_Album tb_Album)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tb_Album).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_ARTISTA = new SelectList(db.tb_Artista, "ID_ARTISTA", "Nombre_Artista", tb_Album.ID_ARTISTA);
            return View(tb_Album);
        }

        // GET: tb_Album/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_Album tb_Album = db.tb_Album.Find(id);
            if (tb_Album == null)
            {
                return HttpNotFound();
            }
            return View(tb_Album);
        }

        // POST: tb_Album/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tb_Album tb_Album = db.tb_Album.Find(id);
            db.tb_Album.Remove(tb_Album);
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
