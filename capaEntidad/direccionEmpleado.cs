using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace capaEntidad
{
    /*
    CREATE TABLE direccionEmpleado (
        idDireccion INT PRIMARY KEY IDENTITY,
        codDireccion VARCHAR(10),
        sucursalEmpleado VARCHAR(100),
        paisEmpleado VARCHAR(100),
        estado VARCHAR(100),
        nombreCalle VARCHAR(100),
        coloniaEmpleado VARCHAR(100),
        codigoPostal INT,
        activoDireccion BIT DEFAULT 1
    );
    */


    public class direccionEmpleado
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
