using capaDatos;
using capaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace capaNegocio
{
    public class CN_Direccion
    {
        //listado direccion
        private CD_Direccion objcapaDatos = new CD_Direccion();

        //método para devolver la lista de los detalles de la capa cd detalles laborales
        public List<direccionEmpleado> Listar()
        {
            return objcapaDatos.Listar();
        }
        //fin de la lista

        //inicio del metodo guardar
        public int Registrar(direccionEmpleado obj, out string Mensaje)
        {
            Mensaje = string.Empty;
            if (string.IsNullOrEmpty(obj.codDireccion) || string.IsNullOrWhiteSpace(obj.codDireccion))
            {
                Mensaje = "Campo codDireccion debe ser completado";
            }

            //validación para renuncia
            if (string.IsNullOrEmpty(obj.sucursalEmpleado) || string.IsNullOrWhiteSpace(obj.sucursalEmpleado))
            {
                Mensaje = "Campo sucursalEmpleado debe ser completado";
            }

            //validación para contrato
            if (string.IsNullOrEmpty(obj.paisEmpleado) || string.IsNullOrWhiteSpace(obj.paisEmpleado))
            {
                Mensaje = "Campo paisEmpleado debe ser completado";
            }

            if (string.IsNullOrEmpty(obj.estado) || string.IsNullOrWhiteSpace(obj.estado))
            {
                Mensaje = "Campo estado debe ser completado";
            } 
            
            if (string.IsNullOrEmpty(obj.nombreCalle) || string.IsNullOrWhiteSpace(obj.nombreCalle))
            {
                Mensaje = "Campo nombreCalle debe ser completado";
            }
            
            if (string.IsNullOrEmpty(obj.coloniaEmpleado) || string.IsNullOrWhiteSpace(obj.coloniaEmpleado))
            {
                Mensaje = "Campo coloniaEmpleado debe ser completado";
            }
            
            if (string.IsNullOrEmpty(Mensaje))
            {
                return objcapaDatos.Registrar(obj, out Mensaje);
            }
            else
            {
                return 0;
            }

        }
        //fin del metodo guardar

        //editar
        public bool Editar(direccionEmpleado obj, out string Mensaje)
        {
            //validación de campos vacíos
            Mensaje = string.Empty;
            if (string.IsNullOrEmpty(obj.codDireccion) || string.IsNullOrWhiteSpace(obj.codDireccion))
            {
                Mensaje = "Campo codDireccion debe ser completado";
            }

            //validación para renuncia
            if (string.IsNullOrEmpty(obj.sucursalEmpleado) || string.IsNullOrWhiteSpace(obj.sucursalEmpleado))
            {
                Mensaje = "Campo sucursalEmpleado debe ser completado";
            }

            //validación para contrato
            if (string.IsNullOrEmpty(obj.paisEmpleado) || string.IsNullOrWhiteSpace(obj.paisEmpleado))
            {
                Mensaje = "Campo paisEmpleado debe ser completado";
            }

            if (string.IsNullOrEmpty(obj.estado) || string.IsNullOrWhiteSpace(obj.estado))
            {
                Mensaje = "Campo estado debe ser completado";
            }

            if (string.IsNullOrEmpty(obj.nombreCalle) || string.IsNullOrWhiteSpace(obj.nombreCalle))
            {
                Mensaje = "Campo nombreCalle debe ser completado";
            }

            if (string.IsNullOrEmpty(obj.coloniaEmpleado) || string.IsNullOrWhiteSpace(obj.coloniaEmpleado))
            {
                Mensaje = "Campo coloniaEmpleado debe ser completado";
            }

            if (string.IsNullOrEmpty(Mensaje))
            {
                return objcapaDatos.Editar(obj, out Mensaje);
            }
            else
            {
                return false;
            }
        }
        //fin editar

        //eliminar
        public bool Eliminar(int id, out string Mensaje)
        {
            return objcapaDatos.Eliminar(id, out Mensaje);
        }

        //fin de eliminar
    }
}
