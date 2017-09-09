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
        IEnumerable<Doctor> GetAll(bool isIncludeUser_Specialist_ContactList = false);
        Doctor Get(int id, bool isIncludeUser_Specialist_ContactList = false);
        int Insert(Doctor user);
        int Update(Doctor user);
        int Delete(int id);
    }
}
