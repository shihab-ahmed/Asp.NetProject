using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace V.Doc_ASP.NET.Models.CustomModel
{
    public class AdminProfileModel
    { 
        [StringLength(50, MinimumLength = 1, ErrorMessage = "First Name Length must be between 1-50")
            , Required(ErrorMessage = "First Name Required")
            , RegularExpression("^[a-zA-Z]*$", ErrorMessage = "Only String is allowed")]
        public String FirstName { get; set; }

        [StringLength(50, MinimumLength = 1, ErrorMessage = "Last Name Length must be between 1-50")
            , Required(ErrorMessage = "Last Name Required")
            , RegularExpression("^[a-zA-Z]*$", ErrorMessage = "Only String is allowed")]
        public String LastName { get; set; }

        [Required(ErrorMessage = "Email is Required"), RegularExpression(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$", ErrorMessage = "Not a valid email")]
        public String Email { get; set; }

        [Required(ErrorMessage = "Birthdate is Requeired")]
        public DateTime Birthdate { get; set; }

        public int Age { get; set; }

        [Required(ErrorMessage = "Gender not selected")]
        public String Gender { get; set; }

        public HttpPostedFileBase File { get; set; }

        public string ProfilePicture { get; set; }

        public string NotifyProfileChangeStatus { get; set; }

        public string imgeFileNeedMessage { get; set; }
    }
}