using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using V.Doc_Entity;

namespace V.Doc_Data.Interfaces
{
    public interface IPatientDataAccess
    {
        IEnumerable<Patient> GetAll();
        Patient Get(int id);
        int Insert(Patient user);
        int Update(Patient user);
        int Delete(int id);
    }
}
