using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Web;

namespace Examen3Progra2
{
    public class ClsEncuesta
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public string genero { get; set; }
        public string edad { get; set; }
        public string correo { get; set; }
        public string partidop { get; set; }
        public static List<ClsEncuesta> encuestas = new List<ClsEncuesta>();
        public ClsEncuesta(int id, string nombre, string genero, string edad, string correo, string partidop)
        {
            this.id = id;
            this.nombre = nombre;
            this.genero = genero;
            this.edad = edad;
            this.correo = correo;
            this.partidop = partidop;
        }
        public ClsEncuesta()
        {

        }
        public static int AgregarEncuesta(string nombre, string genero, string edad, string correo, string partidop)
        {
            int retorno = 0;
            SqlConnection conn = new SqlConnection();
            try
            {
                using (conn = DBconexion.obtenerConexion())
                {
                    SqlCommand cmd = new SqlCommand("AgregarEncuesta", conn)
                    {
                        CommandType = System.Data.CommandType.StoredProcedure
                    };
                    cmd.Parameters.Add(new SqlParameter("@nombre", nombre));
                    cmd.Parameters.Add(new SqlParameter("@genero", genero));
                    cmd.Parameters.Add(new SqlParameter("@edad", edad));
                    cmd.Parameters.Add(new SqlParameter("@correo", correo));
                    cmd.Parameters.Add(new SqlParameter("@partidop", partidop));
                    retorno = cmd.ExecuteNonQuery();
                }
            }
            catch (SqlException ex)
            {
                retorno = -1;
            }
            finally { conn.Close(); }
            return retorno;
        }
        public static int Rencuestas(string tipoOperacion)
        {
            int retorno = 0;
            SqlConnection conn = new SqlConnection();
            try
            {
                using (conn = DBconexion.obtenerConexion())
                {
                    SqlCommand cmd = new SqlCommand("MenuReportes", conn)
                    {
                        CommandType = System.Data.CommandType.StoredProcedure
                    };
                    cmd.Parameters.Add(new SqlParameter("@operacion", tipoOperacion));

                    retorno = cmd.ExecuteNonQuery();
                }
            }
            catch (SqlException ex)
            {
                retorno = -1;
            }
            finally
            {
                conn.Close();
            }

            return retorno;
        }

        public static List<ClsEncuesta> ObtenerEncuesta()
        {
            int retorno = 0;
            SqlConnection conn = new SqlConnection();
            try
            {
                using (conn = DBconexion.obtenerConexion())
                {
                    SqlCommand cmd = new SqlCommand("ReporteEncuesta", conn)
                    {
                        CommandType = System.Data.CommandType.StoredProcedure
                    };
                    retorno = cmd.ExecuteNonQuery();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            ClsEncuesta encuesta = new ClsEncuesta();
                            encuesta.id = reader.GetInt32(0);
                            encuesta.nombre = reader.GetString(1);
                            encuesta.genero = reader.GetString(1);
                            encuesta.edad = reader.GetString(1);
                            encuesta.correo = reader.GetString(1);
                            encuesta.partidop = reader.GetString(1);
                            encuestas.Add(encuesta);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                return encuestas;
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }

            return encuestas;
        }


    }

}