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
        public List<detallesLaborales> Listar()
        {
            List<detallesLaborales> lista = new List<detallesLaborales>();
            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cn))
                {
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

        //editar detalle
        public int Registrar(detallesLaborales obj, out string Mensaje)
        {
            int idautogenerado = 0;
            Mensaje = string.Empty;
            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cn))
                {
                    SqlCommand cmd = new SqlCommand("sp_RegistrarDetalles", oconexion);
                    cmd.Parameters.AddWithValue("codDetalles", obj.codDetalles);
                    cmd.Parameters.AddWithValue("fechaIngreso", obj.fechaIngreso);
                    cmd.Parameters.AddWithValue("fechaRenuncia", obj.fechaRenuncia);
                    cmd.Parameters.AddWithValue("tipoContrato", obj.tipoContrato);
                    cmd.Parameters.AddWithValue("activoDetalle", obj.activoDetalle);
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
        }

        //método de editar
        public bool Editar(detallesLaborales obj, out string Mensaje)
        {
            bool resultado = false;
            Mensaje = string.Empty;

            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cn))
                {
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
        //método eliminar detalles
        public bool Eliminar(int id, out string Mensaje)
        {
            bool resultado = false;
            Mensaje = string.Empty;

            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cn))
                {
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
