using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using V.Doc_Entity;

namespace V.Doc_ASP.NET.Models.CustomModel
{
    public class DiseaseModel:Disease
    {
        public String NotifyStatus { get; set; }

        public List<MedicineMiniModel> MedicineModel { get; set; }
        public List<SymptomMiniModel> SymptomModel { get; set; }

        public String MedicineString { get; set; }
        public String SymptomString { get; set; }
    }
}