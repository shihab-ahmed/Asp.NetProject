using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace V.Doc_ASP.NET.Models.CustomModel
{
    public class MedicineMiniModel
    {
        public int id { get; set; }
        public bool isSelected { get; set; }
        public String Name { get; set; }
        public String Type { get; set; }
    }
}