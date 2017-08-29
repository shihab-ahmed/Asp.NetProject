using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using V.Doc_Service.Interfaces;
using V.Doc_Entity;
using V.Doc_Data.Interfaces;

namespace V.Doc_Service.Abstract_Classes
{
    class DoctorService : IDoctorService
    {
        private IDoctorDataAccess doctorDataAccess;

        public DoctorService(IDoctorDataAccess doctorDataAccess)
        {
            this.doctorDataAccess = doctorDataAccess;
        }
        public int Delete(int id)
        {
            return this.doctorDataAccess.Delete(id);
        }

        public Doctor Get(int id)
        {
            return this.doctorDataAccess.Get(id);
        }

        public IEnumerable<Doctor> GetAll()
        {
            return this.doctorDataAccess.GetAll();
        }

        public int Insert(Doctor doctor)
        {
            return this.doctorDataAccess.Insert(doctor);
        }

        public int Update(Doctor doctor)
        {
            return this.doctorDataAccess.Update(doctor);
        }
    }
}
