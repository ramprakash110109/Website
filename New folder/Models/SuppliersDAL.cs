using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data.SqlClient;
using Mvc_XYZ_Apparels.Models;

namespace Mvc_XYZ_Apparels.Models
{
    public class SuppliersDAL
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["constr"].ConnectionString);

        public bool CreateSupplier(SupplierModel obj)
        {
            if (obj.SupplierWebsite == null)
                obj.SupplierWebsite = "";

            if (obj.SupplierEmailID == null)
                obj.SupplierEmailID = "";

            if (obj.SupplierLandline == null)
                obj.SupplierLandline = "";

            if (obj.SupplierContactName2 == null)
                obj.SupplierContactName2 = "";

            if (obj.SupplierContactNumber2 == null)
                obj.SupplierContactNumber2 = "";

            if (obj.SupplierTIN == null)
                obj.SupplierTIN = "";

            if (obj.SupplierGSTNo == null)
                obj.SupplierGSTNo = "";

            if (obj.SupplierPAN == null)
                obj.SupplierPAN = "";

            if (obj.SupplierBankName == null)
                obj.SupplierBankName = "";

            if (obj.SupplierBankAccountNo == null)
                obj.SupplierBankAccountNo = "";

            if (obj.SupplierIFSC == null)
                obj.SupplierIFSC = "";

            if (obj.SupplierStatus == null)
                obj.SupplierStatus = "ACTIVE";

            SqlCommand com_suppliers_insert = new SqlCommand
            (@"insert Suppliers values(@SupplierName,@MillName,@SupplierAddress,@SupplierWebsite,@SupplierEmailID,@SupplierLandline,
            @SupplierContactName1,@SupplierContactNumber1,@SupplierContactName2,@SupplierContactNumber2,@SupplierTIN,
@SupplierGSTNo,@SupplierPAN,@SupplierBankName,@SupplierBankAccountNo,@SupplierIFSC,@SupplierDue,@SupplierStatus)", con);
            com_suppliers_insert.Parameters.AddWithValue("@SupplierName", obj.SupplierName);
            com_suppliers_insert.Parameters.AddWithValue("@MillName", obj.MillName);
            com_suppliers_insert.Parameters.AddWithValue("@SupplierAddress", obj.SupplierAddress);
            com_suppliers_insert.Parameters.AddWithValue("@SupplierWebsite", obj.SupplierWebsite);
            com_suppliers_insert.Parameters.AddWithValue("@SupplierEmailID", obj.SupplierEmailID);
            com_suppliers_insert.Parameters.AddWithValue("@SupplierLandline", obj.SupplierLandline);
            com_suppliers_insert.Parameters.AddWithValue("@SupplierContactName1", obj.SupplierContactName1);
            com_suppliers_insert.Parameters.AddWithValue("@SupplierContactNumber1", obj.SupplierContactNumber1);
            com_suppliers_insert.Parameters.AddWithValue("@SupplierContactName2", obj.SupplierContactName2);
            com_suppliers_insert.Parameters.AddWithValue("@SupplierContactNumber2", obj.SupplierContactNumber2);
            com_suppliers_insert.Parameters.AddWithValue("@SupplierTIN", obj.SupplierTIN);
            com_suppliers_insert.Parameters.AddWithValue("@SupplierGSTNo", obj.SupplierGSTNo);
            com_suppliers_insert.Parameters.AddWithValue("@SupplierPAN", obj.SupplierPAN);
            com_suppliers_insert.Parameters.AddWithValue("@SupplierBankName", obj.SupplierBankName);
            com_suppliers_insert.Parameters.AddWithValue("@SupplierBankAccountNo", obj.SupplierBankAccountNo);
            com_suppliers_insert.Parameters.AddWithValue("@SupplierIFSC", obj.SupplierIFSC);
            com_suppliers_insert.Parameters.AddWithValue("@SupplierDue", obj.SupplierDue);
            com_suppliers_insert.Parameters.AddWithValue("@SupplierStatus", obj.SupplierStatus);

            con.Open();
            com_suppliers_insert.ExecuteNonQuery();

            SqlCommand com_supplierid = new SqlCommand("Select @@identity", con);

            obj.SupplierID = Convert.ToInt32(com_supplierid.ExecuteScalar());
            con.Close();
            return true;
        }

        public SupplierModel FindSupplier(int ID)
        {
            SqlCommand com_read_supplier = new SqlCommand(@"Select * from Suppliers where SupplierID=@SupplierID", con);
            com_read_supplier.Parameters.AddWithValue("@SupplierID", ID);

            con.Open();

            SqlDataReader dr_suppliers = com_read_supplier.ExecuteReader();
            SupplierModel model = new SupplierModel();
            if (dr_suppliers.Read())
            {
                model.SupplierID = ID;
                model.SupplierName = dr_suppliers.GetString(1);
                model.MillName = dr_suppliers.GetString(2);
                model.SupplierAddress = dr_suppliers.GetString(3);
                model.SupplierWebsite = dr_suppliers.GetString(4);
                model.SupplierEmailID = dr_suppliers.GetString(5);
                model.SupplierLandline = dr_suppliers.GetString(6);
                model.SupplierContactName1 = dr_suppliers.GetString(7);
                model.SupplierContactNumber1 = dr_suppliers.GetString(8);
                model.SupplierContactName2 = dr_suppliers.GetString(9);
                model.SupplierContactNumber2 = dr_suppliers.GetString(10);
                model.SupplierTIN = dr_suppliers.GetString(11);
                model.SupplierGSTNo = dr_suppliers.GetString(12);
                model.SupplierPAN = dr_suppliers.GetString(13);
                model.SupplierBankName = dr_suppliers.GetString(14);
                model.SupplierBankAccountNo = dr_suppliers.GetString(15);
                model.SupplierIFSC = dr_suppliers.GetString(16);
                model.SupplierDue = dr_suppliers.GetInt32(17);
                model.SupplierStatus = dr_suppliers.GetString(18);
            }
            else
                model = null;
            con.Close();
            return model;
        }

        public bool UpdateSupplier(SupplierModel obj)
        {
            if (obj.SupplierWebsite == null)
                obj.SupplierWebsite = "";

            if (obj.SupplierEmailID == null)
                obj.SupplierEmailID = "";

            if (obj.SupplierLandline == null)
                obj.SupplierLandline = "";

            if (obj.SupplierContactName2 == null)
                obj.SupplierContactName2 = "";

            if (obj.SupplierContactNumber2 == null)
                obj.SupplierContactNumber2 = "";

            if (obj.SupplierTIN == null)
                obj.SupplierTIN = "";

            if (obj.SupplierGSTNo == null)
                obj.SupplierGSTNo = "";

            if (obj.SupplierPAN == null)
                obj.SupplierPAN = "";

            if (obj.SupplierBankName == null)
                obj.SupplierBankName = "";

            if (obj.SupplierBankAccountNo == null)
                obj.SupplierBankAccountNo = "";

            if (obj.SupplierIFSC == null)
                obj.SupplierIFSC = "";

            if (obj.SupplierStatus == null)
                obj.SupplierStatus = "ACTIVE";

            SqlCommand com_update_Supplier = new SqlCommand
     (@"update Suppliers set SupplierName=@SupplierName,MillName=@MillName,SupplierAddress=@SupplierAddress,
SupplierWebsite=@SupplierWebsite,SupplierEmailID=@SupplierEmailID,SupplierLandline=@SupplierLandline,SupplierContactName1=@SupplierContactName1,
SupplierContactNumber1=@SupplierContactNumber1,SupplierContactName2=@SupplierContactName2,
SupplierContactNumber2=@SupplierContactNumber2,@SupplierTIN=SupplierTIN,@SupplierGSTNo=SupplierGSTNo,
@SupplierPAN=SupplierPAN,@SupplierBankName=SupplierBankName,@SupplierBankAccountNo=SupplierBankAccountNo,
@SupplierIFSC=SupplierIFSC,SupplierDue=@SupplierDue,SupplierStatus=@SupplierStatus where SupplierID=@SupplierID", con);

            com_update_Supplier.Parameters.AddWithValue("@SupplierName", obj.SupplierName);
            com_update_Supplier.Parameters.AddWithValue("@MillName", obj.MillName);
            com_update_Supplier.Parameters.AddWithValue("@SupplierAddress", obj.SupplierAddress);
            com_update_Supplier.Parameters.AddWithValue("@SupplierWebsite", obj.SupplierWebsite);
            com_update_Supplier.Parameters.AddWithValue("@SupplierEmailID", obj.SupplierEmailID);
            com_update_Supplier.Parameters.AddWithValue("@SupplierLandline", obj.SupplierLandline);
            com_update_Supplier.Parameters.AddWithValue("@SupplierContactName1", obj.SupplierContactName1);
            com_update_Supplier.Parameters.AddWithValue("@SupplierContactNumber1", obj.SupplierContactNumber1);
            com_update_Supplier.Parameters.AddWithValue("@SupplierContactName2", obj.SupplierContactName2);
            com_update_Supplier.Parameters.AddWithValue("@SupplierContactNumber2", obj.SupplierContactNumber2);
            com_update_Supplier.Parameters.AddWithValue("@SupplierTIN", obj.SupplierTIN);
            com_update_Supplier.Parameters.AddWithValue("@SupplierGSTNo", obj.SupplierGSTNo);
            com_update_Supplier.Parameters.AddWithValue("@SupplierPAN", obj.SupplierPAN);
            com_update_Supplier.Parameters.AddWithValue("@SupplierBankName", obj.SupplierBankName);
            com_update_Supplier.Parameters.AddWithValue("@SupplierBankAccountNo", obj.SupplierBankAccountNo);
            com_update_Supplier.Parameters.AddWithValue("@SupplierIFSC", obj.SupplierIFSC);
            com_update_Supplier.Parameters.AddWithValue("@SupplierDue", obj.SupplierDue);
            com_update_Supplier.Parameters.AddWithValue("@SupplierStatus", obj.SupplierStatus);
            com_update_Supplier.Parameters.AddWithValue("@SupplierID", obj.SupplierID);

            con.Open();
            int count = com_update_Supplier.ExecuteNonQuery();
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

        public List<SupplierModel> GetSuppliers()
        {
            List<SupplierModel> list_suppliers = new List<SupplierModel>();
            SqlCommand com_suppliers = new SqlCommand("Select * from Suppliers", con);
            con.Open();
            SqlDataReader dr_suppliers = com_suppliers.ExecuteReader();
            while (dr_suppliers.Read())
            {
                SupplierModel model = new SupplierModel();
                model.SupplierID = dr_suppliers.GetInt32(0);
                model.SupplierName = dr_suppliers.GetString(1);
                model.MillName = dr_suppliers.GetString(2);
                model.SupplierAddress = dr_suppliers.GetString(3);
                model.SupplierWebsite = dr_suppliers.GetString(4);
                model.SupplierEmailID = dr_suppliers.GetString(5);
                model.SupplierLandline = dr_suppliers.GetString(6);
                model.SupplierContactName1 = dr_suppliers.GetString(7);
                model.SupplierContactNumber1 = dr_suppliers.GetString(8);
                model.SupplierContactName2 = dr_suppliers.GetString(9);
                model.SupplierContactNumber2 = dr_suppliers.GetString(10);
                model.SupplierTIN = dr_suppliers.GetString(11);
                model.SupplierGSTNo = dr_suppliers.GetString(12);
                model.SupplierPAN = dr_suppliers.GetString(13);
                model.SupplierBankName = dr_suppliers.GetString(14);
                model.SupplierBankAccountNo = dr_suppliers.GetString(15);
                model.SupplierIFSC = dr_suppliers.GetString(16);
                model.SupplierDue = dr_suppliers.GetInt32(17);
                model.SupplierStatus = dr_suppliers.GetString(18);
                list_suppliers.Add(model);
            }
            con.Close();
            return list_suppliers;
        }

        public bool ChangeStatusInactive(int SupplierID)
        {
            con.Open();
            SqlCommand com_update_Supplier = new SqlCommand
               (@"update Suppliers set SupplierStatus='INACTIVE' where SupplierID=@SupplierID", con);
            com_update_Supplier.Parameters.AddWithValue("@SupplierID", SupplierID);
            int Count = com_update_Supplier.ExecuteNonQuery();
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

        public bool ChangeStatusActive(int SupplierID)
        {
            con.Open();
            SqlCommand com_update_Supplier = new SqlCommand
               (@"update Suppliers set SupplierStatus='ACTIVE' where SupplierID=@SupplierID", con);
            com_update_Supplier.Parameters.AddWithValue("@SupplierID", SupplierID);
            int Count = com_update_Supplier.ExecuteNonQuery();
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
    }
}