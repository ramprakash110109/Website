using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Mvc_XYZ_Apparels.Models
{
    public class SupplierModel
    {
        [Display(Name = "Supplier ID")]
        public int SupplierID { get; set; }

        [Required(ErrorMessage = "*")]
        [Display(Name = "Supplier Name")]
        [StringLength(200, MinimumLength = 3, ErrorMessage = "Maximum 200 characters Allowed")]
        public string SupplierName { get; set; }

        [Required(ErrorMessage = "*")]
        [Display(Name = "Mill Name")]
        [StringLength(200, MinimumLength = 3, ErrorMessage = "Maximum 200 characters Allowed")]
        public string MillName { get; set; }

        [Required(ErrorMessage = "*")]
        [Display(Name = "Supplier Address")]
        [StringLength(250, MinimumLength = 3, ErrorMessage = "Maximum 250 characters Allowed")]
        public string SupplierAddress { get; set; }

        [Display(Name = "Supplier Website")]
        public string SupplierWebsite { get; set; }

        [Display(Name = "Supplier Email ID")]
        [EmailAddress(ErrorMessage = "Invalid Email ID")]
        public string SupplierEmailID { get; set; }

        [Display(Name = "Supplier Landline")]
        public string SupplierLandline { get; set; }

        [Required(ErrorMessage = "*")]
        [Display(Name = "Supplier Contact1 Name")]
        public string SupplierContactName1 { get; set; }

        [Required(ErrorMessage = "*")]
        [Display(Name = "Supplier Contact1 Number")]
        public string SupplierContactNumber1 { get; set; }

        [Display(Name = "Supplier Contact2 Name")]
        public string SupplierContactName2 { get; set; }

        [Display(Name = "Supplier Contact2 Number")]
        public string SupplierContactNumber2 { get; set; }

        [Display(Name = "Supplier TIN")]
        public string SupplierTIN { get; set; }

        [Display(Name = "Supplier GSTNo")]
        public string SupplierGSTNo { get; set; }

        [Display(Name = "Supplier PAN")]
        public string SupplierPAN { get; set; }

        [Display(Name = "Supplier Bank Name")]
        public string SupplierBankName { get; set; }

        [Display(Name = "Supplier Bank Account Number")]
        public string SupplierBankAccountNo { get; set; }

        [Display(Name = "Supplier IFSC")]
        public string SupplierIFSC { get; set; }

        [Display(Name = "Supplier Due")]
        public int SupplierDue { get; set; }

        [Display(Name = "Supplier Status")]
        public string SupplierStatus { get; set; }
    }
}