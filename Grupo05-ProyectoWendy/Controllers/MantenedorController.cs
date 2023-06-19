using capaEntidad;
using capaNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Grupo05_ProyectoWendy.Controllers
{
    public class MantenedorController : Controller
    {
        // GET: Mantenedor
        public ActionResult Detalles()
        {
            return View();
        }
        public ActionResult Direccion()
        {
            return View();
        }
        public ActionResult DatosReporte()
        {
            return View();
        }

        #region DETALLE

        //obtenemos la lista o información de datos user
        [HttpGet]//devuelve los datos
        public JsonResult ListarDetalle()
        {
            List<detallesLaborales> oLista = new List<detallesLaborales>();//llama a la lista de CD_Catergorias 

            oLista = new CN_detalleLaboral().Listar();//lista los datos por medio de json
            return Json(new { data = oLista }, JsonRequestBehavior.AllowGet);
        }

        ////registrar
        //editar
        [HttpPost]//devuelve los datos
        public JsonResult GuardaDetalle(detallesLaborales objeto)
        {
            object resultado;
            string mensaje = string.Empty;
            if (objeto.idDetalleLaboral == 0)
            {
                resultado = new CN_detalleLaboral().Registrar(objeto, out mensaje);
            }
            else
            {
                resultado = new CN_detalleLaboral().Editar(objeto, out mensaje);
            }
            return Json(new { resultado = resultado, mensaje = mensaje }, JsonRequestBehavior.AllowGet);
        }

        //eliminar categoria
        [HttpPost]
        public JsonResult EliminarDetalle(int id)
        {
            bool respuesta = false;
            string mensaje = string.Empty;

            respuesta = new CN_detalleLaboral().Eliminar(id, out mensaje);

            return Json(new { resultado = respuesta, mensaje = mensaje }, JsonRequestBehavior.AllowGet);
        }

        #endregion

        //procesos para la tabla de DIRECCIÓN
        #region DIRECCION
        //obtenemos la lista o información de datos user
        [HttpGet]//devuelve los datos
        public JsonResult ListarDireccion()
        {
            List<direccionEmpleado> oLista = new List<direccionEmpleado>();//llama a la lista de CD_Catergorias 

            oLista = new CN_Direccion().Listar();//lista los datos por medio de json
            return Json(new { data = oLista }, JsonRequestBehavior.AllowGet);
        }

        ////registrar
        //editar
        [HttpPost]//devuelve los datos
        public JsonResult GuardaDireccion(direccionEmpleado objeto)
        {
            object resultado;
            string mensaje = string.Empty;
            if (objeto.idDireccion == 0)
            {
                resultado = new CN_Direccion().Registrar(objeto, out mensaje);
            }
            else
            {
                resultado = new CN_Direccion().Editar(objeto, out mensaje);
            }
            return Json(new { resultado = resultado, mensaje = mensaje }, JsonRequestBehavior.AllowGet);
        }
        //editar datos

        //fin de la edición de datos


        //eliminar categoria
        [HttpPost]
        public JsonResult EliminarDirección(int id)
        {
            bool respuesta = false;
            string mensaje = string.Empty;

            respuesta = new CN_Direccion().Eliminar(id, out mensaje);

            return Json(new { resultado = respuesta, mensaje = mensaje }, JsonRequestBehavior.AllowGet);
        }
        #endregion
    }
}