using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PresupuestoFamiliar
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void bRegistrar_Click(object sender, EventArgs e)
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

        protected void tCedula_TextChanged(object sender, EventArgs e)
        {

        }

        protected void tNombre_TextChanged(object sender, EventArgs e)
        {

        }

        protected void tApellido_TextChanged(object sender, EventArgs e)
        {

        }

        protected void tDireccion_TextChanged(object sender, EventArgs e)
        {

        }

        protected void tTelefono_TextChanged(object sender, EventArgs e)
        {

        }

        protected void tCorreo_TextChanged(object sender, EventArgs e)
        {

        }

        protected void tClave_TextChanged(object sender, EventArgs e)
        {

        }

        protected void dTipoUser_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}