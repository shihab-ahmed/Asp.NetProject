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
    class UserService : IUserDataAccess
    {
        private DatabaseContext databaseContext;

        public UserService(DatabaseContext databaseContext)
        {
            this.databaseContext = databaseContext;
        }

        public int Delete(int id)
        {
            User user = this.databaseContext.Users.SingleOrDefault(x => x.Id == id);
            this.databaseContext.Users.Remove(user);
            return this.databaseContext.SaveChanges();
        }

        public User Get(int id)
        {
            return this.databaseContext.Users.SingleOrDefault(x => x.Id == id);
        }

        public IEnumerable<User> GetAll()
        {
            return this.databaseContext.Users.ToList();
        }

        public int Insert(User user)
        {
            this.databaseContext.Users.Add(user);
            return this.databaseContext.SaveChanges();
        }

        public int Update(User user)
        {
            User userToUpdate = this.databaseContext.Users.SingleOrDefault(x => x.Id == user.Id);

            userToUpdate.FirstName = user.FirstName;
            userToUpdate.LastName = user.LastName;
            userToUpdate.Email = user.Email;
            userToUpdate.Birthdate = user.Birthdate;
            userToUpdate.Age = user.Age;
            userToUpdate.Password = user.Password;
            userToUpdate.Gender = user.Gender;


            return this.databaseContext.SaveChanges();
        }

        public bool ValidateCredentials(User user)
        {
            User usr = this.databaseContext.Users.SingleOrDefault(x => x.UserName == user.UserName && x.Password == user.Password);
            if (usr == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
