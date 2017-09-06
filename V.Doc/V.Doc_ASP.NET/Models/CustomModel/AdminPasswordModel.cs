using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace V.Doc_ASP.NET.Models.CustomModel
{
    public class AdminPasswordModel
    {
        [Required(ErrorMessage = "CurrentPassword is Requeired")]
        public String CurrentPassword { get; set; }

        [Required(ErrorMessage = "Password is Requeired")]
        public String NewPassword { get; set; }

        [CompareAttribute("NewPassword", ErrorMessage = "Confirm Password doesnt match")]
        public String ConfirmPassword { get; set; }

        public String NotifyUpdateStatus { get; set; }
    }
}