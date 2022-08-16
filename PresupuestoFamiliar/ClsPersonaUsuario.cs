using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace PresupuestoFamiliar
{
    public class ClsPersonaUsuario
    {
        private static int id { get; set; }
        private static string cedula { get; set; }
        private static string nombre { get; set; }
        private static string apellido { get; set; }
        private static string direccion { get; set; }
        private static string telefono { get; set; }
        private static string correo { get; set; }
        //private static int idUsuario { get; set; }
        private static int tipoUser { get; set; }
        private static string clave { get; set; }

        public ClsPersonaUsuario(int Id, string ced, string nom, string apell, string direc, string tel, string corr, int tipoUs, string clav)
        {
            id = Id;
            cedula = ced;
            nombre = nom;
            apellido = apell;
            direccion = direc;
            telefono = tel;
            correo = corr;
            tipoUser = tipoUs;
            clave = clav;
        }

        public static int GetId() { return id; }
        public static string GetCedula() { return cedula; }
        public static string GetNombre() { return nombre; }
        public static string GetDireccion() { return direccion; }
        public static string GetTelefono() { return telefono; }
        public static string GetApellido() { return apellido; }
        public static string GetCorreo() { return correo; }
        public static int GetTipoUser() { return tipoUser; }
        public static string GetClave() { return clave; }

        public static void SetId(int Id)
        {
            id = Id;
        }
        public static void SetCedula(string ced)
        {
            cedula = ced;
        }
        public static void SetNombre(string nom)
        {
            nombre = nom;
        }
        public static void SetDireccion(string direc)
        {
            direccion = direc;
        }
        public static void SetTelefono(string tel)
        {
            telefono = tel;
        }
        public static void SetApellido(string apell)
        {
            apellido = apell;
        }
        public static void SetCorreo(string corr)
        {
            correo = corr;
        }
        public static void SetTipoUser(int tipoUs)
        {
            tipoUser = tipoUs;
        }
        public static void SetClave(string clavv)
        {
            clave = clavv;
        }

        public static Boolean RegistroPersonaUser() //cambiar método 
        {
            Boolean registrado = false;
            SqlConnection con = new SqlConnection();
            try
            {
                using (con = DBconn.obtenerConexion())
                {
                    SqlCommand command = new SqlCommand("Registro", con)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    command.Parameters.Add(new SqlParameter("@cedula", cedula));
                    command.Parameters.Add(new SqlParameter("@nombre", nombre));
                    command.Parameters.Add(new SqlParameter("@apellido", apellido));
                    command.Parameters.Add(new SqlParameter("@direccion", direccion));
                    command.Parameters.Add(new SqlParameter("@telefono", telefono));
                    command.Parameters.Add(new SqlParameter("@correo", correo));
                    command.Parameters.Add(new SqlParameter("@tipoUser", tipoUser));
                    command.Parameters.Add(new SqlParameter("@clave", clave));
                    SqlDataAdapter da = new SqlDataAdapter(command);
                    command.ExecuteNonQuery();
                    registrado = true;
                }
                
            }
            catch (Exception)
            {
            }
            finally
            {
                con.Close();
            }
            return registrado;
        }

        public static Boolean IniciarSesion()
        {
            Boolean existe = false;
            String strConnString = ConfigurationManager.ConnectionStrings["UHPRESUPUESTOConnectionString"].ConnectionString;
            SqlConnection con = new SqlConnection(strConnString);
            try
            {
                con.Open();
                SqlCommand command = new SqlCommand("IniciarSesion", con);
                command.Parameters.Add(new SqlParameter("@correo", correo));
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

        public static Boolean BorrarPersonaUser()
        {
            Boolean existe = false;
            String strConnString = ConfigurationManager.ConnectionStrings["UHPRESUPUESTOConnectionString"].ConnectionString;
            SqlConnection con = new SqlConnection(strConnString);
            try
            {
                con.Open();
                SqlCommand command = new SqlCommand("BorrarPersonaUser", con);
                command.Parameters.Add(new SqlParameter("@cedula", cedula));
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
    }
}