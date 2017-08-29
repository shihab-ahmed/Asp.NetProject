using V.Doc_Entity;
using V.Doc_Service.Interfaces;

namespace V.Doc_Service.Abstract_Classes
{
    class ChatService : IChatService
    {
        private DatabaseContext databaseContext;

        public ChatService(DatabaseContext databaseContext)
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
