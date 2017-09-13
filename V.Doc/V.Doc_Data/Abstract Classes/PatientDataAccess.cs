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

        public Patient Get(int id, bool includeUserAndContactList = false)
        {
            if (includeUserAndContactList)
            {
                return this.databaseContext.Patients.Include("User").SingleOrDefault(x => x.Id == id);
            }
            else
            {
                return this.databaseContext.Patients.SingleOrDefault(x => x.Id == id);
            }
            
        }

        public IEnumerable<Patient> GetAll(bool includeUserAndContactList = false)
        {
            if (includeUserAndContactList)
            {
                return this.databaseContext.Patients.Include("User").Include("ContactList").ToList();
            }
            else
            {
                return this.databaseContext.Patients.ToList();
            }
        }

        public Patient GetUsingUser(User user, bool includeUser = false)
        {
            if (includeUser)
            {
                return this.databaseContext.Patients.Include("User").SingleOrDefault(x => x.UserId == user.Id);
            }
            else
            {
                return this.databaseContext.Patients.SingleOrDefault(x => x.User.Id == user.Id);
            }
        }

        public int Insert(Patient patient)
        {
            this.databaseContext.Patients.Add(patient);
            this.databaseContext.SaveChanges();
            return patient.Id;
        }

        public int Update(Patient patient)
        {
            Patient patientToUpdate = this.databaseContext.Patients.SingleOrDefault(x => x.Id == patient.Id);

            patientToUpdate.isAvailable = patient.isAvailable;
            return this.databaseContext.SaveChanges();
        }
    }
}
