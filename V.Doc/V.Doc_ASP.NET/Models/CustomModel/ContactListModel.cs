using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using V.Doc_Entity;

namespace V.Doc_ASP.NET.Models.CustomModel
{
    public class ContactListModel
    {
        public int ContactID { get; set; }
        public int PatientId { get; set; }
        public String PatientName { get; set; }
        public int DoctorId { get; set; }
        public String DoctorName { get; set; }
        public string PatientPic { get; set; }
        public string DoctorPic { get; set; }
        public string message { get; set; }
        public DateTime Time { get; set; }
        public String RequestStatus { get; set; }
        public String availableStatus { get; set; }
    }
}