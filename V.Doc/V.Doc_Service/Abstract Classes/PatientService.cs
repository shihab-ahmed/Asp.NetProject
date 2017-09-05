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
    class PatientService : IPatientService
    {
        private IPatientDataAccess patientDataAccess;

        public PatientService(IPatientDataAccess patientDataAccess)
        {
            this.patientDataAccess = patientDataAccess;
        }
        public int Delete(int id)
        {
            return this.patientDataAccess.Delete(id);
        }

        public Patient Get(int id, bool includeUser = false)
        {
            return this.patientDataAccess.Get(id, includeUser);
        }

        public IEnumerable<Patient> GetAll(bool includeUser = false)
        {
            return this.patientDataAccess.GetAll(includeUser);
        }

        public Patient GetUsingUser(User user, bool includeUser = false)
        {
            return this.patientDataAccess.GetUsingUser(user,includeUser);
        }

        public int Insert(Patient patient)
        {
            return this.patientDataAccess.Insert(patient);
        }

        public int Update(Patient patient)
        {
            return this.patientDataAccess.Update(patient);
        }
    }
}
