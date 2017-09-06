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
        private bool IsUserAlive()
        {
            Patient patient = (Patient)Session["Patient"];
            if (patient == null) return false;
            else
            {
                return true;
            }
            
        }
        // GET: Patient
        public ActionResult CreateAccount()
        {
            //DatabaseContext context = new DatabaseContext();
            //context.Users.ToList();
            return View();
        }
        [HttpPost]
        public ActionResult CreateAccount(PatientModel patientModel)
        {
            if (ModelState.IsValid)
            {
                User user = new User();
                Patient Patient = new Patient();

                if(DoesUserExistInDatabase(patientModel.UserName))
                {
                    patientModel.UserExistMessage = "Sorry user already exist";
                    return View(patientModel);
                }

                LoadToUserAndPatient(patientModel,user,Patient);
                IPatientService patientService = ServiceFactory.GetPatientService();
                patientService.Insert(Patient);
                ModelState.Clear();
                patientModel.NotifyAccountCreatedStatus = "Account Created";
                return View(patientModel);
            }
            else
            {
                return View(patientModel);
            }
        }
        [HttpGet]
        public ActionResult AccountDetails()
        {
            if (!IsUserAlive()) return RedirectToAction("Login", "Login");

            Patient patient = (Patient)Session["Patient"];
            PatientModel patientModel = new PatientModel();

            LoadToPatientModel(patientModel,patient);
            return View(patientModel);
        }
        [HttpGet]
        public ActionResult EditProfile()
        {
            if (!IsUserAlive()) return RedirectToAction("Login", "Login");

            Patient patient = (Patient)Session["Patient"];
            PatientProfileModel profileModel = new PatientProfileModel();

            LoadToProfileModel(profileModel,patient);
            return View(profileModel);
        }
        [HttpGet]
        public ActionResult EditPassword()
        {
            if (!IsUserAlive()) return RedirectToAction("Login", "Login");
            Patient patient = (Patient)Session["Patient"];

            PatientPasswordModel  passwordModel= new PatientPasswordModel();

           
            return View(passwordModel);
        }

        [HttpPost]
        public ActionResult EditProfile(PatientProfileModel profileModel)
        {
            if (!IsUserAlive()) return RedirectToAction("Login", "Login");
            if (ModelState.IsValid)
            {
                
                Patient patient = (Patient)Session["Patient"];
                patient.User.FirstName = profileModel.FirstName;
                patient.User.LastName = profileModel.LastName;
                patient.User.Email = profileModel.Email;
                patient.User.Gender = profileModel.Gender;
                patient.User.Birthdate = profileModel.Birthdate;

                DateAndTime dateAndTime = new DateAndTime();
                patient.User.Age = dateAndTime.GetAge(profileModel.Birthdate);

                if (profileModel.File != null && profileModel.File.ContentLength > 0)
                {
                    string filename = Path.GetFileNameWithoutExtension(profileModel.File.FileName);
                    string extension = Path.GetExtension(profileModel.File.FileName);
                    filename = filename + patient.User.UserName + extension;
                    patient.User.ProfilePicture = "~/UploadedFiles/Images/" + filename;
                    filename = Path.Combine(Server.MapPath("~/UploadedFiles/Images/"), filename);
                    profileModel.File.SaveAs(filename);
                }
                patient.isAvailable = profileModel.isAvailable;

                IPatientService patientService = ServiceFactory.GetPatientService();
                patientService.Update(patient);
                IUserService UserService = ServiceFactory.GetUserService();
                UserService.Update(patient.User);

                ReloadPatientInfo();

                LoadToProfileModel(profileModel, patient);

                profileModel.NotifyProfileChangeStatus = "Profile Updated";

                ModelState.Clear();

                return View(profileModel);
            }

            return View(profileModel);
        }
        [HttpPost]
        public ActionResult EditPassword(PatientPasswordModel patientModel)
        {
            if (!IsUserAlive()) return RedirectToAction("Login", "Login");
            if (ModelState.IsValid)
            {
                Patient patient = (Patient)Session["Patient"];

                if(patient.User.Password==patientModel.CurrentPassword)
                {
                    patient.User.Password = patientModel.NewPassword;

                    IUserService UserService = ServiceFactory.GetUserService();
                    UserService.Update(patient.User);

                    patientModel.NotifyUpdateStatus = "Password changed successfully";
                    ModelState.Clear();
                    return View(patientModel);
                }
                else
                {

                    patientModel.NotifyUpdateStatus = "Your Current password Doesnt match";
                    return View(patientModel);
                }
            }
            return View();
        }

        private void LoadToPatientProfileModel(PatientProfileModel PatientProfileModel, Patient patient)
        {
            PatientProfileModel.FirstName = patient.User.FirstName;
            PatientProfileModel.LastName = patient.User.LastName;
            PatientProfileModel.Email = patient.User.Email;
            PatientProfileModel.Gender = patient.User.Gender;
            PatientProfileModel.Birthdate = patient.User.Birthdate;
            PatientProfileModel.Age = patient.User.Age;
            PatientProfileModel.ProfilePicture = patient.User.ProfilePicture;
        }
        private void ReloadPatientInfo()
        {
            IPatientService patientService = ServiceFactory.GetPatientService();
            Patient patient = (Patient)Session["Patient"];
            patient = patientService.Get(patient.Id, true);
        }
        private void LoadToPatientModel(PatientModel PatientModel,Patient patient)
        {
            PatientModel.FirstName = patient.User.FirstName;
            PatientModel.LastName = patient.User.LastName;
            PatientModel.Email = patient.User.Email;
            PatientModel.Type = patient.User.Type;
            PatientModel.Gender = patient.User.Gender;
            PatientModel.Birthdate = patient.User.Birthdate;
            PatientModel.Age = patient.User.Age;
            PatientModel.ProfilePicture = patient.User.ProfilePicture;
        }
        private void LoadToProfileModel(PatientProfileModel profileModel, Patient patient)
        {
            profileModel.FirstName = patient.User.FirstName;
            profileModel.LastName = patient.User.LastName;
            profileModel.Email = patient.User.Email;
            profileModel.Gender = patient.User.Gender;
            profileModel.Birthdate = patient.User.Birthdate;
            profileModel.Age = patient.User.Age;
            profileModel.ProfilePicture = patient.User.ProfilePicture;
            profileModel.isAvailable = patient.isAvailable;
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
        private bool DoesUserExistInDatabase(String userName)
        {
            IUserService user = ServiceFactory.GetUserService();
            if (user.Get(userName) != null) return true;
            else return false;
        }
    }
}