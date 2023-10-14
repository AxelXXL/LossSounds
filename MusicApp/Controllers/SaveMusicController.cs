using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TagLib;
using TagLib.Flac;
using MusicApp.Models;
using System.IO;

namespace MusicApp.Controllers
{
    public class SaveMusicController : Controller
    {
        private BD_LOSS_SOUNDSEntities1 db = new BD_LOSS_SOUNDSEntities1();

        // GET: SaveMusic
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ObtenerMetadatosCancion(string rutaArchivo)
        {
            if (System.IO.File.Exists(rutaArchivo))
            {
                using (TagLib.File archivoAudio = TagLib.File.Create(rutaArchivo))
                {
                    string tituloCancion = archivoAudio.Tag.Title;
                    string[] artistas = archivoAudio.Tag.Performers;
                    string album = archivoAudio.Tag.Album;
                    string genero = archivoAudio.Tag.FirstGenre;
                    int añoAlbum = (int)archivoAudio.Tag.Year;
                    int numeroCancion = (int)archivoAudio.Tag.Track;
                    int duracionSegundos = (int)archivoAudio.Properties.Duration.TotalSeconds;

                    // Comprobar si el álbum ya existe en la base de datos
                    tb_Album albumExistente = db.tb_Album.FirstOrDefault(a => a.Nombre_album == album);
                    if (albumExistente == null)
                    {
                        albumExistente = new tb_Album
                        {
                            Nombre_album = album,
                            Genero = genero, // Establecer el género
                            Año_Album = añoAlbum // Establecer el año del álbum
                        };
                        db.tb_Album.Add(albumExistente);
                        db.SaveChanges(); // Guardar el álbum para obtener su ID
                    }

                    tb_Cancion cancion = new tb_Cancion
                    {
                        Nombre_Cancion = tituloCancion,
                        Duracion_Cancion = duracionSegundos,
                        Numero_Cancion = numeroCancion,
                        ID_ALBUM = albumExistente.ID_ALBUM
                    };

                    foreach (var artistaNombre in artistas)
                    {
                        // Comprobar si el artista ya existe en la base de datos
                        tb_Artista artistaExistente = db.tb_Artista.FirstOrDefault(a => a.Nombre_Artista == artistaNombre);
                        if (artistaExistente == null)
                        {
                            artistaExistente = new tb_Artista
                            {
                                Nombre_Artista = artistaNombre
                            };
                            db.tb_Artista.Add(artistaExistente);
                            db.SaveChanges(); // Guardar el artista para obtener su ID
                        }

                        cancion.ID_ARTISTA = artistaExistente.ID_ARTISTA;
                    }

                    cancion.Ruta_Audio = rutaArchivo;
                    db.tb_Cancion.Add(cancion);
                    db.SaveChanges();

                    return RedirectToAction("Index");
                }
            }
            else
            {
                return HttpNotFound("El archivo no fue encontrado");
            }
        }


    }
}
