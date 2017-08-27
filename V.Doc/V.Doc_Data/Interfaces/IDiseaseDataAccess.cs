using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using V.Doc_Entity;

namespace V.Doc_Data.Interfaces
{
    public interface IDiseaseDataAccess
    {
        IEnumerable<Disease> GetAll();
        Disease Get(int id);
        int Insert(Disease user);
        int Update(Disease user);
        int Delete(int id);
    }
}
