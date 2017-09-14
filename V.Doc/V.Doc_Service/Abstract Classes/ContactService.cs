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
    class ContactService : IContactService
    {
        private IContactDataAccess ContactDataAccess;

        public ContactService(IContactDataAccess ContactDataAccess)
        {
            this.ContactDataAccess = ContactDataAccess;
        }
        public int Delete(int id)
        {
            return this.ContactDataAccess.Delete(id);
        }

        public Contact Get(int id)
        {
            return this.ContactDataAccess.Get(id);
        }

        public IEnumerable<Contact> GetAll()
        {
            return this.ContactDataAccess.GetAll();
        }

        public List<Contact> GetUsingDoctor(int id)
        {
            return this.ContactDataAccess.GetUsingDoctor(id);
        }

        public List<Contact> GetUsingPatient(int id)
        {
            return this.ContactDataAccess.GetUsingPatient(id);
        }

        public int Insert(Contact user)
        {
            return this.ContactDataAccess.Insert(user);
        }

        public int Update(Contact user)
        {
            return this.ContactDataAccess.Update(user);
        }
    }
}
