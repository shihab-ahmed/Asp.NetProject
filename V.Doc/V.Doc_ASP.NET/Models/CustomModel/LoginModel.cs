using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace V.Doc_ASP.NET.Models.CustomModel
{
    public class LoginModel
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string ErrorMessage { get; set; }
    }
}