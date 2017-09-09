using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using V.Doc_ASP.NET.Models.CustomModel;
using V.Doc_Entity;
using V.Doc_Service;
using V.Doc_Service.Interfaces;

namespace V.Doc_ASP.NET.Controllers
{
    public class SymptomController : Controller
    {
        // GET: Symptom
        public ActionResult Create()
        {
            SymptomModel symptomModel = new SymptomModel();

            LoadListOfDiseasesAndSpecialist(symptomModel);
           

            return View(symptomModel);
        }
        private void LoadListOfDiseasesAndSpecialist(SymptomModel symptomModel)
        {
            //Diseases
            IDiseaseService service = ServiceFactory.GetDiseaseService();
            IEnumerable<Disease> diseases = service.GetAll();
            symptomModel.DiseasesModel = new List<DiseaseMiniModel>();
            foreach (var item in diseases)
            {
                DiseaseMiniModel sDM = new DiseaseMiniModel();
                sDM.Name = item.Name;
                sDM.id = item.Id;
                symptomModel.DiseasesModel.Add(sDM);
            }

            //Specialist
            ISpecialistService serviceSpecialist = ServiceFactory.GetSpecialistService();
            IEnumerable<Specialist> specialist = serviceSpecialist.GetAll();
            symptomModel.SpecialistModel = new List<SpecialistMiniModel>();
            foreach (var item in specialist)
            {
                SpecialistMiniModel sSM = new SpecialistMiniModel();
                sSM.Name = item.Type;
                sSM.id = item.Id;
                symptomModel.SpecialistModel.Add(sSM);

            }
        }
        private void LoadListOfDiseasesAndSpecialist(SymptomModel symptomModel,Symptom symptom)
        {
            symptomModel.Name = symptom.Name;
            symptomModel.Id = symptom.Id;

            IDiseaseService service = ServiceFactory.GetDiseaseService();
            IEnumerable<Disease> diseases = service.GetAll();
            symptomModel.DiseasesModel = new List<DiseaseMiniModel>();
            foreach (var item in diseases)
            {
                DiseaseMiniModel sDM = new DiseaseMiniModel();
                sDM.Name = item.Name;
                sDM.id = item.Id;
                if (symptom.Diseases.Contains(item)) sDM.isSelected = true;

                symptomModel.DiseasesModel.Add(sDM);
            }

            //Specialist
            ISpecialistService serviceSpecialist = ServiceFactory.GetSpecialistService();
            IEnumerable<Specialist> specialist = serviceSpecialist.GetAll();
            symptomModel.SpecialistModel = new List<SpecialistMiniModel>();
            foreach (var item in specialist)
            {
                SpecialistMiniModel sSM = new SpecialistMiniModel();
                sSM.Name = item.Type;
                sSM.id = item.Id;
                if (symptom.Specialists.Contains(item)) sSM.isSelected = true;
                symptomModel.SpecialistModel.Add(sSM);

            }
        }
        [HttpPost]
        public ActionResult Create(SymptomModel model)
        {
            SymptomModel newSM = new SymptomModel();
            if (ModelState.IsValid)
            {
                Symptom symptop = new Symptom();
                symptop.Name = model.Name;
                symptop.Diseases = new List<Disease>();
                symptop.Specialists = new List<Specialist>();


                IDiseaseService IDS = ServiceFactory.GetDiseaseService();
                foreach (var item in model.DiseasesModel)
                {
                    if(item.isSelected) symptop.Diseases.Add(IDS.Get(item.id));

                }

                ISpecialistService ISS = ServiceFactory.GetSpecialistService();
                foreach (var item in model.SpecialistModel)
                {
                    if (item.isSelected) symptop.Specialists.Add(ISS.Get(item.id));
                }


                ISymptomService service = ServiceFactory.GetSymtomService();
                service.Insert(symptop);

                
                LoadListOfDiseasesAndSpecialist(newSM);
                newSM.NotifyStatus = "Information added";
                return View(newSM);
            }
            LoadListOfDiseasesAndSpecialist(newSM);
            newSM.NotifyStatus = "Failed to add";
            return View(newSM);
        }
        public ActionResult Edit(int id)
        {
            ISymptomService service = ServiceFactory.GetSymtomService();
            Symptom symptom = service.Get(id);

            SymptomModel model = new SymptomModel();
            LoadListOfDiseasesAndSpecialist(model,symptom);


            return View(model);
        }
        [HttpPost]
        public ActionResult Edit(SymptomModel model)
        {
            SymptomModel newSM = new SymptomModel();
            ISymptomService service = ServiceFactory.GetSymtomService();
            Symptom symptop = service.Get(model.Id);
            if (ModelState.IsValid)
            {
                
                

                symptop.Name = model.Name;
                symptop.Diseases = new List<Disease>();
                symptop.Specialists = new List<Specialist>();


                IDiseaseService IDS = ServiceFactory.GetDiseaseService();
                foreach (var item in model.DiseasesModel)
                {
                    if (item.isSelected) symptop.Diseases.Add(IDS.Get(item.id));

                }

                ISpecialistService ISS = ServiceFactory.GetSpecialistService();
                foreach (var item in model.SpecialistModel)
                {
                    if (item.isSelected) symptop.Specialists.Add(ISS.Get(item.id));
                }


                service.Update(symptop);


                LoadListOfDiseasesAndSpecialist(newSM,symptop);
                newSM.NotifyStatus = "Information updated";
                return View(newSM);
            }
            LoadListOfDiseasesAndSpecialist(newSM, symptop);
            newSM.NotifyStatus = "Failed to update";
            return View(newSM);
        }
        public ActionResult Delete(int id)
        {
            ISymptomService service = ServiceFactory.GetSymtomService();
            service.Delete(id);
            return RedirectToAction("List");
        }
        public ActionResult List()
        {
            ISymptomService service = ServiceFactory.GetSymtomService();

            IEnumerable<Symptom> symptoms = service.GetAll();
            List<SymptomModel> modelList = new List<SymptomModel>();
            foreach (var item in symptoms)
            {
                SymptomModel sm = new SymptomModel();
                sm.Name = item.Name;
                sm.Id = item.Id;
                foreach (var item2 in item.Diseases)
                {
                    sm.DiseasesString += item2.Name + ",";
                }
                foreach (var item3 in item.Specialists)
                {
                    sm.SpecialistString += item3.Type + ",";
                }
                modelList.Add(sm);
            }

            return View(modelList);
        }
    }
}