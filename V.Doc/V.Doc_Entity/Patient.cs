using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace V.Doc_Entity
{
    public class Patient
    {
        [Key]
        public int Id { get; set; }
        public bool isAvailable { get; set; }
        [Required(ErrorMessage ="User Required")]
        public User User { get; set; }
        public IEnumerable<User> Relative { get; set; }
    }
}
