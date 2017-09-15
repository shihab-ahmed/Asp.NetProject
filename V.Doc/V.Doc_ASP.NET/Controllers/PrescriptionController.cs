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
                pres.Details = model.Details.Replace("\r",",").Replace("\n",",");

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
            IEnumerable<Prescription> presList = isp.GetUsingDoctorId(doc.Id);
            List<PrescriptionModel> pmList = new List<PrescriptionModel>();

            IPatientService patService = ServiceFactory.GetPatientService();

            foreach (var pres in presList)
            {
                PrescriptionModel pm = new PrescriptionModel();
                pm.Title = pres.Title;              
                pm.PatientId = pres.PatientId;
                pm.Id = pres.Id;
                pmList.Add(pm);


            }
            foreach(PrescriptionModel pm in pmList)
            {
                
                Patient p=patService.Get(pm.PatientId,true);
                pm.Image = p.User.ProfilePicture;
                pm.PatientName = p.User.FirstName + " " + p.User.LastName;
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
               
                PrescriptionModel pm = new PrescriptionModel();


                pm.Title = pres.Title;
                pm.DoctorId = pres.DoctorId;
                pm.Id = pres.Id;
                pmList.Add(pm);


            }
            foreach (PrescriptionModel pm in pmList)
            {

                Doctor d = docService.Get(pm.DoctorId, true);
                pm.Image = d.User.ProfilePicture;
                pm.DoctorName = d.User.FirstName + " " + d.User.LastName;
            }
            return View(pmList);
           
        }
        public ActionResult PatientPrescriptionDetails(int id)
        {
            IPrescriptionService isp = ServiceFactory.GetPrescriptionService();
            Prescription pres = isp.Get(id);

            IDoctorService ips = ServiceFactory.GetDoctorService();
            Doctor doc = ips.Get(pres.DoctorId);


            PrescriptionModel pm = new PrescriptionModel();

            String[] s= pres.Details.Split(',');


            pm.ListOfDetails = new List<string>();
            foreach (var item in s)
            {
                pm.ListOfDetails.Add(item);
            }
            pm.Title = pres.Title;
            pm.TimeCreated = pres.TimeCreated;
            pm.TimeUpdated = pres.TimeUpdated;
            pm.PatientName = doc.User.FirstName + " " + doc.User.LastName;
            pm.Id = id;

            return View(pm);
        }
        public ActionResult DoctorPrescriptionDetails(int id)
        {
            IPrescriptionService isp = ServiceFactory.GetPrescriptionService();
            Prescription pres = isp.Get(id);

            IPatientService ips = ServiceFactory.GetPatientService();
            Patient pat = ips.Get(pres.PatientId);


            PrescriptionModel pm = new PrescriptionModel();
            String[] s = pres.Details.Split(',');


            pm.ListOfDetails = new List<string>();
            foreach (var item in s)
            {
                pm.ListOfDetails.Add(item);
            }


            pm.Title = pres.Title;
            pm.TimeCreated = pres.TimeCreated;
            pm.TimeUpdated = pres.TimeUpdated;
            pm.PatientName=pat.User.FirstName+" "+pat.User.LastName;
            pm.Id = id;

            return View(pm);
        }
        public ActionResult Delete(int id)
        {
            IPrescriptionService ps = ServiceFactory.GetPrescriptionService();
            ps.Delete(id);

            return RedirectToAction("DoctorViewList");
        }
        public ActionResult Edit(int id)
        {

            return View();
        }

    }
}