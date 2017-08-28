using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace V.Doc_Entity
{
    public class Chat
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage ="Sender Required")]
        public User Sender { get; set; }
        [Required(ErrorMessage ="Reciever Required")]
        public User Reciever { get; set; }
        [Required(ErrorMessage ="Time Required")]
        public DateTime Time { get; set; }
        public bool isSeenBySender { get; set; }
        public bool isSeenByReciever { get; set; }

    }
}
