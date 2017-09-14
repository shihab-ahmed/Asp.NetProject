using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using V.Doc_Entity;

namespace V.Doc_ASP.NET.Models.CustomModel
{
    public class DoctorModel:User
    {
        [Required]
        [Display(Name = "State")]
        public string Specialist { get; set; }

        // This property will hold all available states for selection
        public IEnumerable<SelectListItem> Specialist_List { get; set; }



        [System.ComponentModel.DataAnnotations.CompareAttribute("Password", ErrorMessage = "Confirm Password doesnt match")]
        public String ConfirmPassword { get; set; }
        public String isAvailable { get; set; }
        public String NotifyAccountCreatedStatus { get; set; }

        //[FileExtensions(ErrorMessage = "Only jpg, jpeg, png", Extensions = ".jpg,.jpeg,.png")]
        [Required(ErrorMessage = "Image File required")]
        public HttpPostedFileBase File { get; set; }
        public string UserExistMessage { get; set; }
        public string imgeFileNeedMessage { get; set; }

        [Required(ErrorMessage = "Experience Required")
            ,Range(1,30, ErrorMessage ="Range between 1-30")]
        public int Experience { get; set; }

        [Required(ErrorMessage = "About is required")]
        public String About { get; set; }


    }
}