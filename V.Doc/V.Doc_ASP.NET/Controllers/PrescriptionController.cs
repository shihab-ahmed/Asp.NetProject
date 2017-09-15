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
    public class PrescriptionController : Controller
    {
        // GET: Prescription
        public ActionResult Create(int id)
        {
            IPatientService ips = ServiceFactory.GetPatientService();
            Patient pat = ips.Get(id,true);
            Doctor doc=(Doctor)Session["Doctor"];

            
            PrescriptionModel pm = new PrescriptionModel();
            pm.PatientId = id;
            pm.DoctorId= doc.Id;
            pm.SelectedName = pat.User.FirstName + " " + pat.User.LastName;
            pm.TimeCreated = DateTime.Now;

            return View(pm);
        }
        [HttpPost]
        public ActionResult Create(PrescriptionModel model)
        {
            IPrescriptionService ips = ServiceFactory.GetPrescriptionService();
            Prescription pres = new Prescription();

            if(ModelState.IsValid)
            {
                pres.Title = model.Title;
                pres.PatientId = model.PatientId;
                pres.DoctorId = model.DoctorId;
                pres.TimeCreated = DateTime.Now;
                pres.TimeUpdated = DateTime.Now;
                pres.Details = model.Details;

                ips.Insert(pres);

                model.NotifyUpdate = "Prescription created";
                model.Details = "";
                return View(model);
            }

            return View(model);
        }
        public ActionResult DoctorViewList()
        {
            Doctor doc = (Doctor)Session["Doctor"];
            IPrescriptionService isp = ServiceFactory.GetPrescriptionService();
            IPatientService patService = ServiceFactory.GetPatientService();
            IEnumerable<Prescription> presList = isp.GetUsingDoctorId(doc.Id);
            List<PrescriptionModel> pmList = new List<PrescriptionModel>();

            foreach (var pres in presList)
            {
                Patient p = patService.Get(pres.PatientId,true);
                PrescriptionModel pm = new PrescriptionModel();


                pm.Title = pres.Title;
                pm.Image = p.User.ProfilePicture;
                pm.PatientName = p.User.FirstName + " " + p.User.LastName;

                pmList.Add(pm);


            }
            return View(pmList);
        }
        public ActionResult PatientViewList()
        {

            Patient pat = (Patient)Session["Patient"];
            IPrescriptionService isp = ServiceFactory.GetPrescriptionService();
            IDoctorService docService = ServiceFactory.GetDoctorService();
            IEnumerable<Prescription> presList = isp.GetUsingDoctorId(pat.Id);
            List<PrescriptionModel> pmList = new List<PrescriptionModel>();

            foreach (var pres in presList)
            {
                Doctor d = docService.Get(pres.DoctorId, true);
                PrescriptionModel pm = new PrescriptionModel();


                pm.Title = pres.Title;
                pm.Image = d.User.ProfilePicture;
                pm.DoctorName = d.User.FirstName + " " + d.User.LastName;

                pmList.Add(pm);


            }
            return View(pmList);
           
        }
    }
}