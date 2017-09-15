using System.Collections.Generic;
using V.Doc_Entity;

namespace V.Doc_Service.Interfaces
{
    public interface IChatService
    {
        IEnumerable<Chat> GetAll(User sender,User reciever);
        IEnumerable<Chat> GetNewChat(int senderId, int recieverId, int lastChatId);
        int Insert(Chat chat);
        int Update(Chat chat);
        int Delete(int id);

    }
}
