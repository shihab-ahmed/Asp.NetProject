using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace V.Doc_Entity
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [StringLength(50,MinimumLength =1,ErrorMessage ="First Name Length must be between 1-50")]
        public String FirstName { get; set; }

        [StringLength(50, MinimumLength = 1, ErrorMessage = "Last Name Length must be between 1-50")]
        public String LastName { get; set; }

        [StringLength(50, MinimumLength = 1, ErrorMessage = "User Name Length must be between 1-50")]
        public String UserName { get; set; }

        [Required(ErrorMessage ="Email is Required"),RegularExpression(@"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*")]
        public String Email { get; set; }

        [Required(ErrorMessage ="Birthdate is Requeired")]
        public DateTime Birthdate { get; set; }

        [Required(ErrorMessage = "Age is Requeired")]
        public int Age { get; set; }

        [Required(ErrorMessage = "Password is Requeired")]
        public String Password { get; set; }

        [Required(ErrorMessage = "Gender is Requeired")]
        public String Gender { get; set; }

        [Required(ErrorMessage = "Type is Requeired")]
        public String Type { get; set; }
    }
}
