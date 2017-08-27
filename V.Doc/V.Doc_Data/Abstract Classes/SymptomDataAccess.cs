using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using V.Doc_Data.Interfaces;
using V.Doc_Entity;

namespace V.Doc_Data.Abstract_Classes
{
    class SymptomDataAccess : ISymptomDataAccess
    {
        private DatabaseContext databaseContext;

        public SymptomDataAccess(DatabaseContext databaseContext)
        {
            this.databaseContext = databaseContext;
        }

      /*  public int Delete(int id)
        {
            Symptom symptom = this.databaseContext.Symptoms.SingleOrDefault(x => x.Id == id);
            this.databaseContext.Users.Remove(user);
            return this.databaseContext.SaveChanges();
        }

        public Symptom Get(int id)
        {
            return this.databaseContext.Users.SingleOrDefault(x => x.Id == id);
        }

        public IEnumerable<Symptom> GetAll()
        {
            return this.databaseContext.Users.ToList();
        }

        public int Insert(Symptom user)
        {
            this.databaseContext.Users.Add(user);
            return this.databaseContext.SaveChanges();
        }

        public int Update(Symptom user)
        {
            Symptom userToUpdate = this.databaseContext.Users.SingleOrDefault(x => x.Id == user.Id);

            userToUpdate.FirstName = user.FirstName;
            userToUpdate.LastName = user.LastName;
            userToUpdate.Email = user.Email;
            userToUpdate.Birthdate = user.Birthdate;
            userToUpdate.Age = user.Age;
            userToUpdate.Password = user.Password;
            userToUpdate.Gender = user.Gender;


            return this.databaseContext.SaveChanges();
        }*/
    }
}
