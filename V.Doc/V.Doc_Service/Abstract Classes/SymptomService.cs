﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using V.Doc_Data.Interfaces;
using V.Doc_Entity;
using V.Doc_Service.Interfaces;

namespace V.Doc_Service.Abstract_Classes
{
    class SymptomService : ISymptomService
    {
        private ISymptomDataAccess symptomDataAccess;

        public SymptomService(ISymptomDataAccess symptomDataAccess)
        {
            this.symptomDataAccess = symptomDataAccess;
        }
        public int Delete(int id)
        {
            return this.symptomDataAccess.Delete(id);
        }

        public Symptom Get(int id, bool includeSpecialistAndMedicine = false)
        {
            return this.symptomDataAccess.Get(id,includeSpecialistAndMedicine);
        }

        public IEnumerable<Symptom> GetAll(bool includeSpecialistAndMedicine = false)
        {
            return this.symptomDataAccess.GetAll(includeSpecialistAndMedicine);
        }

        public int Insert(Symptom symptom)
        {
            return this.symptomDataAccess.Insert(symptom);
        }

        public int Update(Symptom symptom)
        {
            return this.symptomDataAccess.Update(symptom);
        }
    }
}
