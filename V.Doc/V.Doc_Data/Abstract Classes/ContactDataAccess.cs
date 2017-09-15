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
        private DatabaseContext databaseContext;

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

        public Contact Get(int id)
        {
            return this.databaseContext.Contacts.SingleOrDefault(x => x.Id == id);

        }

        public IEnumerable<Contact> GetAll()
        {
            return this.databaseContext.Contacts.ToList();
        }

        public List<Contact> GetUsingDoctor(int id)
        {
            return this.databaseContext.Contacts.Where(x=>x.DoctorId==id).ToList();
        }

        public List<Contact> GetUsingPatient(int id)
        {
            return this.databaseContext.Contacts.Where(x => x.PatientId == id).ToList();
        }

        public int Insert(Contact contact)
        {
            this.databaseContext.Contacts.Add(contact);
            return this.databaseContext.SaveChanges();
        }

        public int Update(Contact contact)
        {
            Contact contactToUpdate = this.databaseContext.Contacts.SingleOrDefault(x => x.Id == contact.Id);

            contactToUpdate.Message = contact.Message;
            contactToUpdate.TimeUpdated = contact.TimeUpdated;
            contactToUpdate.RequestStatus = contact.RequestStatus;



            return this.databaseContext.SaveChanges();
        }
    }
}
