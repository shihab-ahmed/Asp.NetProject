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
       /* private IContactDataAccess ContactDataAccess;

        public ContactService(IContactDataAccess ContactDataAccess)
        {
            this.ContactDataAccess = ContactDataAccess;
        }
        public int Delete(int id)
        {
            return this.ContactDataAccess.Delete(id);
        }

        public Contact Get(int id, bool isIncludePatientAndDoctor = false)
        {
            return this.ContactDataAccess.Get(id, isIncludePatientAndDoctor);
        }

        public IEnumerable<Contact> GetAll(bool isIncludePatientAndDoctor = false)
        {
            return this.ContactDataAccess.GetAll(isIncludePatientAndDoctor);
        }

        public int Insert(Contact user)
        {
            return this.ContactDataAccess.Insert(user);
        }

        public int Update(Contact user)
        {
            return this.ContactDataAccess.Update(user);
        }*/
    }
}
