using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using V.Doc_Entity;

namespace V.Doc_Service.Interfaces
{
    public interface IPatientService
    {
        IEnumerable<Patient> GetAll(bool includeUser = false);
        Patient Get(int id, bool includeUser = false);
        Patient GetUsingUser(User user, bool includeUser = false);
        int Insert(Patient user);
        int Update(Patient user);
        int Delete(int id);
    }
}
