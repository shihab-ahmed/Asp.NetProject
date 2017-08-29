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
    class DiseaseService : IDiseaseService
    {
        private IDiseaseDataAccess diseaseDataAccess;

        public DiseaseService(IDiseaseDataAccess diseaseDataAccess)
        {
            this.diseaseDataAccess = diseaseDataAccess;
        }

        public int Delete(int id)
        {
            return this.diseaseDataAccess.Delete(id);
        }

        public Disease Get(int id)
        {
            return this.diseaseDataAccess.Get(id);
        }

        public IEnumerable<Disease> GetAll()
        {
            return this.diseaseDataAccess.GetAll();
        }

        public int Insert(Disease disease)
        {
            return this.diseaseDataAccess.Insert(disease);
        }

        public int Update(Disease disease)
        {
            return this.diseaseDataAccess.Update(disease);
        }
    }
}
