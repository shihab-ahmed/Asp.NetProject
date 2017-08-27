using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using V.Doc_Data.Interfaces;
using V.Doc_Entity;

namespace V.Doc_Data.Abstract_Classes
{
    class DoctorDataAccess : IDoctorDataAccess
    {
        private DatabaseContext databaseContext;

        public DoctorDataAccess(DatabaseContext databaseContext)
        {
            this.databaseContext = databaseContext;
        }

        public int Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Doctor Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Doctor> GetAll()
        {
            throw new NotImplementedException();
        }

        public int Insert(Doctor user)
        {
            throw new NotImplementedException();
        }

        public int Update(Doctor user)
        {
            throw new NotImplementedException();
        }
    }
}
