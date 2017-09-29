using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.Mvc;

namespace Mvc_XYZ_Apparels.Models
{
    public class UsersDAL
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["constr"].ConnectionString);

        public bool LoginDAL(LoginModel model)
        {
            SqlCommand com_login_proc = new SqlCommand("Proc_Login", con);

            com_login_proc.Parameters.AddWithValue("@UserID", model.UserID);
            com_login_proc.Parameters.AddWithValue("@UserPassword", model.UserPassword);

            com_login_proc.CommandType = System.Data.CommandType.StoredProcedure;

            SqlParameter para_returnvalue = new SqlParameter();

            para_returnvalue.Direction = System.Data.ParameterDirection.ReturnValue;
            com_login_proc.Parameters.Add(para_returnvalue);

            con.Open(); com_login_proc.ExecuteNonQuery(); con.Close();

            int count = Convert.ToInt32(para_returnvalue.Value);
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