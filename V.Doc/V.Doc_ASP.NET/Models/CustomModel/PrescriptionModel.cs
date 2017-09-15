using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using V.Doc_Entity;

namespace V.Doc_ASP.NET.Models.CustomModel
{
    public class PrescriptionModel:Prescription
    {
        public string SelectedName { get; set; }
        public string NotifyUpdate { get; set; }
        public string Image { get;  set; }
        public string PatientName { get; set; }
        public string DoctorName { get; set; }
        public List<String> ListOfDetails { get; set; }
    }
}