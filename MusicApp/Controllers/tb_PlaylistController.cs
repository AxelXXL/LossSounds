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
    public class tb_PlaylistController : Controller
    {
        private BD_LOSS_SOUNDS2Entities db = new BD_LOSS_SOUNDS2Entities();

        // GET: tb_Playlist
        public ActionResult Index()
        {
            var tb_Playlist = db.tb_Playlist.Include(t => t.tb_Cancion).Include(t => t.tb_RolesPrivacidad).Include(t => t.tb_Usuario);
            return View(tb_Playlist.ToList());
        }

        // GET: tb_Playlist/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_Playlist tb_Playlist = db.tb_Playlist.Find(id);
            if (tb_Playlist == null)
            {
                return HttpNotFound();
            }
            return View(tb_Playlist);
        }

        // GET: tb_Playlist/Create
        public ActionResult Create()
        {
            ViewBag.ID_CANCION = new SelectList(db.tb_Cancion, "ID_CANCION", "Nombre_Cancion");
            ViewBag.ID_PRIVACIDAD = new SelectList(db.tb_RolesPrivacidad, "ID_ROL", "Rol");
            ViewBag.ID_USUARIO = new SelectList(db.tb_Usuario, "ID_USUARIO", "Nombre_Usuario");
            return View();
        }

        // POST: tb_Playlist/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_PLAYLIST,ID_USUARIO,ID_CANCION,Nombre_Playlist,Fecha_Creacion,ID_PRIVACIDAD")] tb_Playlist tb_Playlist)
        {
            if (ModelState.IsValid)
            {
                db.tb_Playlist.Add(tb_Playlist);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_CANCION = new SelectList(db.tb_Cancion, "ID_CANCION", "Nombre_Cancion", tb_Playlist.ID_CANCION);
            ViewBag.ID_PRIVACIDAD = new SelectList(db.tb_RolesPrivacidad, "ID_ROL", "Rol", tb_Playlist.ID_PRIVACIDAD);
            ViewBag.ID_USUARIO = new SelectList(db.tb_Usuario, "ID_USUARIO", "Nombre_Usuario", tb_Playlist.ID_USUARIO);
            return View(tb_Playlist);
        }

        // GET: tb_Playlist/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_Playlist tb_Playlist = db.tb_Playlist.Find(id);
            if (tb_Playlist == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_CANCION = new SelectList(db.tb_Cancion, "ID_CANCION", "Nombre_Cancion", tb_Playlist.ID_CANCION);
            ViewBag.ID_PRIVACIDAD = new SelectList(db.tb_RolesPrivacidad, "ID_ROL", "Rol", tb_Playlist.ID_PRIVACIDAD);
            ViewBag.ID_USUARIO = new SelectList(db.tb_Usuario, "ID_USUARIO", "Nombre_Usuario", tb_Playlist.ID_USUARIO);
            return View(tb_Playlist);
        }

        // POST: tb_Playlist/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_PLAYLIST,ID_USUARIO,ID_CANCION,Nombre_Playlist,Fecha_Creacion,ID_PRIVACIDAD")] tb_Playlist tb_Playlist)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tb_Playlist).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_CANCION = new SelectList(db.tb_Cancion, "ID_CANCION", "Nombre_Cancion", tb_Playlist.ID_CANCION);
            ViewBag.ID_PRIVACIDAD = new SelectList(db.tb_RolesPrivacidad, "ID_ROL", "Rol", tb_Playlist.ID_PRIVACIDAD);
            ViewBag.ID_USUARIO = new SelectList(db.tb_Usuario, "ID_USUARIO", "Nombre_Usuario", tb_Playlist.ID_USUARIO);
            return View(tb_Playlist);
        }

        // GET: tb_Playlist/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_Playlist tb_Playlist = db.tb_Playlist.Find(id);
            if (tb_Playlist == null)
            {
                return HttpNotFound();
            }
            return View(tb_Playlist);
        }

        // POST: tb_Playlist/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tb_Playlist tb_Playlist = db.tb_Playlist.Find(id);
            db.tb_Playlist.Remove(tb_Playlist);
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
