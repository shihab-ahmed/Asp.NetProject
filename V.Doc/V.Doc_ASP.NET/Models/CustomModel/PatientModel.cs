using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using V.Doc_Entity;

namespace V.Doc_ASP.NET.Models.CustomModel
{
    public class PatientModel:User
    {
        [CompareAttribute("Password", ErrorMessage = "Confirm Password doesnt match")]
        public String ConfirmPassword { get; set; }
        public String isAvailable { get; set; }
        public String NotifyAccountCreatedStatus { get; set; }

        //[FileExtensions(ErrorMessage = "Only jpg, jpeg, png", Extensions = ".jpg,.jpeg,.png")]
        [Required(ErrorMessage ="Image File required")]
        public HttpPostedFileBase File { get; set; }
        public IEnumerable<User> Relative { get; set; }
        public string UserExistMessage { get; set; }
        public string imgeFileNeedMessage { get; set; }

        public String NotifyProfileUpdatedStatus { get; set; }
        public String NotifyPasswordUpdatedStatus { get; set; }
    }
}