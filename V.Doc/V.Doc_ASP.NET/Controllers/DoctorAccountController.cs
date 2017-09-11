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
        //
        // 1. Action method for displaying 'Sign Up' page
        //
       /* public ActionResult CreateAccount()
        {
            // Let's get all states that we need for a DropDownList
            var states = GetAllSpecialist();

            var model = new DoctorModel();

            // Create a list of SelectListItems so these can be rendered on the page
            model.Specialist_List = GetSelectListItems(states);

            return View(model);
        }*/

        //
        // 2. Action method for handling user-entered data when 'Sign Up' button is pressed.
        //
        [HttpPost]
        public ActionResult CreateAccount(DoctorModel doctorModel)
        {
            /* var states = GetAllSpecialist();
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

                 LoadToUserAndDoctor(doctorModel, user, doctor);


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
             }*/
            return View();
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
            user.Type = Enum_UserType.Patient.ToString();

            if (doctorModel.File != null && doctorModel.File.ContentLength > 0)
            {
                string filename = Path.GetFileNameWithoutExtension(doctorModel.File.FileName);
                string extension = Path.GetExtension(doctorModel.File.FileName);
                filename = filename + user.UserName + extension;
                user.ProfilePicture = "~/UploadedFiles/Images/" + filename;
                filename = Path.Combine(Server.MapPath("~/UploadedFiles/Images/"), filename);
                doctorModel.File.SaveAs(filename);
            }
            doctor.isAvailable = Enum_UserAvailableStatus.NotAvailable.ToString();
            doctor.User = user;
            doctor.Experience = doctorModel.Experience;
            doctor.About = doctorModel.About;

            /*ISpecialistService Service = ServiceFactory.GetSpecialistService();
            Specialist specialist = Service.Get(doctorModel.Specialist);*/

           // doctor.Specialist = specialist;
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
       /* private IEnumerable<string> GetAllSpecialist()
        {
            ISpecialistService Service = ServiceFactory.GetSpecialistService();
            IEnumerable<Specialist> list =Service.GetAll();
            List<string> SpecialistCollection = new List<string>();
            foreach (var item in list)
            {
                SpecialistCollection.Add(item.Type);
            }
            return SpecialistCollection;
        }*/

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
    }
}