using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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

        public DateTime TimeCreated { get; set; }
        public DateTime TimeUpdated { get; set; }

        public virtual ICollection<Specialist> Specialists { get; set; }

        public virtual ICollection<Disease> Diseases { get; set; }
    }
}
