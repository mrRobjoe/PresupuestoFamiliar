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
    public partial class WebForm3 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ListadoTransacciones();
            }
        }

        protected void ListadoTransacciones()
        {
            String strConnString = ConfigurationManager.ConnectionStrings["UHPRESUPUESTOConnectionString"].ConnectionString;
            SqlConnection con = new SqlConnection(strConnString);
            con.Open();
            SqlCommand command = new SqlCommand("sp_ConsultTransc", con);
            command.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(command);
            DataTable dt = new DataTable();
            da.Fill(dt);
            GridView3.DataSource = dt;
            GridView3.DataBind();
        }

        protected void bIngresar_Click(object sender, EventArgs e)
        {
            ClsTransaccion.SetTipoTransaccion(Convert.ToInt32(dTipoTransc.SelectedValue));
            ClsTransaccion.SetCorreo(tCorreo.Text);
            ClsTransaccion.SetDescrip(tDesc.Text);
            ClsTransaccion.SetMonto(float.Parse(tMonto.Text));
            //ClsTransaccion.SetFecha(tFecha.Text);
            if (ClsTransaccion.AgregarTransaccion())
            {
                ListadoTransacciones();
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Notify", "alert('Notification : Transacción no ha sido ingresada, verifíque los campos Tipo Transacción y Correo.');", true);
            }

        }

        protected void bBorrar_Click(object sender, EventArgs e)
        {
            ClsTransaccion.SetId(Convert.ToInt32(tId.Text));
            if (ClsTransaccion.BorrarTransaccion())
            {
                ListadoTransacciones();
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Notify", "alert('Notification : Transacción no ha sido borrada, verifíque el campo del ID.');", true);
            }
        }

        protected void bConsultar_Click(object sender, EventArgs e)
        {
            ConsultaTransaccion();
        }

        protected void ConsultaTransaccion()
        {
            String strConnString = ConfigurationManager.ConnectionStrings["UHPRESUPUESTOConnectionString"].ConnectionString;
            SqlConnection con = new SqlConnection(strConnString);
            con.Open();
            SqlCommand command = new SqlCommand("sp_ConsultarTransaccion", con);
            command.Parameters.Add(new SqlParameter("@Id", Convert.ToInt32(tId.Text)));
            command.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(command);
            DataTable dt = new DataTable();
            da.Fill(dt);
            GridView3.DataSource = dt;
            GridView3.DataBind();
        }

        protected void bModificar_Click(object sender, EventArgs e)
        {
            ClsTransaccion.SetId(Convert.ToInt32(tId.Text));
            ClsTransaccion.SetTipoTransaccion(Convert.ToInt32(dTipoTransc.SelectedValue));
            ClsTransaccion.SetCorreo(tCorreo.Text);
            ClsTransaccion.SetDescrip(tDesc.Text);
            ClsTransaccion.SetMonto(float.Parse(tMonto.Text));
            if (ClsTransaccion.ModificarTransaccion())
            {
                ListadoTransacciones();
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Notify", "alert('Notification : Transacción no ha sido modificada, verifíque el campo del id y los demás.');", true);
            }
        }

        protected void dTipoTransc_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}