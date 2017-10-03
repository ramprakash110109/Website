using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data.SqlClient;
using Mvc_XYZ_Apparels.Models;

namespace Mvc_XYZ_Apparels.Models
{
    public class ContractorsDAL
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["constr"].ConnectionString);

        public bool CreateContractor(ContractorModel obj)
        {
            if (obj.ContractorWebsite == null)
                obj.ContractorWebsite = "";

            if (obj.ContractorEmailID == null)
                obj.ContractorEmailID = "";

            if (obj.ContractorLandline == null)
                obj.ContractorLandline = "";

            if (obj.ContractorContactName2 == null)
                obj.ContractorContactName2 = "";

            if (obj.ContractorContactNumber2 == null)
                obj.ContractorContactNumber2 = "";

            if (obj.ContractorTIN == null)
                obj.ContractorTIN = "";

            if (obj.ContractorGSTNo == null)
                obj.ContractorGSTNo = "";

            if (obj.ContractorPAN == null)
                obj.ContractorPAN = "";

            if (obj.ContractorBankName == null)
                obj.ContractorBankName = "";

            if (obj.ContractorBankAccountNo == null)
                obj.ContractorBankAccountNo = "";

            if (obj.ContractorIFSC == null)
                obj.ContractorIFSC = "";

            if (obj.ContractorStatus == null)
                obj.ContractorStatus = "ACTIVE";

            SqlCommand com_contractors_insert = new SqlCommand
            (@"insert Contractor values(@ContractorName,@ContractorAddress,@ContractorWebsite,@ContractorEmailID,
@ContractorLandline,@ContractorContactName1,@ContractorContactNumber1,@ContractorContactName2,@ContractorContactNumber2,
@ContractorTIN,@ContractorGSTNo,@ContractorPAN,@ContractorBankName,@ContractorBankAccountNo,@ContractorIFSC,@ContractorDue,
@ContractorStatus)", con);
            com_contractors_insert.Parameters.AddWithValue("@ContractorName", obj.ContractorName);
            com_contractors_insert.Parameters.AddWithValue("@ContractorAddress", obj.ContractorAddress);
            com_contractors_insert.Parameters.AddWithValue("@ContractorWebsite", obj.ContractorWebsite);
            com_contractors_insert.Parameters.AddWithValue("@ContractorEmailID", obj.ContractorEmailID);
            com_contractors_insert.Parameters.AddWithValue("@ContractorLandline", obj.ContractorLandline);
            com_contractors_insert.Parameters.AddWithValue("@ContractorContactName1", obj.ContractorContactName1);
            com_contractors_insert.Parameters.AddWithValue("@ContractorContactNumber1", obj.ContractorContactNumber1);
            com_contractors_insert.Parameters.AddWithValue("@ContractorContactName2", obj.ContractorContactName2);
            com_contractors_insert.Parameters.AddWithValue("@ContractorContactNumber2", obj.ContractorContactNumber2);
            com_contractors_insert.Parameters.AddWithValue("@ContractorTIN", obj.ContractorTIN);
            com_contractors_insert.Parameters.AddWithValue("@ContractorGSTNo", obj.ContractorGSTNo);
            com_contractors_insert.Parameters.AddWithValue("@ContractorPAN", obj.ContractorPAN);
            com_contractors_insert.Parameters.AddWithValue("@ContractorBankName", obj.ContractorBankName);
            com_contractors_insert.Parameters.AddWithValue("@ContractorBankAccountNo", obj.ContractorBankAccountNo);
            com_contractors_insert.Parameters.AddWithValue("@ContractorIFSC", obj.ContractorIFSC);
            com_contractors_insert.Parameters.AddWithValue("@ContractorDue", obj.ContractorDue);
            com_contractors_insert.Parameters.AddWithValue("@ContractorStatus", obj.ContractorStatus);

            con.Open();
            com_contractors_insert.ExecuteNonQuery();

            SqlCommand com_contractorid = new SqlCommand("Select @@identity", con);

            obj.ContractorID = Convert.ToInt32(com_contractorid.ExecuteScalar());
            con.Close();
            return true;
        }

        public ContractorModel FindContractor(int ID)
        {
            SqlCommand com_read_contractor = new SqlCommand(@"Select * from Contractors where ContractorID=@ContractorID", con);
            com_read_contractor.Parameters.AddWithValue("@ContractorID", ID);

            con.Open();

            SqlDataReader dr_contractors = com_read_contractor.ExecuteReader();
            ContractorModel model = new ContractorModel();
            if (dr_contractors.Read())
            {
                model.ContractorID = ID;
                model.ContractorName = dr_contractors.GetString(1);
                model.ContractorAddress = dr_contractors.GetString(2);
                model.ContractorWebsite = dr_contractors.GetString(3);
                model.ContractorEmailID = dr_contractors.GetString(4);
                model.ContractorLandline = dr_contractors.GetString(5);
                model.ContractorContactName1 = dr_contractors.GetString(6);
                model.ContractorContactNumber1 = dr_contractors.GetString(7);
                model.ContractorContactName2 = dr_contractors.GetString(8);
                model.ContractorContactNumber2 = dr_contractors.GetString(9);
                model.ContractorTIN = dr_contractors.GetString(10);
                model.ContractorGSTNo = dr_contractors.GetString(11);
                model.ContractorPAN = dr_contractors.GetString(12);
                model.ContractorBankName = dr_contractors.GetString(13);
                model.ContractorBankAccountNo = dr_contractors.GetString(14);
                model.ContractorIFSC = dr_contractors.GetString(15);
                model.ContractorDue = dr_contractors.GetInt32(16);
                model.ContractorStatus = dr_contractors.GetString(17);
            }
            else
                model = null;
            con.Close();
            return model;
        }

        public bool UpdateContractor(ContractorModel obj)
        {
            if (obj.ContractorWebsite == null)
                obj.ContractorWebsite = "";

            if (obj.ContractorEmailID == null)
                obj.ContractorEmailID = "";

            if (obj.ContractorLandline == null)
                obj.ContractorLandline = "";

            if (obj.ContractorContactName2 == null)
                obj.ContractorContactName2 = "";

            if (obj.ContractorContactNumber2 == null)
                obj.ContractorContactNumber2 = "";

            if (obj.ContractorTIN == null)
                obj.ContractorTIN = "";

            if (obj.ContractorGSTNo == null)
                obj.ContractorGSTNo = "";

            if (obj.ContractorPAN == null)
                obj.ContractorPAN = "";

            if (obj.ContractorBankName == null)
                obj.ContractorBankName = "";

            if (obj.ContractorBankAccountNo == null)
                obj.ContractorBankAccountNo = "";

            if (obj.ContractorIFSC == null)
                obj.ContractorIFSC = "";

            if (obj.ContractorStatus == null)
                obj.ContractorStatus = "ACTIVE";

            SqlCommand com_update_Contractor = new SqlCommand
     (@"update Contractors set ContractorName=@ContractorName,ContractorAddress=@ContractorAddress,
ContractorWebsite=@ContractorWebsite,ContractorEmailID=@ContractorEmailID,ContractorLandline=@ContractorLandline,
ContractorContactName1=@ContractorContactName1,ContractorContactNumber1=@ContractorContactNumber1,
ContractorContactName2=@ContractorContactName2,ContractorContactNumber2=@ContractorContactNumber2,
@ContractorTIN=ContractorTIN,@ContractorGSTNo=ContractorGSTNo,@ContractorPAN=ContractorPAN,
@ContractorBankName=ContractorBankName,@ContractorBankAccountNo=ContractorBankAccountNo,
@ContractorIFSC=ContractorIFSC,ContractorDue=@ContractorDue,ContractorStatus=@ContractorStatus
where ContractorID=@ContractorID", con);

            com_update_Contractor.Parameters.AddWithValue("@ContractorName", obj.ContractorName);
            com_update_Contractor.Parameters.AddWithValue("@ContractorAddress", obj.ContractorAddress);
            com_update_Contractor.Parameters.AddWithValue("@ContractorWebsite", obj.ContractorWebsite);
            com_update_Contractor.Parameters.AddWithValue("@ContractorEmailID", obj.ContractorEmailID);
            com_update_Contractor.Parameters.AddWithValue("@ContractorLandline", obj.ContractorLandline);
            com_update_Contractor.Parameters.AddWithValue("@ContractorContactName1", obj.ContractorContactName1);
            com_update_Contractor.Parameters.AddWithValue("@ContractorContactNumber1", obj.ContractorContactNumber1);
            com_update_Contractor.Parameters.AddWithValue("@ContractorContactName2", obj.ContractorContactName2);
            com_update_Contractor.Parameters.AddWithValue("@ContractorContactNumber2", obj.ContractorContactNumber2);
            com_update_Contractor.Parameters.AddWithValue("@ContractorTIN", obj.ContractorTIN);
            com_update_Contractor.Parameters.AddWithValue("@ContractorGSTNo", obj.ContractorGSTNo);
            com_update_Contractor.Parameters.AddWithValue("@ContractorPAN", obj.ContractorPAN);
            com_update_Contractor.Parameters.AddWithValue("@ContractorBankName", obj.ContractorBankName);
            com_update_Contractor.Parameters.AddWithValue("@ContractorBankAccountNo", obj.ContractorBankAccountNo);
            com_update_Contractor.Parameters.AddWithValue("@ContractorIFSC", obj.ContractorIFSC);
            com_update_Contractor.Parameters.AddWithValue("@ContractorDue", obj.ContractorDue);
            com_update_Contractor.Parameters.AddWithValue("@ContractorStatus", obj.ContractorStatus);
            com_update_Contractor.Parameters.AddWithValue("@ContractorID", obj.ContractorID);

            con.Open();
            int count = com_update_Contractor.ExecuteNonQuery();
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

        public List<ContractorModel> GetContractors()
        {
            List<ContractorModel> list_contractors = new List<ContractorModel>();
            SqlCommand com_contractors = new SqlCommand("Select * from Contractors", con);
            con.Open();
            SqlDataReader dr_contractors = com_contractors.ExecuteReader();
            while (dr_contractors.Read())
            {
                ContractorModel model = new ContractorModel();
                model.ContractorID = dr_contractors.GetInt32(0);
                model.ContractorName = dr_contractors.GetString(1);
                model.ContractorAddress = dr_contractors.GetString(2);
                model.ContractorWebsite = dr_contractors.GetString(3);
                model.ContractorEmailID = dr_contractors.GetString(4);
                model.ContractorLandline = dr_contractors.GetString(5);
                model.ContractorContactName1 = dr_contractors.GetString(6);
                model.ContractorContactNumber1 = dr_contractors.GetString(7);
                model.ContractorContactName2 = dr_contractors.GetString(8);
                model.ContractorContactNumber2 = dr_contractors.GetString(9);
                model.ContractorTIN = dr_contractors.GetString(10);
                model.ContractorGSTNo = dr_contractors.GetString(11);
                model.ContractorPAN = dr_contractors.GetString(12);
                model.ContractorBankName = dr_contractors.GetString(13);
                model.ContractorBankAccountNo = dr_contractors.GetString(14);
                model.ContractorIFSC = dr_contractors.GetString(15);
                model.ContractorDue = dr_contractors.GetInt32(16);
                model.ContractorStatus = dr_contractors.GetString(17);
                list_contractors.Add(model);
            }
            con.Close();
            return list_contractors;
        }

        public bool ChangeStatusInactive(int ContractorID)
        {
            con.Open();
            SqlCommand com_update_Contractor = new SqlCommand
               (@"update Contractors set ContractorStatus='INACTIVE' where ContractorID=@ContractorID", con);
            com_update_Contractor.Parameters.AddWithValue("@ContractorID", ContractorID);
            int Count = com_update_Contractor.ExecuteNonQuery();
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

        public bool ChangeStatusActive(int ContractorID)
        {
            con.Open();
            SqlCommand com_update_Contractor = new SqlCommand
               (@"update Suppliers set ContractorStatus='ACTIVE' where ContractorID=@ContractorID", con);
            com_update_Contractor.Parameters.AddWithValue("@ContractorID", ContractorID);
            int Count = com_update_Contractor.ExecuteNonQuery();
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