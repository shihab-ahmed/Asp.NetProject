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
            throw new NotImplementedException();
        }

        public Patient Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Patient> GetAll()
        {
            throw new NotImplementedException();
        }

        public int Insert(Patient user)
        {
            throw new NotImplementedException();
        }

        public int Update(Patient user)
        {
            throw new NotImplementedException();
        }
    }
}
