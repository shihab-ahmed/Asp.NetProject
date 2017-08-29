using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using V.Doc_Entity;

namespace V.Doc_Service.Interfaces
{
    public interface IDoctorService
    {
        IEnumerable<Doctor> GetAll();
        Doctor Get(int id);
        int Insert(Doctor user);
        int Update(Doctor user);
        int Delete(int id);
    }
}
