using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace KrispyCupon.database_Access_Layer
{
    public class db
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConexionDB"].ConnectionString);
        public int Admin_Login(string Usuario, string Password)
        {
            int res = 0;
            SqlCommand cmd = new SqlCommand("sp_ValidaUsers", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@name", Usuario);
            cmd.Parameters.AddWithValue("@password", Password);
            cmd.Parameters.AddWithValue("@patron", "InfoToolsSV");
            
            SqlParameter oblogin = new SqlParameter();
            oblogin.ParameterName = "@Isvalid";
            oblogin.SqlDbType = SqlDbType.Bit;
            oblogin.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(oblogin);
            con.Open();
            cmd.ExecuteNonQuery();
            res = Convert.ToInt32(oblogin.Value);
            con.Close();
            return res;
        }
    }
}