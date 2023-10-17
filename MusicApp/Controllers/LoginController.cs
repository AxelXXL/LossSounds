using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Microsoft.Ajax.Utilities;
using MusicApp.Models;

namespace MusicApp.Controllers
{
    public class LoginController : Controller
    {
        private BD_LOSS_SOUNDS2Entities db = new BD_LOSS_SOUNDS2Entities();

        public ActionResult Index()
        {

            return View();
        }

        [HttpPost]
        public ActionResult Login(tb_Usuario userr)
        {
            // Aquí debes realizar la validación del usuario y contraseña.
            // Puedes consultar tu base de datos u otro sistema de autenticación.
            // Si las credenciales son válidas, inicia sesión y redirige a la página principal.
            try
            {
                var validacion = db.tb_Usuario
                    .Where(a => a.Nombre_Usuario == userr.Nombre_Usuario && a.Contrasena == userr.Contrasena);
               var idUser = db.tb_Usuario
                    .Where(a => a.Nombre_Usuario == userr.Nombre_Usuario && a.Contrasena == userr.Contrasena)
                    .Select(c => new {
                        ID = c.ID_USUARIO
                    })
                    .FirstOrDefault();
                
                if (validacion != null)
                {
                    tb_Usuario oUser = validacion.First();
                    Session["User"] = oUser;
                    Session["Name"] = userr.Nombre_Usuario.ToString();
                    Session["IdUser"] = idUser.ID;
                    
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    return Content("Usuario invalido");
                }
               

            }
            catch (Exception ex)
            {
                return Content("Ocurrió un error "+ex.Message);
            }
           
           

           
            
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }











    }
}
