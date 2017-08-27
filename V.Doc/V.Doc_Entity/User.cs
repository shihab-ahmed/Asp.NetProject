using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace V.Doc_Entity
{
    public class User
    {
        public int Id { get; set; }
        public String FirstName { get; set; }
        public String LastName { get; set; }
        public String UserName { get; set; }
        public String Email { get; set; }
        public DateTime Birthdate { get; set; }
        public int Age { get; set; }
        public String Password { get; set; }
        public String Gender { get; set; }
    }
}
