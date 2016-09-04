using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AdminPanelFabQC.Models
{
    public class LoginDetails
    {
        [Required]
        [Display(Name = "User name")]
        public string userName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string pwd { get; set; }
        
        [Required]
        [Display(Name = "Company ID")]
        public string companyId { get; set; }

        [Display(Name = "Login Failed, please try again!!!")]
        public string showError { get; set; }
    }
}