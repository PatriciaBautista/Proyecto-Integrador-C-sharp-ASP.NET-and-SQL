using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using capaEntidad;
using capaNegocio;

namespace Grupo05_ProyectoWendy.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult usuario()
        {
            return View();
        }

        //obtenemos la lista o información de datos user
        [HttpGet]//devuelve los datos
        public JsonResult ListarUsuario()
        {
            List<Usuario> oLista = new List<Usuario>();//llama a la lista de CD_usuario 

            oLista = new CN_Usuario().Listar();//lista los datos por medio de json
            return Json(new { data = oLista }, JsonRequestBehavior.AllowGet);
        }

        //registrar
        //editar
        [HttpPost]//devuelve los datos
        public JsonResult GuardaUsuario(Usuario objeto)
        {
            object resultado;
            string mensaje = string.Empty;
            if(objeto.idUsuario == 0)
            {
                resultado = new CN_Usuario().Registrar(objeto, out mensaje);
            }
            else
            {
                resultado = new CN_Usuario().Editar(objeto, out mensaje);
            }
            return Json(new {resultado = resultado, mensaje = mensaje}, JsonRequestBehavior.AllowGet);
        }
        //eliminar

        [HttpPost]
        public JsonResult EliminarUsuario(int id)
        {
            bool respuesta = false;
            string mensaje = string.Empty;

            respuesta = new CN_Usuario().Eliminar(id, out mensaje);

            return Json(new { resultado = respuesta, mensaje = mensaje }, JsonRequestBehavior.AllowGet);
        }
    }
}