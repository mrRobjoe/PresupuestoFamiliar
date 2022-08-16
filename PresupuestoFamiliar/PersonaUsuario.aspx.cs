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
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ListadoPersonas();
                ListadoUsuarios();
            }

        }

        protected void ListadoPersonas()
        {
            String strConnString = ConfigurationManager.ConnectionStrings["UHPRESUPUESTOConnectionString"].ConnectionString;
            SqlConnection con = new SqlConnection(strConnString);
            con.Open();
            SqlCommand command = new SqlCommand("sp_ConsultPersona", con);
            command.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(command);
            DataTable dt = new DataTable();
            da.Fill(dt);
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }
        protected void ListadoUsuarios()
        {
            String strConnString = ConfigurationManager.ConnectionStrings["UHPRESUPUESTOConnectionString"].ConnectionString;
            SqlConnection con = new SqlConnection(strConnString);
            con.Open();
            SqlCommand command = new SqlCommand("sp_ConsultUser", con);
            command.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(command);
            DataTable dt = new DataTable();
            da.Fill(dt);
            GridView2.DataSource = dt;
            GridView2.DataBind();
        }

        //Consulta para PERSONA.
        protected void ConsultaPersona()
        {
            String strConnString = ConfigurationManager.ConnectionStrings["UHPRESUPUESTOConnectionString"].ConnectionString;
            SqlConnection con = new SqlConnection(strConnString);
            con.Open();
            SqlCommand command = new SqlCommand("sp_ConsultarPersona", con);
            command.Parameters.Add(new SqlParameter("@cedula", tCedula.Text));
            command.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(command);
            DataTable dt = new DataTable();
            da.Fill(dt);
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }

        //Consulta para USUARIO.
        protected void ConsultaUsuario()
        {
            String strConnString = ConfigurationManager.ConnectionStrings["UHPRESUPUESTOConnectionString"].ConnectionString;
            SqlConnection con = new SqlConnection(strConnString);
            con.Open();
            SqlCommand command = new SqlCommand("sp_ConsultarUsuario", con);
            command.Parameters.Add(new SqlParameter("@correo", tCorreo.Text));
            command.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter daa = new SqlDataAdapter(command);
            DataTable dtt = new DataTable();
            daa.Fill(dtt);
            GridView2.DataSource = dtt;
            GridView2.DataBind();
        }

        protected void dTipoUser_SelectedIndexChanged(object sender, EventArgs e)
        {

        }


        //Boton para registrar a una nueva PERSONA y un nuevo USUARIO.

        protected void bRegister_Click(object sender, EventArgs e)
        {
            ClsPersonaUsuario.SetCedula(tCedula.Text);
            ClsPersonaUsuario.SetNombre(tNombre.Text);
            ClsPersonaUsuario.SetApellido(tApellido.Text);
            ClsPersonaUsuario.SetDireccion(tDireccion.Text);
            ClsPersonaUsuario.SetTelefono(tTelefono.Text);

            ClsPersonaUsuario.SetCorreo(tCorreo.Text);
            ClsPersonaUsuario.SetTipoUser(Convert.ToInt32(dTipoUser.SelectedValue));
            ClsPersonaUsuario.SetClave(tClave.Text);

            // cambiar mensajes 
            if (ClsPersonaUsuario.RegistroPersonaUser())
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Notify", "alert('Notification: Datos ingresados con éxito');", true);
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Notify", "alert('Notification: Error, los datos no han sido ingresados');", true);
            }
            return;
        }


        //Botones para modificar, borrar y consultar a PERSONA.

        protected void bModificarPerson_Click1(object sender, EventArgs e)
        {
            ClsPersona.SetId(Convert.ToInt32(tId.Text));
            ClsPersona.SetCedula(tCedula.Text);
            ClsPersona.SetNombre(tNombre.Text);
            ClsPersona.SetApellido(tApellido.Text);
            ClsPersona.SetDireccion(tDireccion.Text);
            ClsPersona.SetTelefono(tTelefono.Text);
            if (ClsPersona.ModificarPersona())
            {
                ListadoPersonas();
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Notify", "alert('Notification : Persona no ha sido modificada, intentelo de nuevo. ');", true);
            }
        }

        protected void bConsultarPerson_Click(object sender, EventArgs e)
        {
            ConsultaPersona();
        }

        protected void bBorrarPerson_Click(object sender, EventArgs e)
        {
            ClsPersona.SetId(Convert.ToInt32(tId.Text));
            if (ClsPersona.BorrarPersona())
            {
                ListadoPersonas();
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Notify", "alert('Notification : Persona no ha sido Borrada, verifiquelo de nuevo');", true);
            }

        }


        //Botones para modificar, borrar y consultar a USUARIO.

        protected void bModificarUser_Click(object sender, EventArgs e)
        {
            ClsUsuarios.SetCorreo(tCorreo.Text);
            ClsUsuarios.SetClave(tClave.Text);
            ClsUsuarios.SetTipoUser(Convert.ToInt32(dTipoUser.SelectedValue));
            if (ClsUsuarios.ModificarUsuario())
            {
                ListadoUsuarios();
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Notify", "alert('Notification : Usuario no ha sido modificado, verifiquelo de nuevo');", true);
            }
        }

        protected void bConsultarUser_Click(object sender, EventArgs e)
        {
            ConsultaUsuario();
        }

        protected void bBorrarUser_Click(object sender, EventArgs e)
        {
            ClsUsuarios.SetCorreo(tCorreo.Text);
            if (ClsUsuarios.BorrarUsuario())
            {
                ListadoUsuarios();
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Notify", "alert('Notification : Usuario no ha sido Borrado, verifiquelo de nuevo');", true);
            }
        }

    }
}