using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace V.Doc_ASP.NET.Models.CustomModel
{
    public class ChatMessageModel
    {
        public int id { get; set; }
        public string image { get; set; }
        public bool isSender { get; set; }
        public String Name { get; set; }
        public String Message { get; set; }

    }
}