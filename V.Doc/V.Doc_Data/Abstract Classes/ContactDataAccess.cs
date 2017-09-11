using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using V.Doc_Data.Interfaces;
using V.Doc_Entity;

namespace V.Doc_Data.Abstract_Classes
{
    class ContactDataAccess : IContactDataAccess
    {
       /* private DatabaseContext databaseContext;

        public ContactDataAccess(DatabaseContext databaseContext)
        {
            this.databaseContext = databaseContext;
        }

        public int Delete(int id)
        {
            Contact contact = this.databaseContext.Contacts.SingleOrDefault(x => x.Id == id);
            this.databaseContext.Contacts.Remove(contact);
            return this.databaseContext.SaveChanges();
        }

        public Contact Get(int id, bool isIncludePatientAndDoctor = false)
        {
            if (isIncludePatientAndDoctor)
            {
                return this.databaseContext.Contacts.Include("Patient").Include("Doctor").SingleOrDefault(x => x.Id == id);
            }
            else
            {
                return this.databaseContext.Contacts.SingleOrDefault(x => x.Id == id);
            }
            
        }

        public IEnumerable<Contact> GetAll(bool isIncludePatientAndDoctor = false)
        {
            if (isIncludePatientAndDoctor)
            {
                return this.databaseContext.Contacts.Include("Patient").Include("Doctor").ToList();
            }
            else
            {
                return this.databaseContext.Contacts.ToList();
            }
        }

        public int Insert(Contact contact)
        {
            this.databaseContext.Contacts.Add(contact);
            return this.databaseContext.SaveChanges();
        }

        public int Update(Contact contact)
        {
            Contact contactToUpdate = this.databaseContext.Contacts.SingleOrDefault(x => x.Id == contact.Id);

            return this.databaseContext.SaveChanges();
        }*/
    }
}
