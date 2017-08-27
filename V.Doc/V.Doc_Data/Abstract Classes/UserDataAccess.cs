using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using V.Doc_Data.Interfaces;

namespace V.Doc_Data.Abstract_Classes
{
    class UserDataAccess : IUserDataAccess
    {
        private DatabaseContext databaseContext;

        public UserDataAccess(DatabaseContext databaseContext)
        {
            this.databaseContext = databaseContext;
        }
    }
}
