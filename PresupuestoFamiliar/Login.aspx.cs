using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PresupuestoFamiliar
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void bRegistrar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Register.aspx");
        }

        protected void bIniciarSesion_Click(object sender, EventArgs e)
        {
            ClsPersonaUsuario.SetCorreo(tCorreo.Text);
            ClsPersonaUsuario.SetClave(tClave.Text);
            if (ClsPersonaUsuario.IniciarSesion())
            {
                Response.Redirect("Inicio.aspx");
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Notify", "alert('Notification : Usuario no existe');", true);
            }           
        }
    }
}