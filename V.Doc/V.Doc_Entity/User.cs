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

        [StringLength(50,MinimumLength =1,ErrorMessage ="First Name Length must be between 1-50")
            ,Required(ErrorMessage ="First Name Required")
            ,RegularExpression("^[a-zA-Z]*$", ErrorMessage ="Only String is allowed")]
        public String FirstName { get; set; }

        [StringLength(50, MinimumLength = 1, ErrorMessage = "Last Name Length must be between 1-50")
            , Required(ErrorMessage = "Last Name Required")
            , RegularExpression("^[a-zA-Z]*$", ErrorMessage = "Only String is allowed")]
        public String LastName { get; set; }

       [StringLength(50, MinimumLength = 1, ErrorMessage = "User Name Length must be between 1-50")
            , Required(ErrorMessage = "User Name Required")]
        public String UserName { get; set; }

        [Required(ErrorMessage ="Email is Required"),RegularExpression(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$",ErrorMessage ="Not a valid email")]
        public String Email { get; set; }

        [Required(ErrorMessage = "Birthdate is Requeired")
           ]
        public DateTime Birthdate { get; set; }

        public int Age { get; set; }

        [Required(ErrorMessage = "Password is Requeired")]
        public String Password { get; set; }

        [Required(ErrorMessage ="Gender not selected")]
        public String Gender { get; set; }

        
        public String Type { get; set; }

        
        public String ProfilePicture { get; set; }


        public DateTime TimeAccountCreated { get; set; }

        public DateTime LastLogin { get; set; }

        public DateTime LastTimeNotificationChecked { get; set; }

        public String AccountAvailableStatus { get; set; }
    }
}
