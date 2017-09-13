using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using V.Doc_Data.Interfaces;
using V.Doc_Entity;
using V.Doc_Service.Interfaces;

namespace V.Doc_Service.Abstract_Classes
{
    class UserService : IUserService
    {
        private IUserDataAccess userDataAccess;

        public UserService(IUserDataAccess userDataAccess)
        {
            this.userDataAccess = userDataAccess;
        }

        public int Delete(int id)
        {
            return this.userDataAccess.Delete(id);
        }

        public User Get(int id)
        {
            return this.userDataAccess.Get(id);
        }

        public User Get(string UserName)
        {
            return this.userDataAccess.Get(UserName);
        }

        public IEnumerable<User> GetAll()
        {
            return this.userDataAccess.GetAll();
        }

        public int Insert(User user)
        {
            return this.userDataAccess.Insert(user);
        }

        public IEnumerable<User> Search(string SearchBy, string SearchValue)
        {
            return this.userDataAccess.Search(SearchBy,SearchValue);
        }

        public int Update(User user)
        {
            return this.userDataAccess.Update(user);
        }

        public bool ValidateCredentials(User user)
        {
            return this.userDataAccess.ValidateCredentials(user);
        }
    }
}
