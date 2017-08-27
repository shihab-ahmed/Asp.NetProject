using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using V.Doc_Entity;

namespace V.Doc_Data.Interfaces
{
    public interface IMedicineDataAccess
    {
        IEnumerable<Medicine> GetAll();
        Medicine Get(int id);
        int Insert(Medicine user);
        int Update(Medicine user);
        int Delete(int id);
    }
}
