using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace V.Doc_Entity
{
    public class Symptom
    {
        [Key]
        public int Id { get; set; }
        [StringLength(50,MinimumLength =1,ErrorMessage ="Name lenght must be between 1 to 50")]
        public String  Name { get; set; }
        [StringLength(50, MinimumLength = 1, ErrorMessage = "Time duration lenght must be between 1 to 50")]
        public String TimeDuration { get; set; }
    }
}
