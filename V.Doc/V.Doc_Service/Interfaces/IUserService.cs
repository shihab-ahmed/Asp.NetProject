using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using V.Doc_Entity;

namespace V.Doc_Service.Interfaces
{
    public interface IUserService
    {
        IEnumerable<User> GetAll();
        User Get(int id);
        int Insert(User user);
        int Update(User user);
        int Delete(int id);
        bool ValidateCredentials(User user);
    }
}
