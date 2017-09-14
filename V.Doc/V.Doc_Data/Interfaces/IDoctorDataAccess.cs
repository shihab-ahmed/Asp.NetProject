using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using V.Doc_Entity;

namespace V.Doc_Data.Interfaces
{
    public interface IDoctorDataAccess
    {
        IEnumerable<Doctor> GetAll(bool isIncludeUser_Specialist_ContactList=false);
        Doctor Get(int id, bool isIncludeUser_Specialist_ContactList = false);
        Doctor GetUsingUser(User user, bool isExtra = false);
        IEnumerable<Doctor> Search(String SearchBy, String SearchValue);
        int Insert(Doctor user);
        int Update(Doctor user);
        int Delete(int id);
    }
}
