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

        public Disease Get(int id, bool includeSymptomAndMedicine = false)
        {
            return this.diseaseDataAccess.Get(id,includeSymptomAndMedicine);
        }

        public IEnumerable<Disease> GetAll(bool includeSymptomAndMedicine = false)
        {
            return this.diseaseDataAccess.GetAll(includeSymptomAndMedicine);
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
