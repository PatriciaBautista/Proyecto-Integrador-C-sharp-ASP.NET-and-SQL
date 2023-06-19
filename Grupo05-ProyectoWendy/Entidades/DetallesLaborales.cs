using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Grupo05_ProyectoWendy.Entidades
{
    public class DetallesLaborales
    {
        public int idDetalleLaboral { get; set; }
        public string codDetalles { get; set; }
        public string fechaIngreso { get; set; }
        public string fechaRenuncia { get; set; }
        public string tipoContrato { get; set; }
        public DateTime fechaEmision { get; set; }
        public bool activoDetalle { get; set; }
    }
}