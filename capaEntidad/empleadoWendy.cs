using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace capaEntidad
{

//    CREATE TABLE empleadoWendy(
//    idEmpleadoWendy int PRIMARY KEY IDENTITY,
//    nombreEmpleado varchar(100),
//    edadEmpleado int,
//    cargoEmpleado varchar(100),
//    telefonoEmpleado varchar(50),
//    sexoEmpleado varchar(50),
//	  monto DECIMAL(10,2),
//    activoEmpleado bit DEFAULT 1,
//    idDireccion int FOREIGN KEY REFERENCES direccionEmpleado(idDireccion),
//    idDetalleLaboral int FOREIGN KEY REFERENCES detallesLaborales(idDetalleLaboral)
//);

    //mapeamos los datos de la tabla empleadoWendy extraidos desde la BD
    public class empleadoWendy
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
        public direccionEmpleado oidDireccion { get; set; }
        public detallesLaborales oidDetalleLaboral { get; set; }
    }
}
