using capaEntidad;
using Grupo05_ProyectoWendy.Entidades;
using Grupo05_ProyectoWendy.Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Grupo05_ProyectoWendy.Controllers
{
    public class EmpleadoWendyController : Controller
    {
        private EmpleadoWendyNegocio empleadoWendyNegocio;

        public EmpleadoWendyController()
        {
            empleadoWendyNegocio = new EmpleadoWendyNegocio();
        }

        // GET: EmpleadoWendy
        public ActionResult ListaEmpleados(string identificador)
        {
            List<EmpleadoWendy> empleados = empleadoWendyNegocio.ObtenerTodosLosEmpleados();

            if (!string.IsNullOrEmpty(identificador))
            {
                empleados = empleados.Where(e => e.identificadorPersonal.Contains(identificador)).ToList();
            }

            return View(empleados);
        }


        //Inicia método para crear nuevo empleado
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(EmpleadoWendy empleado)
        {
            try
            {
                // Validar y guardar el nuevo empleado
                empleadoWendyNegocio.CrearEmpleado(empleado);
                // Redirigir a la lista de empleados
                return RedirectToAction("ListaEmpleados");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "No se pudo crear el empleado. Por favor, verifica los datos ingresados.");
                return View("Create");
            }
        }
        //Finaliza el método para crear nuevo empleado

        //inicia el método de editar empleado
        public ActionResult Edit(int id)
        {
            EmpleadoWendy empleado = empleadoWendyNegocio.ObtenerEmpleadoPorId(id);
            if (empleado == null)
            {
                return HttpNotFound();
            }
            return View(empleado);
        }

        [HttpPost]
        public ActionResult Edit(EmpleadoWendy empleado)
        {
            try
            {
                // Validar y actualizar el empleado
                empleadoWendyNegocio.ActualizarEmpleado(empleado);
                // Redirigir a la lista de empleados u otra página de éxito
                return RedirectToAction("ListaEmpleados");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "No se pudo actualizar el empleado. Por favor, verifica los datos ingresados.");
                return View(empleado);
            }
        }
        //finaliza el método de editar empleado

        //inicia el método de eliminar datos de la BD
        // Método para eliminar un empleado
        public ActionResult Delete(int id)
        {
            try
            {
                // Eliminar el empleado por su ID
                empleadoWendyNegocio.EliminarEmpleado(id);
                // Redirigir a la lista de empleados u otra página de éxito
                return RedirectToAction("ListaEmpleados");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "No se pudo eliminar el empleado. Por favor, verifica los datos ingresados.");
                return View("ListaEmpleados");
            }
        }

        //finaliza el método de eliminar datos de la BD
    }
}