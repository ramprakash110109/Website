using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Mvc_XYZ_Apparels.Models
{
    public class ContractorModel
    {
        [Display(Name = "Contractor ID")]
        public int ContractorID { get; set; }

        [Required(ErrorMessage = "*")]
        [Display(Name = "Contractor Name")]
        [StringLength(200, MinimumLength = 3, ErrorMessage = "Maximum 200 characters Allowed")]
        public string ContractorName { get; set; }

        [Required(ErrorMessage = "*")]
        [Display(Name = "Contractor Address")]
        [StringLength(250, MinimumLength = 3, ErrorMessage = "Maximum 250 characters Allowed")]
        public string ContractorAddress { get; set; }

        [Display(Name = "Contractor Website")]
        public string ContractorWebsite { get; set; }

        [Display(Name = "Contractor Email ID")]
        [EmailAddress(ErrorMessage = "Invalid Email ID")]
        public string ContractorEmailID { get; set; }

        [Display(Name = "Contractor Landline")]
        public string ContractorLandline { get; set; }

        [Required(ErrorMessage = "*")]
        [Display(Name = "Contractor Contact1 Name")]
        public string ContractorContactName1 { get; set; }

        [Required(ErrorMessage = "*")]
        [Display(Name = "Contractor Contact1 Number")]
        public string ContractorContactNumber1 { get; set; }

        [Display(Name = "Contractor Contact2 Name")]
        public string ContractorContactName2 { get; set; }

        [Display(Name = "Contractor Contact2 Number")]
        public string ContractorContactNumber2 { get; set; }

        [Display(Name = "Contractor TIN")]
        public string ContractorTIN { get; set; }

        [Display(Name = "Contractor GSTNo")]
        public string ContractorGSTNo { get; set; }

        [Display(Name = "Contractor PAN")]
        public string ContractorPAN { get; set; }

        [Display(Name = "Contractor Bank Name")]
        public string ContractorBankName { get; set; }

        [Display(Name = "Contractor Bank Account Number")]
        public string ContractorBankAccountNo { get; set; }

        [Display(Name = "Contractor IFSC")]
        public string ContractorIFSC { get; set; }

        [Display(Name = "Contractor Due")]
        public int ContractorDue { get; set; }

        [Display(Name = "Contractor Status")]
        public string ContractorStatus { get; set; }
    }
}