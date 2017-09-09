using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using V.Doc_Entity;

namespace V.Doc_ASP.NET.Models.CustomModel
{
    public class MedicineModel:Medicine
    {
        public String NotifyStatus { get; set; }

        public List<DiseaseMiniModel> DiseaseMiniModel { get; set; }

        public String DiseaseString { get; set; }
    }
}