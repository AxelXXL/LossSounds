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
        public ActionResult Login(tb_Usuario user)
        {
            // Aquí debes realizar la validación del usuario y contraseña.
            // Puedes consultar tu base de datos u otro sistema de autenticación.
            // Si las credenciales son válidas, inicia sesión y redirige a la página principal.
            try
            {
                var validacion = db.tb_Usuario.Where(a => a.Nombre_Usuario == user.Nombre_Usuario && a.Contrasena == user.Contrasena)
                                              .FirstOrDefault();
                if (validacion != null)
                {
                    FormsAuthentication.SetAuthCookie(user.Nombre_Usuario, false);
                    return RedirectToAction("Index", "Home");
                }
               

            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Usuario o contraseña incorrectos");
            }
           
           

           
            return View();
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }











    }
}
