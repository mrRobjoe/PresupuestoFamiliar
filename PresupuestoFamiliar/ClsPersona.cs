using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace PresupuestoFamiliar
{
    public class ClsPersona
    {
        private static int id { get; set; }
        private static string cedula { get; set; }
        private static string nombre { get; set; }
        private static string apellido { get; set; }
        private static string direccion { get; set; }
        private static string telefono { get; set; }

        public ClsPersona(int Id, string ced, string nom, string apell, string direc, string tel)
        {
            id = Id;
            cedula = ced;
            nombre = nom;
            apellido = apell;
            direccion = direc;
            telefono = tel;

        }

        public static int GetId() { return id; }
        public static string GetCedula() { return cedula; }
        public static string GetNombre() { return nombre; }
        public static string GetDireccion() { return direccion; }
        public static string GetTelefono() { return telefono; }
        public static string GetApellido() { return apellido; }

        public static void SetId(int Id)
        {
            id=Id;
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
            telefono=tel;
        }
        public static void SetApellido(string apell)
        {
            apellido=apell;
        }

        public static Boolean BorrarPersona()
        {
            Boolean existe = false;
            String strConnString = ConfigurationManager.ConnectionStrings["UHPRESUPUESTOConnectionString"].ConnectionString;
            SqlConnection con = new SqlConnection(strConnString);
            try
            {
                con.Open();
                SqlCommand command = new SqlCommand("sp_BorrarPersona", con);
                command.Parameters.Add(new SqlParameter("@id", id));
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

        public static Boolean ModificarPersona()
        {
            Boolean existe = false;
            String strConnString = ConfigurationManager.ConnectionStrings["UHPRESUPUESTOConnectionString"].ConnectionString;
            SqlConnection con = new SqlConnection(strConnString);
            try
            {
                con.Open();
                SqlCommand command = new SqlCommand("sp_ModificarPersona", con);
                command.Parameters.Add(new SqlParameter("@id", id));
                command.Parameters.Add(new SqlParameter("@cedula", cedula));
                command.Parameters.Add(new SqlParameter("@nombre", nombre));
                command.Parameters.Add(new SqlParameter("@apellido", apellido));
                command.Parameters.Add(new SqlParameter("@direccion", direccion));
                command.Parameters.Add(new SqlParameter("@telefono", telefono));
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