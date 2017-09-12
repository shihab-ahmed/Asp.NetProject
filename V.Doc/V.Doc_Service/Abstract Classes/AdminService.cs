using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using V.Doc_Service.Interfaces;
using V.Doc_Entity;
using V.Doc_Data.Interfaces;

namespace V.Doc_Service.Abstract_Classes
{
    class AdminService : IAdminService
    {
        private IAdminDataAccess adminDataAccess;
        public AdminService(IAdminDataAccess adminDataAccess)
        {
            this.adminDataAccess = adminDataAccess;
        }

        public int Delete(int id)
        {
            return this.adminDataAccess.Delete(id);
        }

        public Admin Get(int id, bool Extra = false)
        {
            return this.adminDataAccess.Get(id, Extra);
        }

        public IEnumerable<Admin> GetAll(bool isExtra = false)
        {
            return this.adminDataAccess.GetAll(isExtra);
        }

        public Admin GetUsingUser(User user, bool isIncludeExtra = false)
        {
            return this.adminDataAccess.GetUsingUser(user, isIncludeExtra);
        }

        public int Insert(Admin user)
        {
            return this.adminDataAccess.Insert(user);
        }

        public int Update(Admin user)
        {
            return this.adminDataAccess.Update(user);
        }
    }
}
