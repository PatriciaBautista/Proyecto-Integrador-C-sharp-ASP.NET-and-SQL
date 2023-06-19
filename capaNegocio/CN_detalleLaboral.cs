using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using capaDatos;
using capaEntidad;

namespace capaNegocio
{
    public class CN_detalleLaboral
    {
        private CD_DetallesLaborales objcapaDatos = new CD_DetallesLaborales();

        //método para devolver la lista de los detalles de la capa cd detalles laborales
        public List<detallesLaborales> Listar()
        {
            return objcapaDatos.Listar();
        }

        //método de registrar

        public int Registrar(detallesLaborales obj, out string Mensaje)
        {
            Mensaje = string.Empty;
            if (string.IsNullOrEmpty(obj.fechaIngreso) || string.IsNullOrWhiteSpace(obj.fechaIngreso))
            {
                Mensaje = "Campo fecha ingreso debe ser completado";
            }

            //validación para renuncia
            if (string.IsNullOrEmpty(obj.fechaRenuncia) || string.IsNullOrWhiteSpace(obj.fechaRenuncia))
            {
                Mensaje = "Campo fecha renuncia debe ser completado";
            }

            //validación para contrato
            if (string.IsNullOrEmpty(obj.tipoContrato) || string.IsNullOrWhiteSpace(obj.tipoContrato))
            {
                Mensaje = "Campo tipo de contrato debe ser completado";
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

        //método de editar
        public bool Editar(detallesLaborales obj, out string Mensaje)
        {
            //validación de campos vacíos
            Mensaje = string.Empty;

            if (string.IsNullOrEmpty(obj.codDetalles) || string.IsNullOrWhiteSpace(obj.codDetalles))
            {
                Mensaje = "Campo codigo debe ser completado";
            }

            if (string.IsNullOrEmpty(obj.fechaIngreso) || string.IsNullOrWhiteSpace(obj.fechaIngreso))
            {
                Mensaje = "Campo fecha ingreso debe ser completado";
            }

            //validación para fecha
            if (string.IsNullOrEmpty(obj.fechaRenuncia) || string.IsNullOrWhiteSpace(obj.fechaRenuncia))
            {
                Mensaje = "Campo fecha renuncia debe ser completado";
            }

            if (string.IsNullOrEmpty(obj.tipoContrato) || string.IsNullOrWhiteSpace(obj.tipoContrato))
            {
                Mensaje = "Campo tipo de contrato debe ser completado";
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

        //eliminar
        public bool Eliminar(int id, out string Mensaje)
        {
            return objcapaDatos.Eliminar(id, out Mensaje);
        }
    }
}
