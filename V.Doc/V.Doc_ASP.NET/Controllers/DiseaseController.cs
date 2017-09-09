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
    public class DiseaseController : Controller
    {
        public ActionResult Create()
        {
            DiseaseModel diseaseModel = new DiseaseModel();

            LoadListOfMedicineAndSymptom(diseaseModel);


            return View(diseaseModel);
        }
        private void LoadListOfMedicineAndSymptom(DiseaseModel diseaseModel)
        {
            //Symptom
            ISymptomService service = ServiceFactory.GetSymtomService();
            IEnumerable<Symptom> symptom = service.GetAll();
            diseaseModel.SymptomModel = new List<SymptomMiniModel>();
            foreach (var item in symptom)
            {
                SymptomMiniModel sDM = new SymptomMiniModel();
                sDM.Name = item.Name;
                sDM.id = item.Id;
                diseaseModel.SymptomModel.Add(sDM);
            }

            //Medicine
            IMedicineService serviceMedicine = ServiceFactory.GetMedicineService();
            IEnumerable<Medicine> medicine = serviceMedicine.GetAll();
            diseaseModel.MedicineModel = new List<MedicineMiniModel>();
            foreach (var item in medicine)
            {
                MedicineMiniModel sSM = new MedicineMiniModel();
                sSM.Name = item.Name;
                sSM.Type = item.Type;
                sSM.id = item.Id;
                diseaseModel.MedicineModel.Add(sSM);

            }
        }
        private void LoadListOfMedicineAndSymptom(DiseaseModel diseaseModel, Disease disease)
        {
            diseaseModel.Name = disease.Name;
            diseaseModel.Id = disease.Id;

            ISymptomService service = ServiceFactory.GetSymtomService();
            IEnumerable<Symptom> symptom = service.GetAll();
            diseaseModel.SymptomModel = new List<SymptomMiniModel>();
            foreach (var item in symptom)
            {

                SymptomMiniModel sDM = new SymptomMiniModel();
                sDM.Name = item.Name;
                sDM.id = item.Id;
                if (disease.Symptoms.Contains(item)) sDM.isSelected = true;
                diseaseModel.SymptomModel.Add(sDM);

            }

            //Medicine
            IMedicineService serviceMedicine = ServiceFactory.GetMedicineService();
            IEnumerable<Medicine> medicine = serviceMedicine.GetAll();
            diseaseModel.MedicineModel = new List<MedicineMiniModel>();
            foreach (var item in medicine)
            {
                MedicineMiniModel sSM = new MedicineMiniModel();
                sSM.Name = item.Name;
                sSM.Type = item.Type;
                sSM.id = item.Id;
                if (disease.Medicines.Contains(item)) sSM.isSelected = true;
                diseaseModel.MedicineModel.Add(sSM);

            }
        }
        [HttpPost]
        public ActionResult Create(DiseaseModel model)
        {
            DiseaseModel newSM = new DiseaseModel();
            if (ModelState.IsValid)
            {
                Disease disease = new Disease();
                disease.Name = model.Name;
                disease.Symptoms = new List<Symptom>();
                disease.Medicines = new List<Medicine>();


                ISymptomService ISS = ServiceFactory.GetSymtomService();
                foreach (var item in model.SymptomModel)
                {
                    if (item.isSelected) disease.Symptoms.Add(ISS.Get(item.id));

                }

                IMedicineService IMS = ServiceFactory.GetMedicineService();
                foreach (var item in model.MedicineModel)
                {
                    if (item.isSelected) disease.Medicines.Add(IMS.Get(item.id));
                }


                IDiseaseService service = ServiceFactory.GetDiseaseService();
                service.Insert(disease);


                LoadListOfMedicineAndSymptom(newSM);
                newSM.NotifyStatus = "Information added";
                return View(newSM);
            }
            LoadListOfMedicineAndSymptom(newSM);
            newSM.NotifyStatus = "Failed to add";
            return View(newSM);
        }
        public ActionResult Edit(int id)
        {
            IDiseaseService service = ServiceFactory.GetDiseaseService();
            Disease disease = service.Get(id);

            DiseaseModel model = new DiseaseModel();
            LoadListOfMedicineAndSymptom(model, disease);


            return View(model);
        }
        [HttpPost]
        public ActionResult Edit(DiseaseModel model)
        {
            DiseaseModel newSM = new DiseaseModel();

            IDiseaseService service = ServiceFactory.GetDiseaseService();
            Disease disease = service.Get(model.Id);
            if (ModelState.IsValid)
            {
                disease.Name = model.Name;
                disease.Symptoms = new List<Symptom>();
                disease.Medicines = new List<Medicine>();


                ISymptomService IDS = ServiceFactory.GetSymtomService();
                foreach (var item in model.SymptomModel)
                {
                    if (item.isSelected) disease.Symptoms.Add(IDS.Get(item.id));

                }

                IMedicineService ISS = ServiceFactory.GetMedicineService();
                foreach (var item in model.MedicineModel)
                {
                    if (item.isSelected) disease.Medicines.Add(ISS.Get(item.id));
                }


                service.Update(disease);


                LoadListOfMedicineAndSymptom(newSM, disease);
                newSM.NotifyStatus = "Information updated";
                return View(newSM);
            }
            LoadListOfMedicineAndSymptom(newSM, disease);
            newSM.NotifyStatus = "Failed to update";
            return View(newSM);
        }
        public ActionResult Delete(int id)
        {
            IDiseaseService service = ServiceFactory.GetDiseaseService();
            service.Delete(id);
            return RedirectToAction("List");
        }
        public ActionResult List()
        {
            IDiseaseService service = ServiceFactory.GetDiseaseService();

            IEnumerable<Disease> diseases = service.GetAll(true);
            List<DiseaseModel> modelList = new List<DiseaseModel>();
            foreach (var item in diseases)
            {
                DiseaseModel sm = new DiseaseModel();
                sm.Name = item.Name;
                sm.Id = item.Id;
                foreach (var item2 in item.Symptoms)
                {
                    sm.SymptomString += item2.Name + ",";
                }
                foreach (var item3 in item.Medicines)
                {
                    sm.MedicineString += item3.Name + ",";
                }
                modelList.Add(sm);
            }

            return View(modelList);
        }
    }
}