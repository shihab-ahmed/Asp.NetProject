using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace V.Doc_Entity
{
    public class Doctor
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage ="Experience Required")]
        public int Experience { get; set; }
        [StringLength(50, MinimumLength = 1, ErrorMessage = "Specialist Length must be between 1-50")]
        public String Specialist { get; set; }
        [StringLength(500, MinimumLength = 1, ErrorMessage = "About Length must be between 1-500")]
        public String About { get; set; }
        public bool isAvailable { get; set; }

        public int UserId { get; set; }

        [ForeignKey("UserId")]
        public User User { get; set; }
    }
}
