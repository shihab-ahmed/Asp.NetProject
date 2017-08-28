using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using V.Doc_Data.Interfaces;
using V.Doc_Entity;

namespace V.Doc_Data.Abstract_Classes
{
    class PatientDataAccess : IPatientDataAccess
    {
        private DatabaseContext databaseContext;

        public PatientDataAccess(DatabaseContext databaseContext)
        {
            this.databaseContext = databaseContext;
        }

        public int Delete(int id)
        {
            Patient patient = this.databaseContext.Patients.SingleOrDefault(x => x.Id == id);
            this.databaseContext.Patients.Remove(patient);
            return this.databaseContext.SaveChanges();
        }

        public Patient Get(int id)
        {
            return this.databaseContext.Patients.SingleOrDefault(x => x.Id == id);
        }

        public IEnumerable<Patient> GetAll()
        {
            return this.databaseContext.Patients.ToList();
        }

        public int Insert(Patient patient)
        {
            this.databaseContext.Patients.Add(patient);
            return this.databaseContext.SaveChanges();
        }

        public int Update(Patient patient)
        {
            Patient patientToUpdate = this.databaseContext.Patients.SingleOrDefault(x => x.Id == patient.Id);

            patientToUpdate.isAvailable = patient.isAvailable;
            patientToUpdate.Relative = patient.Relative;
            return this.databaseContext.SaveChanges();
        }
    }
}
