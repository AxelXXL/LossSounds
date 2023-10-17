using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using MusicApp.Models;

namespace MusicApp.Controllers
{
    public class HomeController : Controller
    {
        private BD_LOSS_SOUNDS2Entities db = new BD_LOSS_SOUNDS2Entities();
        public ActionResult Index()
        {
           
            return View();
        }
        public ActionResult Novedades()
        {
           
            return View();
        }
        public JsonResult GetNovedades()
        {
            var datos = db.tb_Cancion.Include(t => t.tb_Album).Include(t => t.tb_Artista)
                                       .Take(50) // Tomar las primeras 50 filas
                                       .Select(c => new
                                       {
                                           NombreCancion = c.Nombre_Cancion,
                                           NombreArtista = c.tb_Artista.Nombre_Artista,
                                           NombreAlbum = c.tb_Album.Nombre_album,
                                           Caratula = c.Portada
                                       })
                                           .ToList(); ;

            

            return Json(datos, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetCancionList(string txt)
        {
            List<SelectListItem> items = db.tb_Cancion
                .Where(x =>
                x.Nombre_Cancion.Contains(txt) || x.tb_Album.Nombre_album.Contains(txt) || x.tb_Album.Genero.Contains(txt)
                || x.tb_Artista.Nombre_Artista.Contains(txt))
                .Select(x => new SelectListItem()
                {
                    Text = x.Nombre_Cancion,
                    Value = x.ID_CANCION.ToString()
                })
                .ToList();
            return Json(items, JsonRequestBehavior.AllowGet);



        }
        [HttpGet]
        public FileResult GetImagen(byte[] dataImg)
        {
            byte[] fileBytes = dataImg;// aqui el array de bytes
            return File(fileBytes, "image/png", "nombre.png"); //3er argumento es opcional
        }

    }
}