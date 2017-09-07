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
        [Display(Name = "Name")]
        public string Name { get; set; }

        // This property will hold a state, selected by user
        [Required]
        [Display(Name = "State")]
        public string Specialist { get; set; }

        // This property will hold all available states for selection
        public IEnumerable<SelectListItem> Specialist_List { get; set; }

    }
}