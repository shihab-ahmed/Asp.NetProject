using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace V.Doc_Entity
{
    public class Prescription
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage ="Time Required")]
        public DateTime Time { get; set; }
        [StringLength(1000,MinimumLength =1,ErrorMessage = "Prescription detail must be between 1-1000")]
        public String Details { get; set; }
        [Required(ErrorMessage = "Sender Required")]
        public User Sender { get; set; }
        [Required(ErrorMessage = "Reciever Required")]
        public User Reciever { get; set; }
        public bool isSeenBySender { get; set; }
        public bool isSeenByReciever { get; set; }
    }
}
