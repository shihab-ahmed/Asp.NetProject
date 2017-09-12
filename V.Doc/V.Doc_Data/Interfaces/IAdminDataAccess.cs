using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using V.Doc_Entity;

namespace V.Doc_Data.Interfaces
{
    public interface IAdminDataAccess
    {
        IEnumerable<Admin> GetAll(bool isExtra=false);
        Admin Get(int id, bool isExtra = false);
        Admin GetUsingUser(User user, bool isExtra = false);
        int Insert(Admin user);
        int Update(Admin user);
        int Delete(int id);
    }
}
