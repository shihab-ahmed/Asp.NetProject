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
        private DatabaseContext context;

        public ChatDataAccess(DatabaseContext context)
        {
            this.context = context;
        }

        public int Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Chat> GetAll(User sender, User reciever)
        {
            throw new NotImplementedException();
        }

        public int Insert(Chat chat)
        {
            throw new NotImplementedException();
        }

        public int Update(Chat employee)
        {
            throw new NotImplementedException();
        }
    }
}
