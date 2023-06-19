using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Grupo05_ProyectoWendy.Entidades
{
    public class DireccionEmpleado
    {
        public int idDireccion { get; set; }
        public string codDireccion { get; set; }
        public string sucursalEmpleado { get; set; }
        public string paisEmpleado { get; set; }
        public string estado { get; set; }
        public string nombreCalle { get; set; }
        public string coloniaEmpleado { get; set; }
        public int codigoPostal { get; set; }
        public bool activoDireccion { get; set; }
    }
}