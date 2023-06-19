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
    public class CD_DetallesLaborales
    {
        //se crea la lista y consulta para listar los datos almacenados direcctamente desde la BD
        public List<detallesLaborales> Listar()
        {
            List<detallesLaborales> lista = new List<detallesLaborales>();
            try
            {
                //se crea la conexión a la base de datos
                using (SqlConnection oconexion = new SqlConnection(Conexion.cn))
                {
                    //consulta directamente de la tabla detalles, se extraen los datos necesarios
                    string query = "select codDetalles, idDetalleLaboral, fechaIngreso, fechaRenuncia,tipoContrato, activoDetalle from detallesLaborales";
                    SqlCommand cmd = new SqlCommand(query, oconexion);
                    cmd.CommandType = CommandType.Text;
                    oconexion.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(new detallesLaborales()
                                {
                                    idDetalleLaboral = Convert.ToInt32(dr["idDetalleLaboral"]),
                                    codDetalles = dr["codDetalles"].ToString(),
                                    fechaIngreso = dr["fechaIngreso"].ToString(),
                                    fechaRenuncia = dr["fechaRenuncia"].ToString(),
                                    tipoContrato = dr["tipoContrato"].ToString(),
                                    activoDetalle = Convert.ToBoolean(dr["activoDetalle"])
                                }
                             );
                        }
                    }
                }
            }
            catch
            {
                lista = new List<detallesLaborales>();
            }
            return lista;
        }

        //registrar detalle 
        public int Registrar(detallesLaborales obj, out string Mensaje)
        {
            //variable para captar el id de forma automatica en la BD
            int idautogenerado = 0;
            Mensaje = string.Empty;
            try
            {
                //conexion a la BD
                using (SqlConnection oconexion = new SqlConnection(Conexion.cn))
                {
                    //seleccionamos el procedimiento almacenado directamente desde la BD
                    SqlCommand cmd = new SqlCommand("sp_RegistrarDetalles", oconexion);
                    cmd.Parameters.AddWithValue("codDetalles", obj.codDetalles);
                    cmd.Parameters.AddWithValue("fechaIngreso", obj.fechaIngreso);
                    cmd.Parameters.AddWithValue("fechaRenuncia", obj.fechaRenuncia);
                    cmd.Parameters.AddWithValue("tipoContrato", obj.tipoContrato);
                    cmd.Parameters.AddWithValue("activoDetalle", obj.activoDetalle);
                    cmd.Parameters.Add("Resultado", SqlDbType.Int).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
                    cmd.CommandType = CommandType.StoredProcedure;

                    oconexion.Open();//abrimos conexion
                    cmd.ExecuteNonQuery();

                    idautogenerado = Convert.ToInt32(cmd.Parameters["Resultado"].Value);//verificamos que los datos no sean null
                    Mensaje = cmd.Parameters["Mensaje"].Value.ToString();
                }
            }
            catch (Exception ex)
            {
                idautogenerado = 0;
                Mensaje = ex.Message;
            }
            return idautogenerado;
        }

        //método de editar, con parametros
        public bool Editar(detallesLaborales obj, out string Mensaje)
        {
            bool resultado = false;
            Mensaje = string.Empty;

            try
            {//conexión a la base de datos
                using (SqlConnection oconexion = new SqlConnection(Conexion.cn))
                {
                    //llamamos al procedimiento almacenados para editar los datos juntos con los
                    //campos o atributos que utilizaremos extraidos desde la capa entiedades clase detallesLaborales
                    SqlCommand cmd = new SqlCommand("sp_ActualizarDetalles", oconexion);
                    cmd.Parameters.AddWithValue("idDetalleLaboral", obj.idDetalleLaboral);
                    cmd.Parameters.AddWithValue("codDetalles", obj.codDetalles);
                    cmd.Parameters.AddWithValue("fechaIngreso", obj.fechaIngreso);
                    cmd.Parameters.AddWithValue("fechaRenuncia", obj.fechaRenuncia);
                    cmd.Parameters.AddWithValue("tipoContrato", obj.tipoContrato);
                    cmd.Parameters.AddWithValue("activoDetalle", obj.activoDetalle);
                    cmd.Parameters.Add("Resultado", SqlDbType.Bit).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
                    cmd.CommandType = CommandType.StoredProcedure;

                    oconexion.Open();//abrimos la conexión a la BD
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
        //método eliminar detalles, extracción de parametros
        public bool Eliminar(int id, out string Mensaje)
        {
            bool resultado = false;
            Mensaje = string.Empty;

            try
            {
                //conexion a la Base de datos
                using (SqlConnection oconexion = new SqlConnection(Conexion.cn))
                {
                    //se extrae el procedimiento almacenado para eliminar el dato de la tabla y al mismo tiempo de la BD
                    SqlCommand cmd = new SqlCommand("sp_EliminarDetalle", oconexion);
                    cmd.Parameters.AddWithValue("idDetalleLaboral", id);
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
    }
}
