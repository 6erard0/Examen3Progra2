using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Examen3Progra2
{
    public class DBconexion
    {
        public static SqlConnection obtenerConexion()
        {
            string s = ConfigurationManager.ConnectionStrings["EncuestaConnectionString"].ConnectionString;
            SqlConnection conexion = new SqlConnection(s);
            conexion.Open();
            return conexion;
        }
    }
}