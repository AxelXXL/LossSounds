using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TagLib;

namespace MusicApp.Controllers
{
    public class SaveMusicController : Controller
    {
        // GET: SaveMusic
        public ActionResult Index()
        {
            return View();
        }

        private ActionResult ObtenerMetadatos(string filePath)
        {
            

            return null;
        }

        [HttpPost]
        public ActionResult GuardarMetadatos(string filePath)
        {

            return null;
        }
    }
}