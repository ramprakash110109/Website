using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Web.Mvc;
using System.Configuration;

namespace Mvc_XYZ_Apparels.Models
{
    public class UsersDAL
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["constr"].ConnectionString);
        public bool LoginDAL(LoginModel model)
        {
            SqlCommand com_login = new SqlCommand(@"select count(*) from users where userid=@UserID and userpassword=@UserPassword", con);
            com_login.Parameters.AddWithValue("@UserID", model.UserID);
            com_login.Parameters.AddWithValue("@UserPassword", model.UserPassword);
            con.Open();
            int count = Convert.ToInt32(com_login.ExecuteScalar());
            con.Close();
            if (count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}