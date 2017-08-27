using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using V.Doc_Data.Interfaces;
using V.Doc_Entity;

namespace V.Doc_Data.Abstract_Classes
{
    class PrescriptionDataAccess : IPrescriptionDataAccess
    {
        private DatabaseContext databaseContext;

        public PrescriptionDataAccess(DatabaseContext databaseContext)
        {
            this.databaseContext = databaseContext;
        }

        public int Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Prescription Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Prescription> GetAll()
        {
            throw new NotImplementedException();
        }

        public int Insert(Prescription user)
        {
            throw new NotImplementedException();
        }

        public int Update(Prescription user)
        {
            throw new NotImplementedException();
        }
    }
}
