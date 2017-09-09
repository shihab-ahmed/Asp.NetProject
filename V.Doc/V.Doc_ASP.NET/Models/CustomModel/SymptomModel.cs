using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using V.Doc_Entity;

namespace V.Doc_ASP.NET.Models.CustomModel
{
    public class SymptomModel:Symptom
    {
        public String NotifyStatus { get; set; }

        public List<SymptomDiseaseModel> DiseasesModel { get; set; }
        public List<SymptomSpecialistModel> SpecialistModel { get; set; }

       
    }
}