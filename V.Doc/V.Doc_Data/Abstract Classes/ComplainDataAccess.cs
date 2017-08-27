using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using V.Doc_Data.Interfaces;
using V.Doc_Entity;

namespace V.Doc_Data.Abstract_Classes
{
    class ComplainDataAccess : IComplainDataAccess
    {
        private DatabaseContext databaseContext;

        public ComplainDataAccess(DatabaseContext databaseContext)
        {
            this.databaseContext = databaseContext;
        }

        public int Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Complain Get(int id, bool includeDepartment = false)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Complain> GetAll()
        {
            throw new NotImplementedException();
        }

        public int Insert(Complain employee)
        {
            throw new NotImplementedException();
        }

        public int Update(Complain employee)
        {
            throw new NotImplementedException();
        }
    }
}
