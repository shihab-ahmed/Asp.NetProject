using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using V.Doc_ASP.NET.Models.CustomModel;
using V.Doc_Entity;
using V.Doc_Service;
using V.Doc_Service.Interfaces;
using V.Doc_Utilities;

namespace V.Doc_ASP.NET.Controllers
{
    public class DoctorAccountController : Controller
    {
        [HttpPost]
        public JsonResult MyAjaxCall(string order)
        {
            return Json(DoesUserExistInDatabase(order));
        }
        public ActionResult CreateAccount()
        {
            // Let's get all states that we need for a DropDownList
            var states = GetAllSpecialist();

            var model = new DoctorModel();

            model.Birthdate = DateTime.Now;
            // Create a list of SelectListItems so these can be rendered on the page
            model.Specialist_List = GetSelectListItems(states);

            return View(model);
        }

        //
        // 2. Action method for handling user-entered data when 'Sign Up' button is pressed.
        //
        private bool isImageValid(DoctorModel doctorModel, User user, Doctor doctor)
        {
            if (doctorModel.File != null && doctorModel.File.ContentLength > 0)
            {
                string filename = Path.GetFileNameWithoutExtension(doctorModel.File.FileName);
                string extension = Path.GetExtension(doctorModel.File.FileName);

                if (extension.ToLower() == ".jpg" || extension.ToLower() == ".jpeg" || extension.ToLower() == ".png")
                {
                    filename = filename + user.UserName + extension;
                    user.ProfilePicture = "~/UploadedFiles/Images/" + filename;
                    filename = Path.Combine(Server.MapPath("~/UploadedFiles/Images/"), filename);
                    doctorModel.File.SaveAs(filename);
                    doctor.User = user;

                    return true;
                }
                else
                {
                    return false;
                }

            }
            else
            {
                return false;
            }

        }
        [HttpPost]
        public ActionResult CreateAccount(DoctorModel doctorModel)
        {
             var states = GetAllSpecialist();
            doctorModel.Specialist_List = GetSelectListItems(states);
            if (ModelState.IsValid)
             {
                 User user = new User();
                 Doctor doctor = new Doctor();


                 if (DoesUserExistInDatabase(doctorModel.UserName))
                 {

                     doctorModel.Specialist_List = GetSelectListItems(states);
                     doctorModel.UserExistMessage = "Sorry user already exist";
                     return View(doctorModel);
                 }
                if (!isImageValid(doctorModel, user, doctor))
                {
                    doctorModel.Specialist_List = GetSelectListItems(states);
                    doctorModel.imgeFileNeedMessage = "Image(jpg,jpeg,png) file required";
                    return View(doctorModel);
                }

                LoadToUserAndDoctor(doctorModel, user, doctor);

                user.TimeAccountCreated = DateTime.Now;
                user.LastLogin = DateTime.Now;
                user.LastTimeNotificationChecked = DateTime.Now;
                IDoctorService doctorService = ServiceFactory.GetDoctorService();
                doctorService.Insert(doctor);
                ModelState.Clear();


                 doctorModel.NotifyAccountCreatedStatus = "Account Created";
                 doctorModel.Specialist_List = GetSelectListItems(states);
                 return View(doctorModel);
             }
             else
             {
                 doctorModel.Specialist_List = GetSelectListItems(states);
                 return View(doctorModel);
             }
        }

        private void LoadToUserAndDoctor(DoctorModel doctorModel, User user, Doctor doctor)
        {
            user.FirstName = doctorModel.FirstName;
            user.LastName = doctorModel.LastName;
            user.UserName = doctorModel.UserName;
            user.Email = doctorModel.Email;
            user.Birthdate = doctorModel.Birthdate;

            DateAndTime dateAndTime = new DateAndTime();
            user.Age = dateAndTime.GetAge(doctorModel.Birthdate);


            user.Password = doctorModel.Password;
            user.Gender = doctorModel.Gender;
            user.Type = Enum_UserType.Doctor.ToString();

            doctor.isAvailable = Enum_UserAvailableStatus.NotAvailable.ToString();
            doctor.User = user;
            doctor.Experience = doctorModel.Experience;
            doctor.About = doctorModel.About;

            ISpecialistService Service = ServiceFactory.GetSpecialistService();
            Specialist specialist = Service.Get(doctorModel.Specialist);

            doctor.Specialist = specialist;
        }

        //
        // 3. Action method for displaying 'Done' page
        //
        public ActionResult Done()
        {
            // Get Sign Up information from the session
            var model = Session["SignUpModel"] as DoctorModel;

            // Display Done.html page that shows Name and selected state.
            return View(model);
        }

        // Just return a list of states - in a real-world application this would call
        // into data access layer to retrieve states from a database.
        private IEnumerable<string> GetAllSpecialist()
        {
            ISpecialistService Service = ServiceFactory.GetSpecialistService();
            IEnumerable<Specialist> list =Service.GetAll();
            List<string> SpecialistCollection = new List<string>();
            foreach (var item in list)
            {
                SpecialistCollection.Add(item.Type);
            }
            return SpecialistCollection;
        }

        // This is one of the most important parts in the whole example.
        // This function takes a list of strings and returns a list of SelectListItem objects.
        // These objects are going to be used later in the SignUp.html template to render the
        // DropDownList.
        private IEnumerable<SelectListItem> GetSelectListItems(IEnumerable<string> elements)
        {
            
            var selectList = new List<SelectListItem>();


            foreach (var element in elements)
            {
                selectList.Add(new SelectListItem
                {
                    Value = element,
                    Text = element
                });
            }

            return selectList;
        }

        private bool DoesUserExistInDatabase(String userName)
        {
            IUserService user = ServiceFactory.GetUserService();
            if (user.Get(userName) != null) return true;
            else return false;
        }
        [HttpGet]
        public ActionResult AccountDetails()
        {
            DoctorModel Dm = new DoctorModel();
            Doctor d = (Doctor)Session["Doctor"];
            LoadToDrModel(Dm, d);
            return View(Dm);
        }
        private void LoadToDrModel(DoctorModel drModel, Doctor Doctor)
        {
            drModel.FirstName = Doctor.User.FirstName;
            drModel.LastName = Doctor.User.LastName;
            drModel.Email = Doctor.User.Email;
            drModel.Type = Doctor.User.Type;
            drModel.Gender = Doctor.User.Gender;
            drModel.Birthdate = Doctor.User.Birthdate;
            drModel.Age = Doctor.User.Age;
            drModel.ProfilePicture = Doctor.User.ProfilePicture;
            drModel.Experience = Doctor.Experience;
            drModel.About = Doctor.About;
            drModel.Specialist = Doctor.Specialist.Type;
        }
        [HttpGet]
        public ActionResult EditProfile()
        {
            Doctor doctor = (Doctor)Session["Doctor"];
            DoctorProfileModel profileModel = new DoctorProfileModel();

            var states = GetAllSpecialist();
            profileModel.Specialist_List = GetSelectListItems(states);



            LoadToProfileModel(profileModel, doctor);
            return View(profileModel);
        }

        private void LoadToProfileModel(DoctorProfileModel profileModel, Doctor doctor)
        {
            profileModel.FirstName = doctor.User.FirstName;
            profileModel.LastName = doctor.User.LastName;
            profileModel.Email = doctor.User.Email;
            profileModel.Gender = doctor.User.Gender;
            profileModel.Birthdate = doctor.User.Birthdate;
            profileModel.Age = doctor.User.Age;
            profileModel.ProfilePicture = doctor.User.ProfilePicture;
            profileModel.Experience = doctor.Experience;
            profileModel.About = doctor.About;

        }

        [HttpGet]
        public ActionResult EditPassword()
        {
            Doctor doctor = (Doctor)Session["Doctor"];

            DoctorPasswordModel passwordModel = new DoctorPasswordModel();

            return View(passwordModel);
        }

        [HttpPost]
        public ActionResult EditProfile(DoctorProfileModel profileModel)
        {
            var states = GetAllSpecialist();
           

            if (ModelState.IsValid)
            {

                Doctor doctor = (Doctor)Session["Doctor"];
                doctor.User.FirstName = profileModel.FirstName;
                doctor.User.LastName = profileModel.LastName;
                doctor.User.Email = profileModel.Email;
                doctor.User.Gender = profileModel.Gender;
                doctor.User.Birthdate = profileModel.Birthdate;

                DateAndTime dateAndTime = new DateAndTime();
                doctor.User.Age = dateAndTime.GetAge(profileModel.Birthdate);

                if (profileModel.File != null && profileModel.File.ContentLength > 0)
                {
                    string filename = Path.GetFileNameWithoutExtension(profileModel.File.FileName);
                    string extension = Path.GetExtension(profileModel.File.FileName);
                    if (extension.ToLower() == ".jpg" || extension.ToLower() == ".jpeg" || extension.ToLower() == ".png")
                    {
                        filename = filename + doctor.User.UserName + extension;
                        doctor.User.ProfilePicture = "~/UploadedFiles/Images/" + filename;
                        filename = Path.Combine(Server.MapPath("~/UploadedFiles/Images/"), filename);
                        profileModel.File.SaveAs(filename);

                       
                    }
                }
                doctor.isAvailable = profileModel.isAvailable;
                doctor.Experience = profileModel.Experience;
                doctor.About = profileModel.About;
                ISpecialistService Service = ServiceFactory.GetSpecialistService();
                Specialist specialist = Service.Get(profileModel.Specialist);
                doctor.Specialist = specialist;

                IDoctorService docService = ServiceFactory.GetDoctorService();
                docService.Update(doctor);
                IUserService UserService = ServiceFactory.GetUserService();
                UserService.Update(doctor.User);

                ReloadDoctorInfo();

                LoadToProfileModel(profileModel, doctor);

                profileModel.NotifyProfileChangeStatus = "Profile Updated";

                ModelState.Clear();

                profileModel.Specialist_List = GetSelectListItems(states);
                return View(profileModel);
            }

            profileModel.Specialist_List = GetSelectListItems(states);
            return View(profileModel);
        }
        private void ReloadDoctorInfo()
        {
            IDoctorService doctorService = ServiceFactory.GetDoctorService();
            Doctor doctor = (Doctor)Session["Doctor"];
            doctor = doctorService.Get(doctor.Id, true);
        }
        [HttpPost]
        public ActionResult EditPassword(DoctorPasswordModel doctorModel)
        {
            if (ModelState.IsValid)
            {
                Doctor doctor = (Doctor)Session["Doctor"];

                if (doctor.User.Password == doctorModel.CurrentPassword)
                {
                    doctor.User.Password = doctorModel.NewPassword;

                    IUserService UserService = ServiceFactory.GetUserService();
                    UserService.Update(doctor.User);

                    doctorModel.NotifyUpdateStatus = "Password changed successfully";
                    ReloadDoctorInfo();
                    ModelState.Clear();
                    return View(doctorModel);
                }
                else
                {

                    doctorModel.NotifyUpdateStatus = "Your Current password Doesnt match";
                    return View(doctorModel);
                }
            }
            return View();
        }

    }
}