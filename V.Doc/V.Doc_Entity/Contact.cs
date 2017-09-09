using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace V.Doc_Entity
{
    public class Contact
    {
        public int Id { get; set; }
        public int MyProperty { get; set; }
        public String Message { get; set; }

        public int PatientId { get; set; }
        [ForeignKey("PatientId")]
        public Patient Patient{get;set;}

        public int DoctorId { get; set; }
        [ForeignKey("DoctorId")]
        public Doctor Doctor{ get; set; }
    }
}
