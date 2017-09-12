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

        public DateTime TimeCreated { get; set; }
        public DateTime TimeUpdated { get; set; }

        public virtual ICollection<Symptom> Symptoms { get; set; }
    }
}
