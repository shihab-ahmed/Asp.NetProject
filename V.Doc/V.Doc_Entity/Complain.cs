using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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

        public int ComplainId { get; set; }


        public bool isActionTaken { get; set; }
    }
}
