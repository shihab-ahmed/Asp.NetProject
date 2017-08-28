using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace V.Doc_Entity
{
    public class Complain
    {
        [Key]
        public int Id { get; set; }
        [StringLength(500, MinimumLength = 1, ErrorMessage = "Details Length must be between 1-500")]
        public String Details { get; set; }
        public bool isSeenByAdmin { get; set; }
        [Required(ErrorMessage ="User Required")]
        public User ComplainAgainst { get; set; }
    }
}
