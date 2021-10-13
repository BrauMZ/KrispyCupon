using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace KrispyCupon.database_Access_Layer
{
    public class dbCupon
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConexionDB"].ConnectionString);
        public string Registra_Cupon(string Vigencia, string Sucursal, Boolean Status, 
            string Descipcion, string Usuario )
        {
            try
            {
                SqlCommand cmd = new SqlCommand("sp_RegistraCupon", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@vigencia", Vigencia);
            cmd.Parameters.AddWithValue("@sucursal", Sucursal);
            cmd.Parameters.AddWithValue("@estatus", Status);
            cmd.Parameters.AddWithValue("@descripcion", Descipcion);
            cmd.Parameters.AddWithValue("@name_user", Usuario);

            SqlParameter obCupon = new SqlParameter();
            obCupon.ParameterName = "@Msg";
            obCupon.SqlDbType = SqlDbType.VarChar;
            obCupon.Size = 50;
            obCupon.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(obCupon);
            con.Open();
            cmd.ExecuteNonQuery();
                return obCupon.Value.ToString();
            
        }
            catch (Exception ex)
            {
                // Qué ha sucedido
                var mensaje = "Error message: " + ex.Message;

                // Información sobre la excepción interna
                if (ex.InnerException != null)
                {
                    mensaje = mensaje + " Inner exception: " + ex.InnerException.Message;
                }

                // Dónde ha sucedido
                mensaje = mensaje + " Stack trace: " + ex.StackTrace;

                throw ex;
            }
            finally { con.Close(); }

        }

        public string Update_Cupon(int idcode, string Vigencia,  Boolean Status,
                                    string Descipcion, string Usuario)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("sp_UpdateCupon", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idcode", idcode);
                cmd.Parameters.AddWithValue("@vigencia", Vigencia);
                cmd.Parameters.AddWithValue("@estatus", Status);
                cmd.Parameters.AddWithValue("@descripcion", Descipcion);
                cmd.Parameters.AddWithValue("@name_user", Usuario);

                SqlParameter obCupon = new SqlParameter();
                obCupon.ParameterName = "@Msg";
                obCupon.SqlDbType = SqlDbType.VarChar;
                obCupon.Size = 50;
                obCupon.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(obCupon);
                con.Open();
                cmd.ExecuteNonQuery();
                return obCupon.Value.ToString();

            }
            catch (Exception ex)
            {
                // Qué ha sucedido
                var mensaje = "Error message: " + ex.Message;

                // Información sobre la excepción interna
                if (ex.InnerException != null)
                {
                    mensaje = mensaje + " Inner exception: " + ex.InnerException.Message;
                }

                // Dónde ha sucedido
                mensaje = mensaje + " Stack trace: " + ex.StackTrace;

                throw ex;
            }
            finally { con.Close(); }

        }

        public string Delete_Cupon(int idcode, string Usuario)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("sp_DeleteCupon", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idcode", idcode);
                cmd.Parameters.AddWithValue("@name_user", Usuario);

                SqlParameter obCupon = new SqlParameter();
                obCupon.ParameterName = "@Msg";
                obCupon.SqlDbType = SqlDbType.VarChar;
                obCupon.Size = 50;
                obCupon.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(obCupon);
                con.Open();
                cmd.ExecuteNonQuery();
                return obCupon.Value.ToString();

            }
            catch (Exception ex)
            {
                // Qué ha sucedido
                var mensaje = "Error message: " + ex.Message;

                // Información sobre la excepción interna
                if (ex.InnerException != null)
                {
                    mensaje = mensaje + " Inner exception: " + ex.InnerException.Message;
                }

                // Dónde ha sucedido
                mensaje = mensaje + " Stack trace: " + ex.StackTrace;

                throw ex;
            }
            finally { con.Close(); }

        }
    }
}