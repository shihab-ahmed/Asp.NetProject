using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using V.Doc_Entity;

namespace V.Doc_Data.Interfaces
{
    public interface IUserDataAccess
    {
        IEnumerable<User> GetAll();
        User Get(int id);
        User Get(String UserName);
        IEnumerable<User> Search(String SearchBy,String SearchValue);
        int Insert(User user);
        int Update(User user);
        int Delete(int id);
        bool ValidateCredentials(User user);
    }
}
