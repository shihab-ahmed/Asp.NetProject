using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using V.Doc_Entity;

namespace V.Doc_Service.Interfaces
{
    public interface IPrescriptionService
    {
        IEnumerable<Prescription> GetAll();
        IEnumerable<Prescription> GetUsingDoctorId(int id);
        IEnumerable<Prescription> GetUsingPatientId(int id);
        Prescription Get(int id);
        int Insert(Prescription user);
        int Update(Prescription user);
        int Delete(int id);
    }
}
