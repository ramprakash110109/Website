using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data.SqlClient;

namespace Mvc_XYZ_Apparels.Models
{
    public class CustomersDAL
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["constr"].ConnectionString);

        public bool CreateCustomer(CustomerModel obj)
        {
            con.Open();

            SqlCommand com_customers_insert = new SqlCommand
            (@"insert Customers values(@CustomerName,@CustomerAddress,@CustomerWebsite,@CustomerEmailID,@CustomerLandline,
            @CustomerContactName1,@CustomerContactNumber1,@CustomerContactName2,@CustomerContactNumber2,@CustomerDue)", con);
            com_customers_insert.Parameters.AddWithValue("@CustomerName", obj.CustomerName);
            com_customers_insert.Parameters.AddWithValue("@CustomerAddress", obj.CustomerAddress);
            com_customers_insert.Parameters.AddWithValue("@CustomerWebsite", obj.CustomerWebsite);
            com_customers_insert.Parameters.AddWithValue("@CustomerEmailID", obj.CustomerEmailID);
            com_customers_insert.Parameters.AddWithValue("@CustomerLandline", obj.CustomerLandline);
            com_customers_insert.Parameters.AddWithValue("@CustomerContactName1", obj.CustomerContactName1);
            com_customers_insert.Parameters.AddWithValue("@CustomerContactNumber1", obj.CustomerContactName1);
            com_customers_insert.Parameters.AddWithValue("@CustomerContactName2", obj.CustomerContactName2);
            com_customers_insert.Parameters.AddWithValue("@CustomerContactNumber2", obj.CustomerContactName2);
            com_customers_insert.Parameters.AddWithValue("@CustomerDue", obj.CustomerDue);

            com_customers_insert.ExecuteNonQuery();

            SqlCommand com_customerid = new SqlCommand("Select @@identity", con);

            obj.CustomerID = Convert.ToInt32(com_customerid.ExecuteScalar());
            con.Close();
            return true;
        }

        public CustomerModel FindCustomer(int CustomerID)
        {
            CustomerModel model = new CustomerModel();
            con.Open();
            SqlCommand com_read_customer = new SqlCommand(@"CustomerName,CustomerAddress,CustomerWebsite,CustomerEmailID,CustomerLandline,
            CustomerContactName1,CustomerContactNumber1,CustomerContactName2,CustomerContactNumber2,CustomerDue from customers where CustomerID=@CustomerID", con);

            com_read_customer.Parameters.AddWithValue("@CustomerID", CustomerID);
            SqlDataReader dr_customer = com_read_customer.ExecuteReader();
            if (dr_customer.Read())
            {
                model.CustomerID = dr_customer.GetInt32(0);
                model.CustomerName = dr_customer.GetString(1);
                model.CustomerAddress = dr_customer.GetString(2);
                model.CustomerWebsite = dr_customer.GetString(3);
                model.CustomerEmailID = dr_customer.GetString(4);
                model.CustomerLandline = dr_customer.GetString(5);
                model.CustomerContactName1 = dr_customer.GetString(6);
                model.CustomerContactNumber1 = dr_customer.GetString(7);
                model.CustomerContactName2 = dr_customer.GetString(8);
                model.CustomerContactNumber2 = dr_customer.GetString(9);
                model.CustomerDue = dr_customer.GetInt32(10);
            }
            con.Close();
            return model;
        }

        public List<CustomerModel> ShowCustomers()
        {
            List<CustomerModel> list_customers = new List<CustomerModel>();

            SqlCommand com_customers_read = new SqlCommand(@"select * from Customers", con);
            con.Open();
            SqlDataReader dr_customers = com_customers_read.ExecuteReader();
            while (dr_customers.Read())
            {
                CustomerModel model = new CustomerModel();
                model.CustomerID = dr_customers.GetInt32(0);
                model.CustomerName = dr_customers.GetString(1);
                model.CustomerAddress = dr_customers.GetString(2);
                model.CustomerWebsite = dr_customers.GetString(3);
                model.CustomerEmailID = dr_customers.GetString(4);
                model.CustomerLandline = dr_customers.GetString(5);
                model.CustomerContactName1 = dr_customers.GetString(6);
                model.CustomerContactNumber1 = dr_customers.GetString(7);
                model.CustomerContactName2 = dr_customers.GetString(8);
                model.CustomerContactNumber2 = dr_customers.GetString(9);
                model.CustomerDue = dr_customers.GetInt32(10);
                list_customers.Add(model);
            }
            con.Close();
            return list_customers;
        }

        public bool CheckEmail(string email)
        {
            SqlCommand com_emailcheck_proc = new SqlCommand("Proc_EmailCheck", con);

            com_emailcheck_proc.Parameters.AddWithValue("@CustomerEmailID", email);

            com_emailcheck_proc.CommandType = System.Data.CommandType.StoredProcedure;

            SqlParameter para_returnvalue = new SqlParameter();

            para_returnvalue.Direction = System.Data.ParameterDirection.ReturnValue;
            com_emailcheck_proc.Parameters.Add(para_returnvalue);

            con.Open(); com_emailcheck_proc.ExecuteNonQuery(); con.Close();

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