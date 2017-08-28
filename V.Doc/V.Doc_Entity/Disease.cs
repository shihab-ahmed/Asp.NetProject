using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace V.Doc_Entity
{
    public class Disease
    {
        [Key]
        public int Id { get; set; }
        [StringLength(50, MinimumLength = 1, ErrorMessage = "Name Length must be between 1-50")]
        public String Name { get; set; }
        [Required(ErrorMessage ="List of symptom required")]
        public IEnumerable<Symptom> Symptoms { get; set; }
        
    }
}
