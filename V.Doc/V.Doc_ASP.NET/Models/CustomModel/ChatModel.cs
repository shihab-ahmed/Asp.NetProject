using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace V.Doc_ASP.NET.Models.CustomModel
{
    public class ChatModel
    {
        public int SelectedUserId { get; set; }
        public int SenderId { get; set; }
        public String SelectedUserImage { get; set; }
        public String SelectedUserName { get; set; }
        public int LastMessageId { get; set; }
    }
}