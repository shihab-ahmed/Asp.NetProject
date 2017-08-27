using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using V.Doc_Data.Interfaces;
using V.Doc_Entity;

namespace V.Doc_Data.Abstract_Classes
{
    class DiseaseDataAccess : IDiseaseDataAccess
    {
        private DatabaseContext databaseContext;

        public DiseaseDataAccess(DatabaseContext databaseContext)
        {
            this.databaseContext = databaseContext;
        }

        public int Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Disease Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Disease> GetAll()
        {
            throw new NotImplementedException();
        }

        public int Insert(Disease user)
        {
            throw new NotImplementedException();
        }

        public int Update(Disease user)
        {
            throw new NotImplementedException();
        }
    }
}
