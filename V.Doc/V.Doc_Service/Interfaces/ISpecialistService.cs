using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using V.Doc_Entity;

namespace V.Doc_Service.Interfaces
{
    public interface ISpecialistService
    {
        IEnumerable<Specialist> GetAll();
        Specialist Get(int id);
        Specialist Get(String type);
        int Insert(Specialist user);
        int Update(Specialist user);
        int Delete(int id);
    }
}
