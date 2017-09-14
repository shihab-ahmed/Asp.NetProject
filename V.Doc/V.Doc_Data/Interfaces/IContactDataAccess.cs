using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using V.Doc_Entity;

namespace V.Doc_Data.Interfaces
{
    public interface IContactDataAccess
    {
        IEnumerable<Contact> GetAll();
        Contact Get(int id);
        List<Contact> GetUsingPatient(int id);
        List<Contact> GetUsingDoctor(int id);
        int Insert(Contact user);
        int Update(Contact user);
        int Delete(int id);
    }
}
