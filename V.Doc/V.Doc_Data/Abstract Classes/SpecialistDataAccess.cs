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
            Specialist specialist = this.databaseContext.Specialists.SingleOrDefault(x => x.Id == id);
            this.databaseContext.Specialists.Remove(specialist);
            return this.databaseContext.SaveChanges();
        }
        public Specialist Get(String Type, bool includeSymptoms = false)
        {
            if (includeSymptoms)
            {
                return this.databaseContext.Specialists.Include("Symptom").SingleOrDefault(x => x.Type == Type);
            }
            else
            {
                return this.databaseContext.Specialists.SingleOrDefault(x => x.Type == Type);
            }
        }

        public Specialist Get(int id, bool includeSymptoms = false)
        {
            if (includeSymptoms)
            {
                return this.databaseContext.Specialists.Include("Symptom").SingleOrDefault(x => x.Id == id);
            }
            else
            {
                return this.databaseContext.Specialists.SingleOrDefault(x => x.Id == id);
            }
        }

        public IEnumerable<Specialist> GetAll(bool includeSymptoms = false)
        {
            if (includeSymptoms)
            {
                return this.databaseContext.Specialists.Include("Symptom").ToList();
            }
            else
            {
                return this.databaseContext.Specialists.ToList();
            }
           
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
            return this.databaseContext.SaveChanges();
        }
    }
}
