using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Mvc_XYZ_Apparels.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "*")]
        [Display(Name = "User ID : ")]
        public string UserID { get; set; }

        [Required(ErrorMessage = "*")]
        [Display(Name = "User Password : ")]
        [DataType(DataType.Password)]
        public string UserPassword { get; set; }

        [Display(Name = "Remember Me :")]
        public bool RememberMe { get; set; }

        [Required(ErrorMessage = "*")]
        public string UserType { get; set; }
    }
}