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
        [Required(ErrorMessage ="Time Required")]
        public DateTime Time { get; set; }
        public bool isSeenBySender { get; set; }
        public bool isSeenByReciever { get; set; }

        public User Sender { get; set; }
        public User Reciever { get; set; }

    }
}
