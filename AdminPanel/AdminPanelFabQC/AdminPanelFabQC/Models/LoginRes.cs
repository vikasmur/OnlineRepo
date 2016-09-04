using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AdminPanelFabQC.Models
{
    public class LoginRes
    {
        public string status { get; set; }
        public string errorMessage { get; set; }
        public userDetails userDetail { get; set; }
    }
}