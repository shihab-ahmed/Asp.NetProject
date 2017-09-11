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
       /* private bool IsAdminAlive()
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
            return View();
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
                Specialist specialist = new Specialist();
                specialist.Type = model.Type;
                specialist.Symptoms = new List<Symptom>();

                ISpecialistService service = ServiceFactory.GetSpecialistService();
                service.Insert(specialist);

                model.NotifyStatus = "Information added";
                ModelState.Clear();

                return View();
            }
            return View(model);
        }
        public ActionResult DeleteSpecialist(int id)
        {
            ISpecialistService service = ServiceFactory.GetSpecialistService();

            service.Delete(id);
            return RedirectToAction("SpecialistFromAdminSite");
        }*/
    }
}