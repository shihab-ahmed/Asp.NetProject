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
    class SpecialistService : ISpecialistService
    {
        private ISpecialistDataAccess specialistDataAccess;

        public SpecialistService(ISpecialistDataAccess specialistDataAccess)
        {
            this.specialistDataAccess = specialistDataAccess;
        }
        public int Delete(int id)
        {
            return this.specialistDataAccess.Delete(id);
        }

        public Specialist Get(int id)
        {
            return this.specialistDataAccess.Get(id);
        }

        public IEnumerable<Specialist> GetAll()
        {
            return this.specialistDataAccess.GetAll();
        }

        public int Insert(Specialist specialist)
        {
            return this.specialistDataAccess.Insert(specialist);
        }

        public int Update(Specialist specialist)
        {
            return this.specialistDataAccess.Update(specialist);
        }
    }
}
