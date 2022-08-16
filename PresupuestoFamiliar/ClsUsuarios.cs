using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace PresupuestoFamiliar
{
    public class ClsUsuarios
    {
        private static string correo { get; set; }
        //private static int idUsuario { get; set; }
        private static int tipoUser { get; set; }
        private static string clave { get; set; }

        public ClsUsuarios(string corr, int tipoUs,string clav)
        {
            correo= corr;
           // idUsuario= idUser;
            tipoUser= tipoUs;
            clave= clav;
        }

        public static string GetCorreo() { return correo; }
        public static int GetTipoUser() { return tipoUser; }
        public static string GetClave() { return clave; }

        public static void SetCorreo(string corr)
        {
            correo=corr;
        }
        public static void SetTipoUser(int tipoUs)
        {
            tipoUser= tipoUs;
        }
        public static void SetClave(string clavv)
        {
            clave = clavv;
        }

        public static Boolean ConsultarUsuario()
        {
            Boolean existe=false;
            String strConnString = ConfigurationManager.ConnectionStrings["UHPRESUPUESTOConnectionString"].ConnectionString;
            SqlConnection con = new SqlConnection(strConnString);
            try
            {
                con.Open();
                SqlCommand command = new SqlCommand("sp_ConsultarUsuario", con);
                command.Parameters.Add(new SqlParameter("@correo", correo));
                command.CommandType=CommandType.StoredProcedure;
                SqlDataAdapter da= new SqlDataAdapter(command);
                command.ExecuteNonQuery();
                existe = true;
                
            }
            catch (Exception)
            {
            }
            finally
            {
                con.Close();
            }
            return existe;
        }

        public static Boolean BorrarUsuario()
        {
            Boolean existe = false;
            String strConnString = ConfigurationManager.ConnectionStrings["UHPRESUPUESTOConnectionString"].ConnectionString;
            SqlConnection con = new SqlConnection(strConnString);
            try
            {
                con.Open();
                SqlCommand command = new SqlCommand("sp_BorrarUsuario", con);
                command.Parameters.Add(new SqlParameter("@correo", correo));
                command.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(command);
                command.ExecuteNonQuery();
                existe = true;
            }
            catch (Exception)
            {
            }
            finally
            {
                con.Close();
            }
            return existe;
        }

        public static Boolean ModificarUsuario()
        {
            Boolean existe = false;
            String strConnString = ConfigurationManager.ConnectionStrings["UHPRESUPUESTOConnectionString"].ConnectionString;
            SqlConnection con = new SqlConnection(strConnString);
            try
            {
                con.Open();
                SqlCommand command = new SqlCommand("sp_ModificarUsuario", con);
                command.Parameters.Add(new SqlParameter("@correo", correo));
                command.Parameters.Add(new SqlParameter("@tipoUsuario", tipoUser));
                command.Parameters.Add(new SqlParameter("@clave", clave));
                command.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(command);
                command.ExecuteNonQuery();
                existe = true;
            }
            catch (Exception)
            {
            }
            finally
            {
                con.Close();
            }
            return existe;
        }
    }
}