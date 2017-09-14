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
    public class SpecialistController : Controller
    {
        private bool IsAdminAlive()
        {
            User user = (User)Session["User"];
            if (user == null) return false;
            else
            {
                return true;
            }

        }
        private bool IsPatientAlive()
        {
            Patient patient = (Patient)Session["Patient"];
            if (patient == null) return false;
            else
            {
                return true;
            }

        }
        [HttpPost]
        public JsonResult DoesNameExist(string order)
        {
            return Json(DoesUserExistInDatabase(order));
        }
        private bool DoesUserExistInDatabase(String userName)
        {
            ISpecialistService spec = ServiceFactory.GetSpecialistService();
            if (spec.Get(userName) != null) return true;
            else return false;
        }
        private bool IsDoctorAlive()
        {
            Doctor doctor = (Doctor)Session["Doctor"];
            if (doctor == null) return false;
            else
            {
                return true;
            }

        }
        // GET: Specialist
        public ActionResult CreateSpecialist()
        {
            return View(new SpecialistModel());
        }
        // GET: Specialist
        public ActionResult SpecialistFromAdminSite()
        {
            ISpecialistService service = ServiceFactory.GetSpecialistService();
            IEnumerable<Specialist> specialist=service.GetAll(true);

            List<SpecialistModel> SpecialistModel = new List<SpecialistModel>();
            foreach (var item in specialist)
            {
                SpecialistModel sM = new SpecialistModel();

                sM.Type = item.Type;
                sM.Id = item.Id;
                foreach (var item2 in item.Symptoms)
                {
                    sM.Symptom += item2.Name+ " ";
                }
                SpecialistModel.Add(sM);
            }
            return View(SpecialistModel);
        }
        [HttpPost]
        public ActionResult CreateSpecialist(SpecialistModel model)
        {
            if(ModelState.IsValid)
            {
                if(DoesUserExistInDatabase(model.Type))
                {
                    model.NotifyStatus = "type already exist";
                    return View(model);
                }
                Specialist specialist = new Specialist();
                specialist.Type = model.Type;
                specialist.Symptoms = new List<Symptom>();
                specialist.TimeCreated = DateTime.Now;
                specialist.TimeUpdated = DateTime.Now;

                ISpecialistService service = ServiceFactory.GetSpecialistService();
                service.Insert(specialist);

                SpecialistModel sM = new SpecialistModel();
                sM.NotifyStatus = "Information added";
                ModelState.Clear();

                return View(sM);
            }
            return View(model);
        }
        public ActionResult DeleteSpecialist(int id)
        {
            ISpecialistService service = ServiceFactory.GetSpecialistService();
            IDoctorService docService = ServiceFactory.GetDoctorService();
            ISymptomService symtomService = ServiceFactory.GetSymtomService();

            bool shouldDelete = true;

            foreach (var item in docService.GetAll())
            {
                if (item.SpecialistId == id && !shouldDelete)
                {
                    shouldDelete = false;
                    break;
                }
            }
            if(shouldDelete)
            {
                foreach (var item in symtomService.GetAll(true))
                {
                    foreach (var item2 in item.Specialists)
                    {
                        if (item2.Id == id && shouldDelete)
                        {
                            shouldDelete = false;
                            break;
                        }
                    }

                }
            }
            if (shouldDelete)service.Delete(id);
            return RedirectToAction("SpecialistFromAdminSite");
        }
        public ActionResult Edit(int id)
        {
            ISpecialistService service = ServiceFactory.GetSpecialistService();
            Specialist s=service.Get(id);

            SpecialistModel sm = new SpecialistModel();
            sm.Id = id;
            sm.Type = s.Type;
            return View(sm);
        }
        [HttpPost]
        public ActionResult Edit(SpecialistModel model)
        {
            ISpecialistService service = ServiceFactory.GetSpecialistService();
            Specialist specialist = service.Get(model.Id);



            if (ModelState.IsValid)
            {
                if (DoesUserExistInDatabase(model.Type))
                {
                    model.NotifyStatus = "type already exist";
                    return View(model);
                }
                specialist.Type = model.Type;
                specialist.TimeUpdated = DateTime.Now;

                service.Update(specialist);

                model.NotifyStatus = "Information added";
                ModelState.Clear();

                return View(model);
            }
            return View(model);
        }

    }
}