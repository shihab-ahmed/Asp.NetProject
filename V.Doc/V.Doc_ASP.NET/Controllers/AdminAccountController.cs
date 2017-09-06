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
    public class AdminAccountController : Controller
    {
        private bool IsUserAlive()
        {
            User user = (User)Session["User"];
            if (user == null) return false;
            else
            {
                return true;
            }

        }
        private bool IsDefaultAdmin()
        {
            User user = (User)Session["User"];
            if (user.UserName == "Admin") return true;
            else
            {
                return false;
            }
        }
        // GET: Patient
        public ActionResult CreateAccount()
        {
            DatabaseContext context = new DatabaseContext();
            context.Users.ToList();
            return View();
        }
        [HttpPost]
        public ActionResult CreateAccount(AdminModel adminModel)
        {
            if (ModelState.IsValid)
            {
                User user = new User();

                if (DoesUserExistInDatabase(adminModel.UserName))
                {
                    adminModel.UserExistMessage = "Sorry user already exist";
                    return View(adminModel);
                }

                LoadToUser(adminModel, user);
                IUserService userService = ServiceFactory.GetUserService();
                userService.Insert(user);
                ModelState.Clear();
                adminModel.NotifyAccountCreatedStatus = "Account Created";
                return View(adminModel);
            }
            else
            {
                return View(adminModel);
            }
        }
        [HttpGet]
        public ActionResult AccountDetails()
        {
            if (!IsUserAlive()) return RedirectToAction("Login", "Login");

            User user = (User)Session["User"];
            AdminModel adminModel = new AdminModel();

            LoadToAdminModel(adminModel, user);
            return View(adminModel);
        }
        [HttpGet]
        public ActionResult EditProfile()
        {
            if (!IsUserAlive()) return RedirectToAction("Login", "Login");
            if (IsDefaultAdmin()) return RedirectToAction("AccountDetails","AdminAccount");

            User user = (User)Session["User"];
            AdminProfileModel AdminProfileModel = new AdminProfileModel();

            LoadToProfileModel(AdminProfileModel, user);
            return View(AdminProfileModel);
        }
        [HttpGet]
        public ActionResult EditPassword()
        {
            if (!IsUserAlive()) return RedirectToAction("Login", "Login");
            if (IsDefaultAdmin()) return RedirectToAction("AccountDetails", "AdminAccount");

            User user = (User)Session["User"];
            AdminPasswordModel AdminPasswordModel = new AdminPasswordModel();
            return View(AdminPasswordModel);
        }

        [HttpPost]
        public ActionResult EditProfile(AdminProfileModel profileModel)
        {
            if (!IsUserAlive()) return RedirectToAction("Login", "Login");
            if (ModelState.IsValid)
            {

                User User = (User)Session["User"];
                User.FirstName = profileModel.FirstName;
                User.LastName = profileModel.LastName;
                User.Email = profileModel.Email;
                User.Gender = profileModel.Gender;
                User.Birthdate = profileModel.Birthdate;

                DateAndTime dateAndTime = new DateAndTime();
                User.Age = dateAndTime.GetAge(profileModel.Birthdate);

                if (profileModel.File != null && profileModel.File.ContentLength > 0)
                {
                    string filename = Path.GetFileNameWithoutExtension(profileModel.File.FileName);
                    string extension = Path.GetExtension(profileModel.File.FileName);
                    filename = filename + User.UserName + extension;
                    User.ProfilePicture = "~/UploadedFiles/Images/" + filename;
                    filename = Path.Combine(Server.MapPath("~/UploadedFiles/Images/"), filename);
                    profileModel.File.SaveAs(filename);
                }
                IUserService UserService = ServiceFactory.GetUserService();
                UserService.Update(User);

                ReloadPatientInfo();

                LoadToProfileModel(profileModel, User);

                profileModel.NotifyProfileChangeStatus = "Profile Updated";

                ModelState.Clear();

                return View(profileModel);
            }

            return View(profileModel);
        }
        [HttpPost]
        public ActionResult EditPassword(AdminPasswordModel passwordModel)
        {
            if (!IsUserAlive()) return RedirectToAction("Login", "Login");
            if (ModelState.IsValid)
            {
                User User = (User)Session["User"];

                if (User.Password == passwordModel.CurrentPassword)
                {
                    User.Password = passwordModel.NewPassword;

                    IUserService UserService = ServiceFactory.GetUserService();
                    UserService.Update(User);

                    passwordModel.NotifyUpdateStatus = "Password changed successfully";
                    ModelState.Clear();
                    return View(passwordModel);
                }
                else
                {

                    passwordModel.NotifyUpdateStatus = "Your Current password Doesnt match";
                    return View(passwordModel);
                }
            }
            return View();
        }
        
        private void LoadToAdminProfileModel(AdminProfileModel AdminProfileModel, User User)
        {
            AdminProfileModel.FirstName = User.FirstName;
            AdminProfileModel.LastName = User.LastName;
            AdminProfileModel.Email = User.Email;
            AdminProfileModel.Gender = User.Gender;
            AdminProfileModel.Birthdate = User.Birthdate;
            AdminProfileModel.Age = User.Age;
            AdminProfileModel.ProfilePicture = User.ProfilePicture;
        }
        private void ReloadPatientInfo()
        {
            IUserService userService = ServiceFactory.GetUserService();
            User User = (User)Session["User"];
            User = userService.Get(User.Id);
        }
        private void LoadToAdminModel(AdminModel AdminModel, User User)
        {
            AdminModel.FirstName = User.FirstName;
            AdminModel.LastName = User.LastName;
            AdminModel.Email = User.Email;
            AdminModel.Type = User.Type;
            AdminModel.Gender = User.Gender;
            AdminModel.Birthdate = User.Birthdate;
            AdminModel.Age = User.Age;
            AdminModel.ProfilePicture = User.ProfilePicture;
        }
        private void LoadToProfileModel(AdminProfileModel AdminProfile, User User)
        {
            AdminProfile.FirstName = User.FirstName;
            AdminProfile.LastName =User.LastName;
            AdminProfile.Email = User.Email;
            AdminProfile.Gender = User.Gender;
            AdminProfile.Birthdate = User.Birthdate;
            AdminProfile.Age = User.Age;
            AdminProfile.ProfilePicture = User.ProfilePicture;
            
        }
        private void LoadToUser(AdminModel adminModel, User user)
        {
            user.FirstName = adminModel.FirstName;
            user.LastName = adminModel.LastName;
            user.UserName = adminModel.UserName;
            user.Email = adminModel.Email;
            user.Birthdate = adminModel.Birthdate;

            DateAndTime dateAndTime = new DateAndTime();
            user.Age = dateAndTime.GetAge(adminModel.Birthdate);


            user.Password = adminModel.Password;
            user.Gender = adminModel.Gender;
            user.Type = Enum_UserType.Admin.ToString();

            if (adminModel.File != null && adminModel.File.ContentLength > 0)
            {
                string filename = Path.GetFileNameWithoutExtension(adminModel.File.FileName);
                string extension = Path.GetExtension(adminModel.File.FileName);
                filename = filename + user.UserName + extension;
                user.ProfilePicture = "~/UploadedFiles/Images/" + filename;
                filename = Path.Combine(Server.MapPath("~/UploadedFiles/Images/"), filename);
                adminModel.File.SaveAs(filename);
            }
        }
        private bool DoesUserExistInDatabase(String userName)
        {
            IUserService user = ServiceFactory.GetUserService();
            if (user.Get(userName) != null) return true;
            else return false;
        }
    }
}