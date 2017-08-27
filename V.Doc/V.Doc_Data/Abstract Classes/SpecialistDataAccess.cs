using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using V.Doc_Data.Interfaces;
using V.Doc_Entity;

namespace V.Doc_Data.Abstract_Classes
{
    class SpecialistDataAccess : ISpecialistDataAccess
    {
        private DatabaseContext databaseContext;

        public SpecialistDataAccess(DatabaseContext databaseContext)
        {
            this.databaseContext = databaseContext;
        }

        public int Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Specialist Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Specialist> GetAll()
        {
            throw new NotImplementedException();
        }

        public int Insert(Specialist user)
        {
            throw new NotImplementedException();
        }

        public int Update(Specialist user)
        {
            throw new NotImplementedException();
        }
    }
}
