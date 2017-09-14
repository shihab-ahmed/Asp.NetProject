using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using V.Doc_Entity;

namespace V.Doc_ASP.NET.Models.CustomModel
{
    public class SpecialistModel:Specialist
    {
        public String NotifyStatus { get; set; }
        public String NameExistStatus { get; set; }
        public String Symptom { get; set; }
    }
}