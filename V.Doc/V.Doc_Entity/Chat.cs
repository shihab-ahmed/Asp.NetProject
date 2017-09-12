using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace V.Doc_Entity
{
    public class Chat
    {
        [Key]
        public int Id { get; set; }
        [StringLength(300,MinimumLength =1,ErrorMessage ="Message must be between 1-300")]
        public String Message { get; set; }
        [Required(ErrorMessage = "Time Required")]


       
        public int PatientId { get; set; }

        public int DoctorId { get; set; }


        public DateTime TimeCreated { get; set; }
        public DateTime TimeUpdated { get; set; }
    }
}
