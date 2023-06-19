using capaEntidad;
using Grupo05_ProyectoWendy.Datos;
using Grupo05_ProyectoWendy.Entidades;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Grupo05_ProyectoWendy.Negocio
{
    public class EmpleadoWendyNegocio
    {
        private EmpleadoWendyDatos empleadoWendyDatos;
        public EmpleadoWendyNegocio()
        {
            empleadoWendyDatos = new EmpleadoWendyDatos();
        }

        public List<EmpleadoWendy> ObtenerTodosLosEmpleados()
        {
            return empleadoWendyDatos.ObtenerTodosLosEmpleados();
        }

        //Inicia el método para guardar empleado
        public void CrearEmpleado(EmpleadoWendy empleado)
        {
            // Validar los datos del empleado si es necesario
            if (empleado == null)
            {
                throw new ArgumentNullException(nameof(empleado), "El objeto EmpleadoWendy no puede ser nulo.");
            }

            // Validar campos obligatorios
            if (string.IsNullOrEmpty(empleado.nombreEmpleado))
            {
                throw new ArgumentException("El nombre del empleado es obligatorio.", nameof(empleado.nombreEmpleado));
            }

            if (string.IsNullOrEmpty(empleado.cargoEmpleado))
            {
                throw new ArgumentException("El cargo del empleado es obligatorio.", nameof(empleado.cargoEmpleado));
            }

            // Validar reglas de negocio adicionales
            if (empleado.edadEmpleado <= 0)
            {
                throw new ArgumentException("La edad del empleado debe ser un valor mayor a cero.", nameof(empleado.edadEmpleado));
            }

            // Realizar lógica adicional de validación si es necesario
            // ...

            // Luego, puedes llamar al método correspondiente en la capa de datos (EmpleadoWendyDatos)
            empleadoWendyDatos.CrearEmpleado(empleado);
        }
        //Finaliza el método para guardar empleado

        //inicia elmétodo de editar empleado
        public EmpleadoWendy ObtenerEmpleadoPorId(int idEmpleado)
        {
            // Lógica para obtener el empleado por su ID utilizando el objeto empleadoWendyDatos
            EmpleadoWendy empleado = empleadoWendyDatos.ObtenerEmpleadoPorId(idEmpleado);

            if (empleado == null)
            {
                throw new ArgumentException("No se encontró ningún empleado con el ID especificado.");
            }

            return empleado;
        }

        public void ActualizarEmpleado(EmpleadoWendy empleado)
        {
            if (empleado == null)
            {
                throw new ArgumentNullException(nameof(empleado));
            }

            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["cadena"].ConnectionString))
            {
                connection.Open();

                // Verificar si el empleado existe en la base de datos
                string existenciaQuery = "SELECT COUNT(*) FROM empleadoWendy WHERE idEmpleadoWendy = @idEmpleadoWendy";
                SqlCommand existenciaCommand = new SqlCommand(existenciaQuery, connection);
                existenciaCommand.Parameters.AddWithValue("@idEmpleadoWendy", empleado.idEmpleadoWendy);

                int existencia = (int)existenciaCommand.ExecuteScalar();
                if (existencia == 0)
                {
                    throw new ArgumentException("El empleado especificado no existe en la base de datos.");
                }

                // Actualizar los datos del empleado
                string updateQuery = "UPDATE empleadoWendy SET identificadorPersonal = @identificadorPersonal, nombreEmpleado = @nombreEmpleado, edadEmpleado = @edadEmpleado, cargoEmpleado = @cargoEmpleado, telefonoEmpleado = @telefonoEmpleado, sexoEmpleado = @sexoEmpleado, monto = @monto, activoEmpleado = @activoEmpleado, idDireccion = @idDireccion, idDetalleLaboral = @idDetalleLaboral WHERE idEmpleadoWendy = @idEmpleadoWendy";
                SqlCommand updateCommand = new SqlCommand(updateQuery, connection);
                updateCommand.Parameters.AddWithValue("@identificadorPersonal", empleado.identificadorPersonal);
                updateCommand.Parameters.AddWithValue("@nombreEmpleado", empleado.nombreEmpleado);
                updateCommand.Parameters.AddWithValue("@edadEmpleado", empleado.edadEmpleado);
                updateCommand.Parameters.AddWithValue("@cargoEmpleado", empleado.cargoEmpleado);
                updateCommand.Parameters.AddWithValue("@telefonoEmpleado", empleado.telefonoEmpleado);
                updateCommand.Parameters.AddWithValue("@sexoEmpleado", empleado.sexoEmpleado);
                updateCommand.Parameters.AddWithValue("@monto", empleado.monto);
                updateCommand.Parameters.AddWithValue("@activoEmpleado", empleado.activoEmpleado);
                updateCommand.Parameters.AddWithValue("@idDireccion", empleado.idDireccion);
                updateCommand.Parameters.AddWithValue("@idDetalleLaboral", empleado.idDetalleLaboral);
                updateCommand.Parameters.AddWithValue("@idEmpleadoWendy", empleado.idEmpleadoWendy);

                updateCommand.ExecuteNonQuery();
                empleadoWendyDatos.ActualizarEmpleado(empleado);
            }
        }
        //Finaliza él método de editar empleado

        //inicia el método de verificación de empleado
        public void EliminarEmpleado(int idEmpleado)
        {
            // Verificar si el empleado existe antes de eliminarlo
            EmpleadoWendy empleado = empleadoWendyDatos.ObtenerEmpleadoPorId(idEmpleado);
            if (empleado == null)
            {
                throw new ArgumentException("El empleado especificado no existe en la base de datos.");
            }

            // Realizar cualquier validación adicional antes de eliminar al empleado

            // Eliminar al empleado de la base de datos
            empleadoWendyDatos.EliminarEmpleado(idEmpleado);
        }

        //finaliza el método de verificación de empleado


        

    }
}