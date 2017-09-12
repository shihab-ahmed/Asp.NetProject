using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace V.Doc_Entity
{
    public class Prescription
    {
        [Key]
        public int Id { get; set; }
        [StringLength(1000,MinimumLength =1,ErrorMessage = "Prescription detail must be between 1-1000")]
        public String Details { get; set; }



        public int DoctorId { get; set; }
        public int PatientId { get; set; }


        public DateTime TimeCreated { get; set; }
        public DateTime TimeUpdated { get; set; }


    }
}
