using EntreHojas.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace EntreHojas.WebAdmin.Controllers
{
    public class LoginController : Controller
    {

        SeguridadBL _seguridadBL;

        public LoginController()
        {
            _seguridadBL = new SeguridadBL();
        }
         
        // GET: Login
        public ActionResult Index()
        {
            FormsAuthentication.SignOut();
            return View();
        }

        [HttpPost]
        public ActionResult Index(FormCollection data)
        {
            var nombreUsuario = data["username"];  //valida los datos de contraseña y usuario
            var contrasena = data["password"];

            var usuarioValido = _seguridadBL
                .Autorizar(nombreUsuario, contrasena);

            if (usuarioValido)
            {
                FormsAuthentication.SetAuthCookie(nombreUsuario, true);   //guarda las cookies
                return RedirectToAction("Index", "Home");
            }

            ModelState.AddModelError("", "Usuario o contraseña invalido");  //Manda el mensaje de error cuando ingresamos datos incorrectos

            return View();
        }
    }
}