using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using V.Doc_Entity;

namespace V.Doc_Service.Interfaces
{
    public interface ISymptomService
    {
        IEnumerable<Symptom> GetAll(bool includeSpecialistAndMedicine = false);
        Symptom Get(int id, bool includeSpecialistAndMedicine = false);
        int Insert(Symptom user);
        int Update(Symptom user);
        int Delete(int id);
    }
}
