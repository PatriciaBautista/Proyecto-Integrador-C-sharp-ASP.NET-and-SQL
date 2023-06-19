using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Grupo05_ProyectoWendy.Entidades
{
    public class DatosCompletos
    {
        public List<EmpleadoWendy> Empleados { get; set; }
        public List<DireccionEmpleado> Direccion { get; set; }
        public List<DetallesLaborales> DetalleLaboral { get; set; }
    }
}