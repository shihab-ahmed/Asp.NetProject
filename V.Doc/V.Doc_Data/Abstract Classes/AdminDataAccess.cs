using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using V.Doc_Data.Interfaces;
using V.Doc_Entity;

namespace V.Doc_Data.Abstract_Classes
{
    class AdminDataAccess : IAdminDataAccess
    {
        private DatabaseContext databaseContext;

        public AdminDataAccess(DatabaseContext databaseContext)
        {
            this.databaseContext = databaseContext;
        }
        public int Delete(int id)
        {
            Admin admin = this.databaseContext.Admins.SingleOrDefault(x => x.Id == id);
            this.databaseContext.Admins.Remove(admin);
            return this.databaseContext.SaveChanges();
        }

        public Admin Get(int id, bool isExtra = false)
        {
            if (isExtra)
            {
                return this.databaseContext.Admins.Include("User").SingleOrDefault(x => x.Id == id);
            }
            else
            {
                return this.databaseContext.Admins.SingleOrDefault(x => x.Id == id);
            }
        }

        public IEnumerable<Admin> GetAll(bool isExtra = false)
        {
            if (isExtra)
            {
                return this.databaseContext.Admins.Include("User").ToList();
            }
            else
            {
                return this.databaseContext.Admins.ToList();
            }
        }

        public Admin GetUsingUser(User user, bool isExtra = false)
        {
            if (isExtra)
            {
                return this.databaseContext.Admins.Include("User").SingleOrDefault(x => x.User.Id == user.Id);
            }
            else
            {
                return this.databaseContext.Admins.SingleOrDefault(x => x.User.Id == user.Id);
            }
        }

        public int Insert(Admin user)
        {
            this.databaseContext.Admins.Add(user);
            return this.databaseContext.SaveChanges();
        }

        public int Update(Admin user)
        {
            Admin adminToUpdate = this.databaseContext.Admins.SingleOrDefault(x => x.Id == user.Id);



            return this.databaseContext.SaveChanges();
        }
    }
}
