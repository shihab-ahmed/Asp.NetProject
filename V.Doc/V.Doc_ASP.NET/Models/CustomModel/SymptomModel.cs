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

        public List<DiseaseMiniModel> DiseasesModel { get; set; }
        public List<SpecialistMiniModel> SpecialistModel { get; set; }

        public String DiseasesString { get; set; }
        public String SpecialistString { get; set; }

    }
}