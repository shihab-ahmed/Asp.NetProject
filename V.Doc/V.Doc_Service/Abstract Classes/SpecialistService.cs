using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using V.Doc_Service.Interfaces;
using V.Doc_Entity;

namespace V.Doc_Service.Abstract_Classes
{
    class SpecialistService : ISpecialistDataAccess
    {
        private DatabaseContext databaseContext;

        public SpecialistService(DatabaseContext databaseContext)
        {
            this.databaseContext = databaseContext;
        }

        public int Delete(int id)
        {
            Specialist specialist = this.databaseContext.Specialists.SingleOrDefault(x => x.Id == id);
            this.databaseContext.Specialists.Remove(specialist);
            return this.databaseContext.SaveChanges();
        }

        public Specialist Get(int id)
        {
            return this.databaseContext.Specialists.SingleOrDefault(x => x.Id == id);
        }

        public IEnumerable<Specialist> GetAll()
        {
            return this.databaseContext.Specialists.ToList();
        }

        public int Insert(Specialist specialist)
        {
            this.databaseContext.Specialists.Add(specialist);
            return this.databaseContext.SaveChanges();
        }

        public int Update(Specialist specialist)
        {
            Specialist specialistToUpdate = this.databaseContext.Specialists.SingleOrDefault(x => x.Id == specialist.Id);

            specialistToUpdate.Type = specialist.Type;
            specialistToUpdate.Symptoms = specialist.Symptoms;
            return this.databaseContext.SaveChanges();
        }
    }
}
