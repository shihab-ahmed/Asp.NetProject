using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using V.Doc_Entity;

namespace V.Doc_Data.Interfaces
{
    public interface ISpecialistDataAccess
    {
        IEnumerable<Specialist> GetAll();
        Specialist Get(int id);
        Specialist Get(String Type);
        int Insert(Specialist user);
        int Update(Specialist user);
        int Delete(int id);
    }
}
