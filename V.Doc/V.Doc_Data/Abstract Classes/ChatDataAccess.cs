using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using V.Doc_Data.Interfaces;
using V.Doc_Entity;

namespace V.Doc_Data.Abstract_Classes
{
    class ChatDataAccess : IChatDataAccess
    {
        private DatabaseContext databaseContext;

        public ChatDataAccess(DatabaseContext databaseContext)
        {
            this.databaseContext = databaseContext;
        }

        public int Delete(int id)
        {
            Chat chat = this.databaseContext.Chats.SingleOrDefault(x => x.Id == id);
            this.databaseContext.Chats.Remove(chat);
            return this.databaseContext.SaveChanges();
        }

        public Chat Get(int id)
        {
            return this.databaseContext.Chats.SingleOrDefault(x => x.Id == id);
        }

        public IEnumerable<Chat> GetAll(User sender,User reciever)
        {
            return this.databaseContext.Chats.OrderByDescending(x => x.Sender == sender||x.Reciever==sender||x.Sender==reciever ||x.Reciever==reciever).ToList();
        }

        public int Insert(Chat chat)
        {
            this.databaseContext.Chats.Add(chat);
            return this.databaseContext.SaveChanges();
        }

        public int Update(Chat chat)
        {
            Chat chatToUpdate = this.databaseContext.Chats.SingleOrDefault(x => x.Id == chat.Id);

            chatToUpdate.isSeenByReciever = chat.isSeenByReciever;
            chatToUpdate.isSeenBySender = chat.isSeenBySender;
            chatToUpdate.Message = chat.Message;
            return this.databaseContext.SaveChanges();
        }
    }
}
