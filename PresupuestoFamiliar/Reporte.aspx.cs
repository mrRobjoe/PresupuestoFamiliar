using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PresupuestoFamiliar
{
    public partial class WebForm4 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

       protected void ReporteTransacciones()
        {
            String strConnString = ConfigurationManager.ConnectionStrings["UHPRESUPUESTOConnectionString"].ConnectionString;
            SqlConnection con = new SqlConnection(strConnString);
            con.Open();
            SqlCommand command = new SqlCommand("ConsultaTranFilt", con);
            command.Parameters.Add(new SqlParameter("@tipoTran", dTipoTran.SelectedValue));
            command.Parameters.Add(new SqlParameter("@user", tUser.Text));
            command.Parameters.Add(new SqlParameter("@mes", dMes.SelectedValue));
            command.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(command);
            DataTable dt = new DataTable();
            da.Fill(dt);
            Gridview4.DataSource = dt;
            Gridview4.DataBind();
        }

        protected void bReporte_Click(object sender, EventArgs e)
        {
            ReporteTransacciones();
        }
    }
}