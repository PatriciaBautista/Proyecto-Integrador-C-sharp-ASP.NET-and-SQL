using capaEntidad;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace capaDatos
{
    public class CD_Direccion
    {
        //listamos en la tabla de dirección
        public List<direccionEmpleado> Listar()
        {
            //listamos las direcciones entrayendo los datos directamente desde la capa entidad
            List<direccionEmpleado> lista = new List<direccionEmpleado>();
            try
            {
                //conexión a la Base de datos y consulta de los datos
                using (SqlConnection oconexion = new SqlConnection(Conexion.cn))
                {
                    string query = "SELECT idDireccion, codDireccion, sucursalEmpleado, paisEmpleado, estado, nombreCalle, coloniaEmpleado, codigoPostal, activoDireccion FROM direccionEmpleado";
                    SqlCommand cmd = new SqlCommand(query, oconexion);
                    cmd.CommandType = CommandType.Text;
                    oconexion.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(new direccionEmpleado()
                            {
                                idDireccion = Convert.ToInt32(dr["idDireccion"]),
                                codDireccion = dr["codDireccion"].ToString(),
                                sucursalEmpleado = dr["sucursalEmpleado"].ToString(),
                                paisEmpleado = dr["paisEmpleado"].ToString(),
                                estado = dr["estado"].ToString(),
                                nombreCalle = dr["nombreCalle"].ToString(),
                                coloniaEmpleado = dr["coloniaEmpleado"].ToString(),
                                codigoPostal = Convert.ToInt32(dr["codigoPostal"]),
                                activoDireccion = Convert.ToBoolean(dr["activoDireccion"])
                            }
                             );
                        }
                    }
                }
            }
            catch
            {
                lista = new List<direccionEmpleado>();
            }
            return lista;
        }

        //fin de la lista

        //iniciar el registro de nuevas direcciones de empleado
        public int Registrar(direccionEmpleado obj, out string Mensaje)
        {
            int idautogenerado = 0;
            Mensaje = string.Empty;
            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cn))
                {
                    //creamos la conexion y llamamos al procedimientos almacenado directamente des de la BD
                    //extraemos los datos de campa entidades clase direccionEmpleado ocupando los datos necesarios
                    SqlCommand cmd = new SqlCommand("sp_RegistrarDireccion", oconexion);
                    cmd.Parameters.AddWithValue("codDireccion", obj.codDireccion);
                    cmd.Parameters.AddWithValue("sucursalEmpleado", obj.sucursalEmpleado);
                    cmd.Parameters.AddWithValue("paisEmpleado", obj.paisEmpleado);
                    cmd.Parameters.AddWithValue("estado", obj.estado);
                    cmd.Parameters.AddWithValue("nombreCalle", obj.nombreCalle);
                    cmd.Parameters.AddWithValue("coloniaEmpleado", obj.coloniaEmpleado);
                    cmd.Parameters.AddWithValue("codigoPostal", obj.codigoPostal);
                    cmd.Parameters.AddWithValue("activoDireccion", obj.activoDireccion);
                    cmd.Parameters.Add("Resultado", SqlDbType.Int).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
                    cmd.CommandType = CommandType.StoredProcedure;

                    oconexion.Open();
                    cmd.ExecuteNonQuery();

                    idautogenerado = Convert.ToInt32(cmd.Parameters["Resultado"].Value);
                    Mensaje = cmd.Parameters["Mensaje"].Value.ToString();
                }
            }
            catch (Exception ex)
            {
                idautogenerado = 0;
                Mensaje = ex.Message;
            }
            return idautogenerado;
        }//fin del registro de dirección

        //inicio de editar direcciones
        public bool Editar(direccionEmpleado obj, out string Mensaje)
        {
            bool resultado = false;
            Mensaje = string.Empty;

            try
            {//conexion a la base de datos
                using (SqlConnection oconexion = new SqlConnection(Conexion.cn))
                {//llamado del procedimiento almacenado y de la capa entidades con los campos necesarios
                    SqlCommand cmd = new SqlCommand("sp_ActualizarDireccion", oconexion);
                    cmd.Parameters.AddWithValue("idDireccion", obj.idDireccion);
                    cmd.Parameters.AddWithValue("codDireccion", obj.codDireccion);
                    cmd.Parameters.AddWithValue("sucursalEmpleado", obj.sucursalEmpleado);
                    cmd.Parameters.AddWithValue("paisEmpleado", obj.paisEmpleado);
                    cmd.Parameters.AddWithValue("estado", obj.estado);
                    cmd.Parameters.AddWithValue("nombreCalle", obj.nombreCalle);
                    cmd.Parameters.AddWithValue("coloniaEmpleado", obj.coloniaEmpleado);
                    cmd.Parameters.AddWithValue("codigoPostal", obj.codigoPostal);
                    cmd.Parameters.AddWithValue("activoDireccion", obj.activoDireccion);
                    cmd.Parameters.Add("Resultado", SqlDbType.Bit).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
                    cmd.CommandType = CommandType.StoredProcedure;

                    oconexion.Open();
                    cmd.ExecuteNonQuery();

                    resultado = Convert.ToBoolean(cmd.Parameters["Resultado"].Value);
                    Mensaje = cmd.Parameters["Mensaje"].Value.ToString();
                }
            }
            catch (Exception ex)
            {
                resultado = false;
                Mensaje = ex.Message;
            }
            return resultado;
        }


        //fin de editar direcciones

        //inicio del ciclo eliminar
        public bool Eliminar(int id, out string Mensaje)
        {
            bool resultado = false;
            Mensaje = string.Empty;

            try
            {
                //conexión a la base de datos
                using (SqlConnection oconexion = new SqlConnection(Conexion.cn))
                {
                    //llamado del procedimiento eliminar dirección
                    SqlCommand cmd = new SqlCommand("sp_EliminarDireccion", oconexion);
                    cmd.Parameters.AddWithValue("idDireccion", id);
                    cmd.Parameters.Add("Resultado", SqlDbType.Bit).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
                    cmd.CommandType = CommandType.StoredProcedure;

                    oconexion.Open();
                    cmd.ExecuteNonQuery();

                    resultado = Convert.ToBoolean(cmd.Parameters["Resultado"].Value);
                    Mensaje = cmd.Parameters["Mensaje"].Value.ToString();
                }
            }
            catch (Exception ex)
            {
                resultado = false;
                Mensaje = ex.Message;
            }
            return resultado;
        }
        //fin de eliminar

    }
}
