using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace V.Doc_Entity
{
    public class Medicine
    {
        [Key]
        public int Id { get; set; }
        [StringLength(100, MinimumLength = 1, ErrorMessage = "Name Length must be between 1-50")]
        public String Name { get; set; }
        [StringLength(50, MinimumLength = 1, ErrorMessage = "Type Length must be between 1-50")]
        public String Type { get; set; }


        public virtual ICollection<Disease> Diseases { get; set; }
    }
}
