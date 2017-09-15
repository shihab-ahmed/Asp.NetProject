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
            return this.databaseContext.Chats.OrderByDescending(x => x.SenderId == sender.Id||x.RecieverId==sender.Id||x.SenderId==reciever.Id ||x.RecieverId==reciever.Id).ToList();
        }

        public IEnumerable<Chat> GetNewChat(int senderId, int recieverId, int lastChatId)
        {
            return this.databaseContext.Chats.OrderByDescending(x => x.SenderId == senderId || x.RecieverId == senderId || x.SenderId == recieverId || x.RecieverId == recieverId).Where(x=>x.Id>lastChatId).ToList();
        }

        public int Insert(Chat chat)
        {
            this.databaseContext.Chats.Add(chat);
            return this.databaseContext.SaveChanges();
        }

        public int Update(Chat chat)
        {
            Chat chatToUpdate = this.databaseContext.Chats.SingleOrDefault(x => x.Id == chat.Id);
            chatToUpdate.Message = chat.Message;
            return this.databaseContext.SaveChanges();
        }
    }
}
