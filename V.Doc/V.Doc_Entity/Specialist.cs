using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace V.Doc_Entity
{
    public class Specialist
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage ="Type is required")]
        public String Type { get; set; }
        [Required(ErrorMessage ="List of Symptoms Required")]
        public IEnumerable<Symptom> Symptoms { get; set; }
    }
}
