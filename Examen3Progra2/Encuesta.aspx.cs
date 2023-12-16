using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Examen3Progra2
{
    public partial class Encuesta : System.Web.UI.Page
    {
        public static List<ClsEncuesta> encuestas = new List<ClsEncuesta>();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarEncuestas();
            }
        }
        private void CargarEncuestas()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["EncuestaConnectionString"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "ReporteEncuesta";
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                GridView1.DataSource = dataTable;
                GridView1.DataBind();
            }
        }

        protected void TextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        protected void TextBox3_TextChanged(object sender, EventArgs e)
        {

        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        public void alertas(String texto)
        {
            string message = texto;
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append("<script type = 'text/javascript'>");
            sb.Append("window.onload=function(){");
            sb.Append("alert('");
            sb.Append(message);
            sb.Append("')};");
            sb.Append("</script>");
            ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", sb.ToString());

        }

        protected void BAgregar_Click(object sender, EventArgs e)
        {
            int resultado = ClsEncuesta.AgregarEncuesta(Tnombre.Text, DropDownList3.Text, TEdad.Text, TCorreo.Text, DropDownList1.Text);
            if (resultado > 0)
            {
                alertas("Encuesta agregada con exito");

            }
            else
            {
                alertas("Error al ingresar Usuario");
            }
        }

        protected void BResultados_Click(object sender, EventArgs e)
        {
            CargarEncuestas();
        }

        protected void EXAMENFINAL_Selecting(object sender, SqlDataSourceSelectingEventArgs e)
        {

        }

        protected void BMostrarGeneros_Click(object sender, EventArgs e)
        {
            string tipoOperacion = Toperacion.Text.Trim();
            int resultado = ClsEncuesta.Rencuestas(tipoOperacion);

            if (resultado > 0)
            {
                alertas("Reporte Generado");
                GridView2.DataSource = resultado;
                GridView2.DataBind();

            }
            else
            {


            }
        }
    }
}
