using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using V.Doc_Data.Interfaces;
using V.Doc_Entity;

namespace V.Doc_Data.Abstract_Classes
{
    class MedicineDataAccess : IMedicineDataAccess
    {
        private DatabaseContext databaseContext;

        public MedicineDataAccess(DatabaseContext databaseContext)
        {
            this.databaseContext = databaseContext;
        }

        public int Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Medicine Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Medicine> GetAll()
        {
            throw new NotImplementedException();
        }

        public int Insert(Medicine user)
        {
            throw new NotImplementedException();
        }

        public int Update(Medicine user)
        {
            throw new NotImplementedException();
        }
    }
}
