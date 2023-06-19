using Grupo05_ProyectoWendy.Entidades;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Grupo05_ProyectoWendy.Datos
{
    public class EmpleadoWendyDatos
    {
        private string connectionString;
        public EmpleadoWendyDatos()
        {
            connectionString = ConfigurationManager.ConnectionStrings["cadena"].ConnectionString;
        }
        public List<EmpleadoWendy> ObtenerTodosLosEmpleados()
        {
            List<EmpleadoWendy> empleados = new List<EmpleadoWendy>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM empleadoWendy";

                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    EmpleadoWendy empleado = new EmpleadoWendy()
                    {
                        idEmpleadoWendy = (int)reader["idEmpleadoWendy"],
                        identificadorPersonal = (string)reader["identificadorPersonal"],
                        nombreEmpleado = (string)reader["nombreEmpleado"],
                        edadEmpleado = (int)reader["edadEmpleado"],
                        cargoEmpleado = (string)reader["cargoEmpleado"],
                        telefonoEmpleado = (string)reader["telefonoEmpleado"],
                        sexoEmpleado = (string)reader["sexoEmpleado"],
                        monto = (decimal)reader["monto"],
                        activoEmpleado = (bool)reader["activoEmpleado"],
                        idDireccion = (int)reader["idDireccion"],
                        idDetalleLaboral = (int)reader["idDetalleLaboral"]
                    };

                    empleados.Add(empleado);
                }

                reader.Close();
            }

            return empleados;
        }

        //inicia el guardado de datos
        public void CrearEmpleado(EmpleadoWendy empleado)
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["cadena"].ConnectionString))
            {
                string query = "INSERT INTO empleadoWendy (identificadorPersonal, nombreEmpleado, edadEmpleado, cargoEmpleado, telefonoEmpleado, sexoEmpleado, monto, activoEmpleado, idDireccion, idDetalleLaboral) " +
                               "VALUES (@identificadorPersonal, @nombreEmpleado, @edadEmpleado, @cargoEmpleado, @telefonoEmpleado, @sexoEmpleado, @monto, @activoEmpleado, @idDireccion, @idDetalleLaboral)";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@identificadorPersonal", empleado.identificadorPersonal);
                command.Parameters.AddWithValue("@nombreEmpleado", empleado.nombreEmpleado);
                command.Parameters.AddWithValue("@edadEmpleado", empleado.edadEmpleado);
                command.Parameters.AddWithValue("@cargoEmpleado", empleado.cargoEmpleado);
                command.Parameters.AddWithValue("@telefonoEmpleado", empleado.telefonoEmpleado);
                command.Parameters.AddWithValue("@sexoEmpleado", empleado.sexoEmpleado);
                command.Parameters.AddWithValue("@monto", empleado.monto);
                command.Parameters.AddWithValue("@activoEmpleado", empleado.activoEmpleado);
                command.Parameters.AddWithValue("@idDireccion", empleado.idDireccion);
                command.Parameters.AddWithValue("@idDetalleLaboral", empleado.idDetalleLaboral);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }
        //finaliza el guardado de datos de empleado

        //inicia la edicion de datos

        public EmpleadoWendy ObtenerEmpleadoPorId(int idEmpleado)
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["cadena"].ConnectionString))
            {
                connection.Open();

                string query = "SELECT * FROM empleadoWendy WHERE idEmpleadoWendy = @idEmpleado";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@idEmpleado", idEmpleado);

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        // Crear un objeto EmpleadoWendy con los datos del lector
                        EmpleadoWendy empleado = new EmpleadoWendy
                        {
                            // Asignar los valores de las columnas del lector al objeto EmpleadoWendy
                            idEmpleadoWendy = (int)reader["idEmpleadoWendy"],
                            identificadorPersonal = (string)reader["identificadorPersonal"],
                            nombreEmpleado = (string)reader["nombreEmpleado"],
                            edadEmpleado = (int)reader["edadEmpleado"],
                            cargoEmpleado = (string)reader["cargoEmpleado"],
                            telefonoEmpleado = (string)reader["telefonoEmpleado"],
                            sexoEmpleado = (string)reader["sexoEmpleado"],
                            monto = (decimal)reader["monto"],
                            activoEmpleado = (bool)reader["activoEmpleado"],
                            idDireccion = (int)reader["idDireccion"],
                            idDetalleLaboral = (int)reader["idDetalleLaboral"]
                        };

                        return empleado;
                    }
                }
            }

            return null; // Si no se encuentra el empleado, retornar null
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
            }
        }
        //finaliza la edicion de datos

        //inicia el método de eliminar empleado si existe
        public bool ExisteEmpleado(int idEmpleado)
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["cadena"].ConnectionString))
            {
                connection.Open();

                string query = "SELECT COUNT(*) FROM empleadoWendy WHERE idEmpleadoWendy = @idEmpleado";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@idEmpleado", idEmpleado);

                int count = (int)command.ExecuteScalar();

                return count > 0;
            }
        }

        //finaliza el método de eliminar empleado si existe

        //Inicia logica para eliminar definitivamente al empleado
        public void EliminarEmpleado(int idEmpleado)
        {
            // Verificar si el empleado existe antes de eliminarlo
            if (!ExisteEmpleado(idEmpleado))
            {
                throw new ArgumentException("El empleado especificado no existe en la base de datos.");
            }

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string deleteQuery = "DELETE FROM empleadoWendy WHERE idEmpleadoWendy = @idEmpleado";
                SqlCommand command = new SqlCommand(deleteQuery, connection);
                command.Parameters.AddWithValue("@idEmpleado", idEmpleado);

                command.ExecuteNonQuery();
            }
        }
        //fin de la logica para eliminar definitivamente al empleado
    }
}