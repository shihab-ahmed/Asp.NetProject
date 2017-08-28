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
            Disease disease = this.databaseContext.Diseases.SingleOrDefault(x => x.Id == id);
            this.databaseContext.Diseases.Remove(disease);
            return this.databaseContext.SaveChanges();
        }
        public Disease Get(int id)
        {
            return this.databaseContext.Diseases.SingleOrDefault(x => x.Id == id);
        }

        public IEnumerable<Disease> GetAll()
        {
            return this.databaseContext.Diseases.ToList();
        }

        public int Insert(Disease disease)
        {
            this.databaseContext.Diseases.Add(disease);
            return this.databaseContext.SaveChanges();
        }

        public int Update(Disease disease)
        {
            Disease diseaseToUpdate = this.databaseContext.Diseases.SingleOrDefault(x => x.Id == disease.Id);

            diseaseToUpdate.Name = disease.Name;
            diseaseToUpdate.Symptoms = disease.Symptoms;

            return this.databaseContext.SaveChanges();
        }
    }
}
