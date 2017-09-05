using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using V.Doc_ASP.NET.Models.CustomModel;
using V.Doc_Data;
using V.Doc_Entity;
using V.Doc_Service;
using V.Doc_Service.Interfaces;
using V.Doc_Utilities;

namespace V.Doc_ASP.NET.Controllers
{
    public class PatientAccountController : Controller
    {

        // GET: Patient
        public ActionResult CreateAccount()
        {
            DatabaseContext context = new DatabaseContext();
            context.Users.ToList();
            return View();
        }
        [HttpPost]
        public ActionResult CreateAccount(PatientModel patientModel)
        {
            if (ModelState.IsValid)
            {
                User user = new User();
                Patient Patient = new Patient();

                if(DoesUserExist(patientModel.UserName))
                {
                    patientModel.UserExistMessage = "Sorry user already exist";
                    return View(patientModel);
                }

                LoadToUserAndPatient(patientModel,user,Patient);
                IPatientService patientService = ServiceFactory.GetPatientService();
                patientService.Insert(Patient);
                ModelState.Clear();
                patientModel.NotifyMessage = "Account Created";
                return View(patientModel);
            }
            else
            {
                return View(patientModel);
            }
        }
        [HttpGet]
        public ActionResult AccountDetails(int id)
        {
            PatientModel patientModel = new PatientModel();
            LoadToPatientModel(patientModel,id);
            return View(patientModel);
        }
        [HttpGet]
        public ActionResult EditAccount(int id)
        {
            PatientModel patientModel = new PatientModel();
            LoadToPatientModel(patientModel, id);
            return View(patientModel);
        }
        [HttpPost]
        public ActionResult EditProfile(PatientModel patientModel)
        {
            IPatientService patientService = ServiceFactory.GetPatientService();
            return View();
        }
        [HttpPost]
        public ActionResult EditPassword(PatientModel patientModel)
        {
           
            return View();
        }

        private void LoadToPatientModel(PatientModel PatientModel,int id)
        {
            IPatientService patientService = ServiceFactory.GetPatientService();
            Patient patient = patientService.Get(id,true);

            PatientModel.FirstName = patient.User.FirstName;
            PatientModel.LastName = patient.User.LastName;
            PatientModel.Email = patient.User.Email;
            PatientModel.Type = patient.User.Type;
            PatientModel.Gender = patient.User.Gender;
            PatientModel.Birthdate = patient.User.Birthdate;
            PatientModel.Age = patient.User.Age;
            PatientModel.ProfilePicture = patient.User.ProfilePicture;
        }
        private void LoadToUserAndPatient(PatientModel PatientModel,User user,Patient patient)
        {
            user.FirstName = PatientModel.FirstName;
            user.LastName = PatientModel.LastName;
            user.UserName = PatientModel.UserName;
            user.Email = PatientModel.Email;
            user.Birthdate = PatientModel.Birthdate;

            DateAndTime dateAndTime = new DateAndTime();
            user.Age = dateAndTime.GetAge(PatientModel.Birthdate);


            user.Password = PatientModel.Password;
            user.Gender = PatientModel.Gender;
            user.Type = Enum_UserType.Patient.ToString();

            if (PatientModel.File != null && PatientModel.File.ContentLength > 0)
            {
                string filename = Path.GetFileNameWithoutExtension(PatientModel.File.FileName);
                string extension = Path.GetExtension(PatientModel.File.FileName);
                filename = filename + user.UserName + extension;
                user.ProfilePicture = "~/UploadedFiles/Images/" + filename;
                filename = Path.Combine(Server.MapPath("~/UploadedFiles/Images/"), filename);
                PatientModel.File.SaveAs(filename);
            }
            patient.isAvailable = Enum_UserAvailableStatus.NotAvailable.ToString();
            patient.User = user;
           
        }
        private bool DoesUserExist(String userName)
        {
            IUserService user = ServiceFactory.GetUserService();
            if (user.Get(userName) != null) return true;
            else return false;
        }
    }
}