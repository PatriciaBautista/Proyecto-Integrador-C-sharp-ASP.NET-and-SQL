﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using capaDatos;
using capaEntidad;

namespace capaNegocio
{
    public class CN_Usuario
    {
        private CD_Usuarios objcapaDatos = new CD_Usuarios();

        //método para devolver la lista de los admid de la capa cd usuarios
        public List<Usuario> Listar()
        {
            return objcapaDatos.Listar();
        }
        //método de registrar
        public int Registrar(Usuario obj, out string Mensaje)
        {
            Mensaje = string.Empty;
            if (string.IsNullOrEmpty(obj.nombreUsuario) || string.IsNullOrWhiteSpace(obj.nombreUsuario))
            {
                Mensaje = "Campo Nombre debe ser completado";
            }

            //validación para apellidos
            if (string.IsNullOrEmpty(obj.apellidoUsuario) || string.IsNullOrWhiteSpace(obj.apellidoUsuario))
            {
                Mensaje = "Campo Apellido debe ser completado";
            }

            //validación para correo
            if (string.IsNullOrEmpty(obj.correo) || string.IsNullOrWhiteSpace(obj.correo))
            {
                Mensaje = "Campo Correo debe ser completado";
            }

            if (string.IsNullOrEmpty(Mensaje))
            {
                //aquí enviaremos el correo al usuario

                string clave = CN_Recursos.GenerarClave();
                string asunto = "Cuenta nueva";
                //mensaje que aparece en la bandeja de entrada del nuevo correo
                string mensaje_correo = "<h3>Su cuenta fue creada con éxito en el Sistema WENDY</h3></br><p>Nueva contraseña, (favor de no compartir): !clave!</p>";
                mensaje_correo = mensaje_correo.Replace("!clave!", clave);
                bool respuesta = CN_Recursos.EnviarCorreo(obj.correo, asunto, mensaje_correo);
                if (respuesta)
                {
                    obj.clave = CN_Recursos.ConvertirSha256(clave);
                    return objcapaDatos.Registrar(obj, out Mensaje);
                }
                else
                {
                    Mensaje = "Error al envia correo";
                    return 0;
                }
            }
            else
            {
                return 0;
            }

        }

        //método de editar
        public bool Editar(Usuario obj, out string Mensaje)
        {
            //validación de campos vacíos
            Mensaje = string.Empty;
            if (string.IsNullOrEmpty(obj.nombreUsuario) || string.IsNullOrWhiteSpace(obj.nombreUsuario))
            {
                Mensaje = "Campo Nombre debe ser completado";
            }

            //validación para apellidos
            if (string.IsNullOrEmpty(obj.apellidoUsuario) || string.IsNullOrWhiteSpace(obj.apellidoUsuario))
            {
                Mensaje = "Campo Apellido debe ser completado";
            }

            //validación para correo
            if (string.IsNullOrEmpty(obj.correo) || string.IsNullOrWhiteSpace(obj.correo))
            {
                Mensaje = "Campo Correo debe ser completado";
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


        public bool Eliminar(int id, out string Mensaje)
        {
            return objcapaDatos.Eliminar(id, out Mensaje);
        }

        //llamando el método de CD_usuarios
        public bool CambiarClave(int idUsuario, string nuevaClave, out string Mensaje)
        {
            return objcapaDatos.CambiarClave(idUsuario, nuevaClave, out Mensaje);
        }

        //reestablecer la clave
        public bool ReestablecerClave(int idUsuario, string correo, out string Mensaje)
        {
            Mensaje = string.Empty;
            string nuevaClave = CN_Recursos.GenerarClave();
            bool resultado = objcapaDatos.ReestablecerC(idUsuario, CN_Recursos.ConvertirSha256(nuevaClave), out Mensaje);

            if (resultado)
            {
                string asunto = "Su contraseña fue reestablecida";
                string mensaje_correo = "<h3>Su cuenta fue reestablecida con éxito en el Sistema WENDY</h3></br><p>Nueva contraseña, (favor de no compartir): !clave!</p>";
                mensaje_correo = mensaje_correo.Replace("!clave!", nuevaClave);
                bool respuesta = CN_Recursos.EnviarCorreo(correo, asunto, mensaje_correo);

                if (respuesta)
                {
                    return true;
                }
                else
                {
                    Mensaje = "Error al enviar correo";
                    return false;
                }

            }
            else
            {
                Mensaje = "Error al reestablecer contraseña";
                return false;
            }
        }

    }
}
