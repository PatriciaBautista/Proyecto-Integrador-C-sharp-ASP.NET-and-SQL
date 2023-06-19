using capaEntidad;
using capaNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Grupo05_ProyectoWendy.Controllers
{
    public class AccesoController : Controller
    {
        // GET: Acceso
        public ActionResult Login()
        {
            return View();
        }

        public ActionResult CambiarClave()
        {
            return View();
        }

        public ActionResult Reestablecer()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string correo, string clave)
        {
            Usuario oUsuario = new Usuario();
            oUsuario = new CN_Usuario().Listar().Where(u => u.correo == correo && u.clave == CN_Recursos.ConvertirSha256(clave)).FirstOrDefault();
            if (oUsuario == null)
            {
                ViewBag.Error = "El correo o la contraseña no son correctas";//validaciones dentro del login
                return View();
            }
            else
            {
                ViewBag.Error = null;
                return RedirectToAction("Detalles", "Mantenedor");//envío a la vista de detalles sistema en marcha
            }
        }
    }
}