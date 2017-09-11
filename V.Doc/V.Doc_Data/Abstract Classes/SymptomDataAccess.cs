using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using V.Doc_Data.Interfaces;
using V.Doc_Entity;

namespace V.Doc_Data.Abstract_Classes
{
    class SymptomDataAccess : ISymptomDataAccess
    {
       /* private DatabaseContext databaseContext;

        public SymptomDataAccess(DatabaseContext databaseContext)
        {
            this.databaseContext = databaseContext;
        }

        public int Delete(int id)
        {
            Symptom symptom = this.databaseContext.Symptoms.SingleOrDefault(x => x.Id == id);
            this.databaseContext.Symptoms.Remove(symptom);
            return this.databaseContext.SaveChanges();
        }

        public Symptom Get(int id, bool includeSpecialistAndMedicine = false)
        {
            if (includeSpecialistAndMedicine)
            {
                return this.databaseContext.Symptoms.Include("Specialists").Include("Diseases").SingleOrDefault(x => x.Id == id);
            }
            else
            {
                return this.databaseContext.Symptoms.SingleOrDefault(x => x.Id == id);
            }
            
        }

        public IEnumerable<Symptom> GetAll(bool includeSpecialistAndMedicine = false)
        {
            if (includeSpecialistAndMedicine)
            {
                return this.databaseContext.Symptoms.Include("Specialists").Include("Diseases").ToList();
            }
            else
            {
                return this.databaseContext.Symptoms.ToList();
            }
        }

        public int Insert(Symptom symptom)
        {
            this.databaseContext.Symptoms.Add(symptom);
            return this.databaseContext.SaveChanges();
        }

        public int Update(Symptom symptom)
        {
            Symptom symptomToUpdate = this.databaseContext.Symptoms.SingleOrDefault(x => x.Id == symptom.Id);

            symptomToUpdate.Name = symptom.Name;
            return this.databaseContext.SaveChanges();
        }*/
    }
}
