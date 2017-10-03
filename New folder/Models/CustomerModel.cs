using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Mvc_XYZ_Apparels.Models
{
    public class CustomerModel
    {
        [Display(Name = "Customer ID")]
        public int CustomerID { get; set; }

        [Required(ErrorMessage = "*")]
        [Display(Name = "Customer Name")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Maximum 100 characters Allowed")]
        public string CustomerName { get; set; }

        [Required(ErrorMessage = "*")]
        [Display(Name = "Customer Address")]
        [StringLength(250, MinimumLength = 3, ErrorMessage = "Maximum 250 characters Allowed")]
        public string CustomerAddress { get; set; }

        [Display(Name = "Customer Website")]
        public string CustomerWebsite { get; set; }

        [Display(Name = "Customer Email ID")]
        [EmailAddress(ErrorMessage = "Invalid Email ID")]
        public string CustomerEmailID { get; set; }

        [Display(Name = "Customer Landline")]
        public string CustomerLandline { get; set; }

        [Required(ErrorMessage = "*")]
        [Display(Name = "Customer Contact1 Name")]
        public string CustomerContactName1 { get; set; }

        [Required(ErrorMessage = "*")]
        [Display(Name = "Customer Contact1 Number")]
        public string CustomerContactNumber1 { get; set; }

        [Display(Name = "Customer Contact2 Name")]
        public string CustomerContactName2 { get; set; }

        [Display(Name = "Customer Contact2 Number")]
        public string CustomerContactNumber2 { get; set; }

        [Display(Name = "Customer Due")]
        public int CustomerDue { get; set; }

        [Display(Name = "Customer Status")]
        public string CustomerStatus { get; set; }
    }

}