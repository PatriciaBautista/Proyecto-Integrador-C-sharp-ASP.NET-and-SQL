using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Grupo05_ProyectoWendy.Entidades
{
    public class DatosCompletosEmpleado
    {
        // Propiedades de empleadoWendy
        public string identificadorPersonal { get; set; }
        public string nombreEmpleado { get; set; }
        public string cargoEmpleado { get; set; }
        public decimal monto { get; set; }
        public int edadEmpleado { get; set; }

        // Propiedades de direccionEmpleado
        public string paisEmpleado { get; set; }
        public string sucursalEmpleado { get; set; }
        public string estado { get; set; }
        public string fechaIngreso { get; set; }
        public string fechaRenuncia { get; set; }
        public string tipoContrato { get; set; }
        public DateTime fechaEmision { get; set; }
    }
}