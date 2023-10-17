using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MusicApp.Models;

namespace MusicApp.Controllers
{
    public class tb_CancionController : Controller
    {
        private BD_LOSS_SOUNDS2Entities db = new BD_LOSS_SOUNDS2Entities();

        // GET: tb_Cancion
        public ActionResult Index()
        {
            var tb_Cancion = db.tb_Cancion.Include(t => t.tb_Album).Include(t => t.tb_Artista);
            return View(tb_Cancion.ToList());
        }

        // GET: tb_Cancion/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_Cancion tb_Cancion = db.tb_Cancion.Find(id);
            if (tb_Cancion == null)
            {
                return HttpNotFound();
            }
            return View(tb_Cancion);
        }

        // GET: tb_Cancion/Create
        public ActionResult Create()
        {
            ViewBag.ID_ALBUM = new SelectList(db.tb_Album, "ID_ALBUM", "Nombre_album");
            ViewBag.ID_ARTISTA = new SelectList(db.tb_Artista, "ID_ARTISTA", "Nombre_Artista");
            return View();
        }

        // POST: tb_Cancion/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_CANCION,ID_ARTISTA,ID_ALBUM,Nombre_Cancion,Numero_Cancion,Ruta_Audio,PortadaFile")] tb_Cancion tb_Cancion)
        {
            if (ModelState.IsValid)
            {
                if (tb_Cancion.PortadaFile != null)
                {
                    byte[] imageData;
                    using (var binaryReader = new BinaryReader(tb_Cancion.PortadaFile.InputStream))
                    {
                        imageData = binaryReader.ReadBytes(tb_Cancion.PortadaFile.ContentLength);
                    }
                    tb_Cancion.Portada = imageData;
                    // Guardar 'imageData' en la base de datos y luego redirigir a otra vista.
                    db.tb_Cancion.Add(tb_Cancion);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
               
            }
        

            ViewBag.ID_ALBUM = new SelectList(db.tb_Album, "ID_ALBUM", "Nombre_album", tb_Cancion.ID_ALBUM);
            ViewBag.ID_ARTISTA = new SelectList(db.tb_Artista, "ID_ARTISTA", "Nombre_Artista", tb_Cancion.ID_ARTISTA);
            return View(tb_Cancion);
        }


        // GET: tb_Cancion/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_Cancion tb_Cancion = db.tb_Cancion.Find(id);
            if (tb_Cancion == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_ALBUM = new SelectList(db.tb_Album, "ID_ALBUM", "Nombre_album", tb_Cancion.ID_ALBUM);
            ViewBag.ID_ARTISTA = new SelectList(db.tb_Artista, "ID_ARTISTA", "Nombre_Artista", tb_Cancion.ID_ARTISTA);
            return View(tb_Cancion);
        }

        // POST: tb_Cancion/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_CANCION,ID_ARTISTA,ID_ALBUM,Nombre_Cancion,Numero_Cancion,Ruta_Audio,Portada")] tb_Cancion tb_Cancion)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tb_Cancion).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_ALBUM = new SelectList(db.tb_Album, "ID_ALBUM", "Nombre_album", tb_Cancion.ID_ALBUM);
            ViewBag.ID_ARTISTA = new SelectList(db.tb_Artista, "ID_ARTISTA", "Nombre_Artista", tb_Cancion.ID_ARTISTA);
            return View(tb_Cancion);
        }

        // GET: tb_Cancion/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_Cancion tb_Cancion = db.tb_Cancion.Find(id);
            if (tb_Cancion == null)
            {
                return HttpNotFound();
            }
            return View(tb_Cancion);
        }

        // POST: tb_Cancion/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tb_Cancion tb_Cancion = db.tb_Cancion.Find(id);
            db.tb_Cancion.Remove(tb_Cancion);
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
