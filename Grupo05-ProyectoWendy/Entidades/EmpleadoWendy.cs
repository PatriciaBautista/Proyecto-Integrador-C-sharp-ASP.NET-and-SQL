using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Grupo05_ProyectoWendy.Entidades
{
    public class EmpleadoWendy
    {
        public int idEmpleadoWendy { get; set; }
        public string identificadorPersonal { get; set; }
        public string nombreEmpleado { get; set; }
        public int edadEmpleado { get; set; }
        public string cargoEmpleado { get; set; }
        public string telefonoEmpleado { get; set; }
        public string sexoEmpleado { get; set; }
        public decimal monto { get; set; }
        public bool activoEmpleado { get; set; }
        public int idDireccion { get; set; }
        public int idDetalleLaboral { get; set; }

        public DireccionEmpleado DireccionEmpleado { get; set; }
        public DetallesLaborales DetallesLaborales { get; set; }
    }
}