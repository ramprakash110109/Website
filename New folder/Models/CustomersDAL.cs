using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data.SqlClient;
using Mvc_XYZ_Apparels.Models;

namespace Mvc_XYZ_Apparels.Models
{
    public class CustomersDAL
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["constr"].ConnectionString);

        public bool CreateCustomer(CustomerModel obj)
        {            
            if (obj.CustomerWebsite == null)
                obj.CustomerWebsite = "";

            if (obj.CustomerEmailID == null)
                obj.CustomerEmailID = "";

            if (obj.CustomerLandline == null)
                obj.CustomerLandline = "";

            if (obj.CustomerContactName2 == null)
                obj.CustomerContactName2 = "";

            if (obj.CustomerContactNumber2 == null)
                obj.CustomerContactNumber2 = "";

            if (obj.CustomerStatus == null)
                obj.CustomerStatus = "ACTIVE";
       
            SqlCommand com_customers_insert = new SqlCommand
            (@"insert Customers values(@CustomerName,@CustomerAddress,@CustomerWebsite,@CustomerEmailID,@CustomerLandline,
            @CustomerContactName1,@CustomerContactNumber1,@CustomerContactName2,@CustomerContactNumber2,@CustomerDue,@CustomerStatus)", con);
            com_customers_insert.Parameters.AddWithValue("@CustomerName", obj.CustomerName);
            com_customers_insert.Parameters.AddWithValue("@CustomerAddress", obj.CustomerAddress);
            com_customers_insert.Parameters.AddWithValue("@CustomerWebsite", obj.CustomerWebsite);
            com_customers_insert.Parameters.AddWithValue("@CustomerEmailID", obj.CustomerEmailID);
            com_customers_insert.Parameters.AddWithValue("@CustomerLandline", obj.CustomerLandline);
            com_customers_insert.Parameters.AddWithValue("@CustomerContactName1", obj.CustomerContactName1);
            com_customers_insert.Parameters.AddWithValue("@CustomerContactNumber1", obj.CustomerContactNumber1);
            com_customers_insert.Parameters.AddWithValue("@CustomerContactName2", obj.CustomerContactName2);
            com_customers_insert.Parameters.AddWithValue("@CustomerContactNumber2", obj.CustomerContactNumber2);
            com_customers_insert.Parameters.AddWithValue("@CustomerDue", obj.CustomerDue);
            com_customers_insert.Parameters.AddWithValue("@CustomerStatus", obj.CustomerStatus);

            con.Open();
            com_customers_insert.ExecuteNonQuery();

            SqlCommand com_customerid = new SqlCommand("Select @@identity", con);

            obj.CustomerID = Convert.ToInt32(com_customerid.ExecuteScalar());
            con.Close();
            return true;
        }

        public CustomerModel FindCustomer(int ID)
        {
            SqlCommand com_read_customer = new SqlCommand(@"Select * from Customers where CustomerID=@CustomerID", con);           
            com_read_customer.Parameters.AddWithValue("@CustomerID", ID);
            
            con.Open();
            
            SqlDataReader dr_customers = com_read_customer.ExecuteReader();
            CustomerModel model = new CustomerModel();
            if (dr_customers.Read())
            {
                model.CustomerID = ID;
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
                model.CustomerStatus = dr_customers.GetString(11);
            }
            else
                model = null;
            con.Close();
            return model;
        }

        public bool UpdateCustomer(CustomerModel obj)
        {
            if (obj.CustomerWebsite == null)
                obj.CustomerWebsite = "";

            if (obj.CustomerEmailID == null)
                obj.CustomerEmailID = "";

            if (obj.CustomerLandline == null)
                obj.CustomerLandline = "";

            if (obj.CustomerContactName2 == null)
                obj.CustomerContactName2 = "";

            if (obj.CustomerContactNumber2 == null)
                obj.CustomerContactNumber2 = "";

            if (obj.CustomerStatus == null)
                obj.CustomerStatus = "ACTIVE";
            SqlCommand com_update_Customer = new SqlCommand
                (@"update Customers set CustomerName=@CustomerName,CustomerAddress=@CustomerAddress,
CustomerWebsite=@CustomerWebsite,CustomerEmailID=@CustomerEmailID,CustomerLandline=@CustomerLandline,
CustomerContactName1=@CustomerContactName1,CustomerContactNumber1=@CustomerContactNumber1,
CustomerContactName2=@CustomerContactName2,CustomerContactNumber2=@CustomerContactNumber2,CustomerDue=@CustomerDue where CustomerID=@CustomerID", con);
            com_update_Customer.Parameters.AddWithValue("@CustomerName", obj.CustomerName);
            com_update_Customer.Parameters.AddWithValue("@CustomerAddress", obj.CustomerAddress);
            com_update_Customer.Parameters.AddWithValue("@CustomerWebsite", obj.CustomerWebsite);
            com_update_Customer.Parameters.AddWithValue("@CustomerEmailID", obj.CustomerEmailID);
            com_update_Customer.Parameters.AddWithValue("@CustomerLandline", obj.CustomerLandline);
            com_update_Customer.Parameters.AddWithValue("@CustomerContactName1", obj.CustomerContactName1);
            com_update_Customer.Parameters.AddWithValue("@CustomerContactNumber1", obj.CustomerContactNumber1);
            com_update_Customer.Parameters.AddWithValue("@CustomerContactName2", obj.CustomerContactName2);
            com_update_Customer.Parameters.AddWithValue("@CustomerContactNumber2", obj.CustomerContactNumber2);
            com_update_Customer.Parameters.AddWithValue("@CustomerDue", obj.CustomerDue);
            com_update_Customer.Parameters.AddWithValue("@CustomerID", obj.CustomerID);

            con.Open();
            int count = com_update_Customer.ExecuteNonQuery();
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

        public List<CustomerModel> GetCustomers()
        {            
            List<CustomerModel> list_customers = new List<CustomerModel>();
            SqlCommand com_customers = new SqlCommand("Select * from Customers", con);
            con.Open();
            SqlDataReader dr_customer = com_customers.ExecuteReader();
            while (dr_customer.Read())
            {
                CustomerModel model = new CustomerModel();
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
                model.CustomerStatus = dr_customer.GetString(11);
                list_customers.Add(model);
            }
            con.Close();
            return list_customers;
        }

        public List<CustomerModel> GetActiveCustomers()
        {
            List<CustomerModel> list_customers = new List<CustomerModel>();
            SqlCommand com_customers = new SqlCommand(@"Select * from Customers where CustomerStatus='ACTIVE'", con);
            con.Open();
            SqlDataReader dr_customer = com_customers.ExecuteReader();
            while (dr_customer.Read())
            {
                CustomerModel model = new CustomerModel();
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
                model.CustomerStatus = dr_customer.GetString(11);
                list_customers.Add(model);
            }
            con.Close();
            return list_customers;
        }

        public List<CustomerModel> GetInactiveCustomers()
        {
            List<CustomerModel> list_customers = new List<CustomerModel>();
            SqlCommand com_customers = new SqlCommand(@"Select * from Customers where CustomerStattus='INACTIVE'", con);
            con.Open();
            SqlDataReader dr_customer = com_customers.ExecuteReader();
            while (dr_customer.Read())
            {
                CustomerModel model = new CustomerModel();
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
                model.CustomerStatus = dr_customer.GetString(11);
                list_customers.Add(model);
            }
            con.Close();
            return list_customers;
        }

        public bool ChangeStatusInactive(int CustomerID)
        {
            con.Open();
            SqlCommand com_update_Customer = new SqlCommand
               (@"update Customers set CustomerStatus='INACTIVE' where CustomerID=@CustomerID", con);
            com_update_Customer.Parameters.AddWithValue("@CustomerID", CustomerID);
            int Count = com_update_Customer.ExecuteNonQuery();
            con.Close();
            if (Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool ChangeStatusActive(int CustomerID)
        {
            con.Open();
            SqlCommand com_update_Customer = new SqlCommand
               (@"update Customers set CustomerStatus='ACTIVE' where CustomerID=@CustomerID", con);
            com_update_Customer.Parameters.AddWithValue("@CustomerID", CustomerID);
            int Count = com_update_Customer.ExecuteNonQuery();
            con.Close();
            if (Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //public bool CheckEmail(string email)
        //{
        //    SqlCommand com_emailcheck_proc =
        //        new SqlCommand(@"select count(*) from Customers where CustomerEmailID=@CustomerEmailID", con);
        //    com_emailcheck_proc.Parameters.AddWithValue("@CustomerEmailID", email);

        //    con.Open();
        //    int count = com_emailcheck_proc.ExecuteNonQuery();
        //    con.Close();
        //    if (count > 0)
        //    {
        //        return true;
        //    }
        //    else
        //    {
        //        return false;
        //    }
        //}

    }
}