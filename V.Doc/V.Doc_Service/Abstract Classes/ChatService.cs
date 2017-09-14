using System;
using System.Collections.Generic;
using V.Doc_Data.Interfaces;
using V.Doc_Entity;
using V.Doc_Service.Interfaces;

namespace V.Doc_Service.Abstract_Classes
{
    class ChatService : IChatService
    {
        private IChatDataAccess chatDataAccess;

        public ChatService(IChatDataAccess chatDataAccess)
        {
            this.chatDataAccess = chatDataAccess;
        }

        public int Delete(int id)
        {
            return this.chatDataAccess.Delete(id);
        }

        public IEnumerable<Chat> GetAll(User sender, User reciever)
        {
            return this.chatDataAccess.GetAll(sender, reciever);
        }

        public int Insert(Chat chat)
        {
            return this.chatDataAccess.Insert(chat);
        }

        public int Update(Chat chat)
        {
            return this.chatDataAccess.Update(chat);
        }
    }
}
