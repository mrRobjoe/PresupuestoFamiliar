using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace PresupuestoFamiliar
{
    public class ClsTransaccion
    {
        private static int Id { get; set; }
        private static int idTipoTransaccion { get; set; }
        private static string correo { get; set; }
        private static string descrip { get; set; }
        private static float monto { get; set; }
        private static string fecha { get; set; }

        private static int mes { get; set; }
        private static float Ingresos { get; set; }

        public ClsTransaccion(int ID, int tipoTransaccion, string corr, string descripcion, float mont, string fech, int month)
        {
            Id = ID;
            idTipoTransaccion = tipoTransaccion;
            correo = corr;
            descrip = descripcion;
            monto = mont;
            fecha = fech;
            mes = month;
        }

        public static int GetId() { return Id; }
        public static int GetTipoTransaccion() { return idTipoTransaccion; }
        public static string GetCorreo() { return correo; }
        public static string GetDescrip() { return descrip; }
        public static float GetMonto() { return monto; }
        public static string GetFecha() { return fecha; }

        public static int GetMes() { return mes; }
        

        public static void SetId(int ID)
        {
            Id = ID;
        }
        public static void SetTipoTransaccion(int tipoTransaccion)
        {
            idTipoTransaccion = tipoTransaccion;
        }
        public static void SetCorreo(string corr)
        {
            correo=corr;
        }
        public static void SetDescrip(string descripcion)
        {
            descrip=descripcion;
        }
        public static void SetMonto(float mont)
        {
            monto=mont;
        }
        public static void SetFecha(string fech)
        {
            fecha=fech;
        }

        public static void SetMes(int month)
        {
            mes = month;
        }

        public static Boolean AgregarTransaccion()
        {
            Boolean existe = false;
            String strConnString = ConfigurationManager.ConnectionStrings["UHPRESUPUESTOConnectionString"].ConnectionString;
            SqlConnection con = new SqlConnection(strConnString);
            try
            {
                con.Open();
                SqlCommand command = new SqlCommand("sp_AgregarTransaccion", con);
                command.Parameters.Add(new SqlParameter("@idTipoTransaccion", idTipoTransaccion));
                command.Parameters.Add(new SqlParameter("@correo", correo));
                command.Parameters.Add(new SqlParameter("@descripcion", descrip));
                command.Parameters.Add(new SqlParameter("@monto", monto));
               // command.Parameters.Add(new SqlParameter("@fecha", fecha));
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

        public static Boolean BorrarTransaccion()
        {
            Boolean existe = false;
            String strConnString = ConfigurationManager.ConnectionStrings["UHPRESUPUESTOConnectionString"].ConnectionString;
            SqlConnection con = new SqlConnection(strConnString);
            try
            {
                con.Open();
                SqlCommand command = new SqlCommand("sp_BorrarTransaccion", con);
                command.Parameters.Add(new SqlParameter("@id", Id));
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

        public static Boolean ModificarTransaccion()
        {
            Boolean existe = false;
            String strConnString = ConfigurationManager.ConnectionStrings["UHPRESUPUESTOConnectionString"].ConnectionString;
            SqlConnection con = new SqlConnection(strConnString);
            try
            {
                con.Open();
                SqlCommand command = new SqlCommand("sp_ModificarTransaccion", con);
                command.Parameters.Add(new SqlParameter("@Id", Id));
                command.Parameters.Add(new SqlParameter("@tipoTransc", idTipoTransaccion));
                command.Parameters.Add(new SqlParameter("@correo", correo));
                command.Parameters.Add(new SqlParameter("@desc", descrip));
                command.Parameters.Add(new SqlParameter("@monto", monto));
                command.Parameters.Add(new SqlParameter("@fecha", fecha));
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

        public static Boolean ReporteFiltro()
        {
            Boolean existe = false;
            String strConnString = ConfigurationManager.ConnectionStrings["UHPRESUPUESTOConnectionString"].ConnectionString;
            SqlConnection con = new SqlConnection(strConnString);
            try
            {
                con.Open();
                SqlCommand command = new SqlCommand("ConsultaTranFiltro", con);
                command.Parameters.Add(new SqlParameter("@tipoTransacc", idTipoTransaccion));
                command.Parameters.Add(new SqlParameter("@correo", correo));
                command.Parameters.Add(new SqlParameter("@mes", mes));
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

        public static void SumaIngresos()
        {

        }
    }
}