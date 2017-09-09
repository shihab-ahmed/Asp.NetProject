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
    public class MedicineController : Controller
    {
        // GET: Symptom
        public ActionResult Create()
        {
            MedicineModel medicineModel = new MedicineModel();

            LoadListOfDisease(medicineModel);


            return View(medicineModel);
        }
        private void LoadListOfDisease(MedicineModel medicineModel)
        {
            //Diseases
            IDiseaseService service = ServiceFactory.GetDiseaseService();
            IEnumerable<Disease> diseases = service.GetAll();
            medicineModel.DiseaseMiniModel = new List<DiseaseMiniModel>();
            foreach (var item in diseases)
            {
                DiseaseMiniModel sDM = new DiseaseMiniModel();
                sDM.Name = item.Name;
                sDM.id = item.Id;
                medicineModel.DiseaseMiniModel.Add(sDM);
            }

        }
        private void LoadListOfDisease(MedicineModel medicineModel, Medicine medicine)
        {
            medicineModel.Name = medicine.Name;
            medicineModel.Type = medicine.Type;
            medicineModel.Id = medicine.Id;

            IDiseaseService service = ServiceFactory.GetDiseaseService();
            IEnumerable<Disease> diseases = service.GetAll();
            medicineModel.DiseaseMiniModel = new List<DiseaseMiniModel>();
            foreach (var item in diseases)
            {
                DiseaseMiniModel sDM = new DiseaseMiniModel();
                sDM.Name = item.Name;
                sDM.id = item.Id;
                if (medicine.Diseases.Contains(item)) sDM.isSelected = true;

                medicineModel.DiseaseMiniModel.Add(sDM);
            }
        }
        [HttpPost]
        public ActionResult Create(MedicineModel model)
        {
            MedicineModel newSM = new MedicineModel();
            if (ModelState.IsValid)
            {
                Medicine medicine = new Medicine();
                medicine.Name = model.Name;
                medicine.Type = model.Type;
                medicine.Diseases = new List<Disease>();



                IDiseaseService IDS = ServiceFactory.GetDiseaseService();
                foreach (var item in model.DiseaseMiniModel)
                {
                    if (item.isSelected) medicine.Diseases.Add(IDS.Get(item.id));

                }

                IMedicineService service = ServiceFactory.GetMedicineService();
                service.Insert(medicine);


                LoadListOfDisease(newSM);
                newSM.NotifyStatus = "Information added";
                return View(newSM);
            }
            LoadListOfDisease(newSM);
            newSM.NotifyStatus = "Failed to add";
            return View(newSM);
        }
        public ActionResult Edit(int id)
        {
            IMedicineService service = ServiceFactory.GetMedicineService();
            Medicine medicine = service.Get(id);

            MedicineModel model = new MedicineModel();
            LoadListOfDisease(model, medicine);


            return View(model);
        }
        [HttpPost]
        public ActionResult Edit(MedicineModel model)
        {
            MedicineModel newSM = new MedicineModel();
            IMedicineService service = ServiceFactory.GetMedicineService();
            Medicine medicne = service.Get(model.Id);
            if (ModelState.IsValid)
            {



                medicne.Name = model.Name;
                medicne.Type = model.Type;
                medicne.Diseases = new List<Disease>();


                IDiseaseService IDS = ServiceFactory.GetDiseaseService();
                foreach (var item in model.DiseaseMiniModel)
                {
                    if (item.isSelected) medicne.Diseases.Add(IDS.Get(item.id));

                }

                service.Update(medicne);


                LoadListOfDisease(newSM, medicne);
                newSM.NotifyStatus = "Information updated";
                return View(newSM);
            }
            LoadListOfDisease(newSM, medicne);
            newSM.NotifyStatus = "Failed to update";
            return View(newSM);
        }
        public ActionResult Delete(int id)
        {
            IMedicineService service = ServiceFactory.GetMedicineService();
            service.Delete(id);
            return RedirectToAction("List");
        }
        public ActionResult List()
        {
            IMedicineService service = ServiceFactory.GetMedicineService();

            IEnumerable<Medicine> medicine = service.GetAll();
            List<MedicineModel> modelList = new List<MedicineModel>();
            foreach (var item in medicine)
            {
                MedicineModel sm = new MedicineModel();
                sm.Name = item.Name;
                sm.Type = item.Type;
                sm.Id = item.Id;
                foreach (var item2 in item.Diseases)
                {
                    sm.DiseaseString += item2.Name + ",";
                }
                modelList.Add(sm);
            }

            return View(modelList);
        }
    }
}