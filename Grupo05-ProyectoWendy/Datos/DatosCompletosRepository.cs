using Grupo05_ProyectoWendy.Entidades;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Grupo05_ProyectoWendy.Datos
{
    public class DatosCompletosRepository
    {
        public DatosCompletos ObtenerDatosCompletos()
        {
            DatosCompletos datosCompletos = new DatosCompletos();
            datosCompletos.Empleados = new List<EmpleadoWendy>();
            datosCompletos.Direccion = new List<DireccionEmpleado>();
            datosCompletos.DetalleLaboral = new List<DetallesLaborales>();

            // Obtener la cadena de conexión desde el Web.config
            string connectionString = ConfigurationManager.ConnectionStrings["cadena"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // Abre la conexión
                connection.Open();

                // Consulta para obtener los datos de las tres tablas mediante JOIN
                string query = @"
                SELECT *
                FROM empleadoWendy AS e
                INNER JOIN direccionEmpleado AS d ON e.idDireccion = d.idDireccion
                INNER JOIN detallesLaborales AS dl ON e.idDetalleLaboral = dl.idDetalleLaboral
            ";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    // Ejecuta la consulta y obtiene el resultado
                    SqlDataReader reader = command.ExecuteReader();

                    // Verifica si hay filas en el resultado
                    if (reader.HasRows)
                    {
                        // Lee cada fila del resultado
                        while (reader.Read())
                        {
                            // Datos de la tabla empleadoWendy
                            EmpleadoWendy empleado = new EmpleadoWendy();
                            empleado.idEmpleadoWendy = (int)reader["idEmpleadoWendy"];
                            empleado.identificadorPersonal = (string)reader["identificadorPersonal"];
                            empleado.nombreEmpleado = (string)reader["nombreEmpleado"];
                            empleado.cargoEmpleado = (string)reader["cargoEmpleado"];
                            empleado.edadEmpleado = (int)reader["edadEmpleado"];
                            empleado.monto = (decimal)reader["monto"];
                            datosCompletos.Empleados.Add(empleado);

                            // Datos de la tabla direccionEmpleado
                            DireccionEmpleado direccion = new DireccionEmpleado();
                            direccion.idDireccion = (int)reader["idDireccion"];
                            direccion.sucursalEmpleado = (string)reader["sucursalEmpleado"];
                            direccion.paisEmpleado = (string)reader["paisEmpleado"];
                            direccion.estado = (string)reader["estado"];
                            datosCompletos.Direccion.Add(direccion);

                            // Datos de la tabla detallesLaborales
                            DetallesLaborales detallesLaborales = new DetallesLaborales();
                            detallesLaborales.idDetalleLaboral = (int)reader["idDetalleLaboral"];
                            detallesLaborales.fechaIngreso = (string)reader["fechaIngreso"];
                            detallesLaborales.fechaRenuncia = (string)reader["fechaRenuncia"];
                            detallesLaborales.tipoContrato = (string)reader["tipoContrato"];
                            detallesLaborales.fechaEmision = (DateTime)reader["fechaEmision"];
                            datosCompletos.DetalleLaboral.Add(detallesLaborales);
                        }
                    }

                    // Cierra el lector
                    reader.Close();
                }

                // Cierra la conexión
                connection.Close();
            }

            return datosCompletos;
        }
    }
}