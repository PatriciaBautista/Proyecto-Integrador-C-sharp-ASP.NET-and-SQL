using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace capaEntidad
{
//    CREATE TABLE Usuario(
//    idUsuario INT PRIMARY KEY IDENTITY,
//    nombreUsuario VARCHAR(100),
//    apellidoUsuario VARCHAR(100),
//    correo VARCHAR(100),
//    clave VARCHAR(150),
//    restablecerUsuario BIT DEFAULT 1,
//	  activo BIT DEFAULT 1,
//    fechaRegistro DATETIME DEFAULT GETDATE()
//);

    public class Usuario
    {
        public int idUsuario { get; set; }
        public string nombreUsuario { get; set; }
        public string apellidoUsuario { get; set; }
        public string correo { get; set; }
        public string clave { get; set; }
        public bool restablecerUsuario { get; set; }
        public bool activo { get; set; }

    }
}
