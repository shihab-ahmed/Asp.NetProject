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
        private bool IsAdminAlive()
        {
            Admin admin = (Admin)Session["Admin"];
            if (admin == null) return false;
            else
            {
                return true;
            }

        }
        private bool IsDefaultAdmin()
        {
            Admin admin = (Admin)Session["Admin"];
            if (admin.User.UserName == "Admin") return true;
            else
            {
                return false;
            }
        }
        private List<ShowUserListModel> GetAllUser()
        {
            IUserService service = ServiceFactory.GetUserService();
            
            IEnumerable<User> UserList =service.GetAll();
            List<ShowUserListModel> UserListModel = new List<ShowUserListModel>();
            foreach (var item in UserList)
            {
                ShowUserListModel uModel = new ShowUserListModel();

                uModel.FirstName = item.FirstName;
                uModel.LastName = item.LastName;
                uModel.Email = item.Email;
                uModel.ProfilePicture = item.ProfilePicture;
                uModel.Type = item.Type;
                uModel.Age = item.Age;
                uModel.Gender = item.Gender;
                uModel.Id = item.Id;
                uModel.AccountAvailableStatus = item.AccountAvailableStatus;
                UserListModel.Add(uModel);
            }
            return UserListModel;

        }
        public ActionResult ShowUserDetails(int id)
        {
            IUserService uS = ServiceFactory.GetUserService();
            User User=uS.Get(id);

            if(User.Type==Enum_UserType.Admin.ToString())
            {
                IAdminService aS = ServiceFactory.GetAdminService();
                Admin admin = aS.Get(id, true);

                AdminAdminDetails aaD = new AdminAdminDetails();
                

                return View("AdminDetails",aaD);

            }
            if (User.Type == Enum_UserType.Doctor.ToString())
            {
                IDoctorService dS = ServiceFactory.GetDoctorService();
                Doctor doctor = dS.Get(id, true);
                AdminDoctorDetails aDD = new AdminDoctorDetails();

                return View("ShowDoctorDetails",aDD);
            }
            else
            {
                IPatientService pS = ServiceFactory.GetPatientService();
                Patient patient = pS.Get(id, true);
                AdminPatientDetails aPD = new AdminPatientDetails();

                return View("ShowPatientDetails",aPD);
            }


            
        }
        public ActionResult DeleteUser(int id)
        {
            return View();
        }
        [HttpGet]
        public ActionResult ShowUserList()
        {
            if (!IsAdminAlive()) return RedirectToAction("Login", "Login");
            return View(GetAllUser());
        }
        public ActionResult CreateAccount()
        {
            AdminModel PM = new AdminModel();
            return View(PM);
        }
        [HttpPost]
        public ActionResult CreateAccount(AdminModel adminModel)
        {
            if (ModelState.IsValid)
            {
                User user = new User();
                Admin admin = new Admin();
                admin.User = user;

                if (DoesUserExistInDatabase(adminModel.UserName))
                {
                    adminModel.UserExistMessage = "Sorry user already exist";
                    return View(adminModel);
                }
                if (!isImageValid(adminModel, user, admin))
                {
                    adminModel.imgeFileNeedMessage = "Image(jpg,jpeg,png) file required";
                    return View(adminModel);
                }


                LoadToUserAndAdmin(adminModel, user, admin);

                user.TimeAccountCreated = DateTime.Now;
                user.LastLogin = DateTime.Now;
                user.LastTimeNotificationChecked = DateTime.Now;
                user.AccountAvailableStatus = Enum_AccountAvailableStatus.Accessable.ToString();

                IAdminService adminService = ServiceFactory.GetAdminService();
                adminService.Insert(admin);
                ModelState.Clear();

                AdminModel newPM = new AdminModel();
                newPM.NotifyAccountCreatedStatus = "Account Created";
                return View(newPM);
            }
            else
            {
                adminModel.NotifyAccountCreatedStatus = "Fail to create account";
                return View(adminModel);
            }
        }
        [HttpGet]
        public ActionResult AccountDetails()
        {
            if (!IsAdminAlive()) return RedirectToAction("Login", "Login");

            Admin admin = (Admin)Session["Admin"];
            AdminModel adminModel = new AdminModel();

            LoadToAdminModel(adminModel, admin);
            return View(adminModel);
        }
        [HttpGet]
        public ActionResult EditProfile()
        {
            if (!IsAdminAlive()) return RedirectToAction("Login", "Login");
            if (IsDefaultAdmin()) return RedirectToAction("AccountDetails","AdminAccount");

            Admin admin = (Admin)Session["Admin"];
            AdminProfileModel AdminProfileModel = new AdminProfileModel();

            LoadToProfileModel(AdminProfileModel, admin);
            return View(AdminProfileModel);
        }
        [HttpGet]
        public ActionResult EditPassword()
        {
            if (!IsAdminAlive()) return RedirectToAction("Login", "Login");
            if (IsDefaultAdmin()) return RedirectToAction("AccountDetails", "AdminAccount");
            AdminPasswordModel AdminPasswordModel = new AdminPasswordModel();
            return View(AdminPasswordModel);
        }

        [HttpPost]
        public ActionResult EditProfile(AdminProfileModel profileModel)
        {
            if (!IsAdminAlive()) return RedirectToAction("Login", "Login");
            if (ModelState.IsValid)
            {
                
                Admin admin = (Admin)Session["Admin"];
                admin.User.FirstName = profileModel.FirstName;
                admin.User.LastName = profileModel.LastName;
                admin.User.Email = profileModel.Email;
                admin.User.Gender = profileModel.Gender;
                admin.User.Birthdate = profileModel.Birthdate;

                DateAndTime dateAndTime = new DateAndTime();
                admin.User.Age = dateAndTime.GetAge(profileModel.Birthdate);

                if (profileModel.File != null && profileModel.File.ContentLength > 0)
                {
                    string filename = Path.GetFileNameWithoutExtension(profileModel.File.FileName);
                    string extension = Path.GetExtension(profileModel.File.FileName);
                    if (extension.ToLower() == ".jpg" || extension.ToLower() == ".jpeg" || extension.ToLower() == ".png")
                    {
                        filename = filename + admin.User.UserName + extension;
                        admin.User.ProfilePicture = "~/UploadedFiles/Images/" + filename;
                        filename = Path.Combine(Server.MapPath("~/UploadedFiles/Images/"), filename);
                        profileModel.File.SaveAs(filename);
                    }
                    else
                    {
                        profileModel.imgeFileNeedMessage = "Image file must be (jpg,jpeg,png)";
                        return View(profileModel);
                    }
                }


                IAdminService adminService = ServiceFactory.GetAdminService();
                adminService.Update(admin);

                ReloadAdminInfo();

                LoadToProfileModel(profileModel, admin);

                profileModel.NotifyProfileChangeStatus = "Profile Updated";

                ModelState.Clear();

                return View(profileModel);
            }

            return View(profileModel);
        }
        [HttpPost]
        public ActionResult EditPassword(AdminPasswordModel passwordModel)
        {
            if (!IsAdminAlive()) return RedirectToAction("Login", "Login");
            if (ModelState.IsValid)
            {
                Admin admin = (Admin)Session["Admin"];

                if (admin.User.Password == passwordModel.CurrentPassword)
                {
                    admin.User.Password = passwordModel.NewPassword;

                    IAdminService UserService = ServiceFactory.GetAdminService();
                    UserService.Update(admin);

                    passwordModel.NotifyUpdateStatus = "Password changed successfully";
                    ModelState.Clear();
                    ReloadAdminInfo();
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
        private void ReloadAdminInfo()
        {
            IAdminService adminService = ServiceFactory.GetAdminService();
            Admin admin = (Admin)Session["Admin"];
            admin = adminService.Get(admin.User.Id);
        }
        private void LoadToAdminModel(AdminModel AdminModel, Admin admin)
        {
            AdminModel.FirstName = admin.User.FirstName;
            AdminModel.LastName = admin.User.LastName;
            AdminModel.Email = admin.User.Email;
            AdminModel.Type = admin.User.Type;
            AdminModel.Gender = admin.User.Gender;
            AdminModel.Birthdate = admin.User.Birthdate;
            AdminModel.Age = admin.User.Age;
            AdminModel.ProfilePicture = admin.User.ProfilePicture;
        }
        private void LoadToProfileModel(AdminProfileModel AdminProfile, Admin admin)
        {
            AdminProfile.FirstName = admin.User.FirstName;
            AdminProfile.LastName =admin.User.LastName;
            AdminProfile.Email = admin.User.Email;
            AdminProfile.Gender = admin.User.Gender;
            AdminProfile.Birthdate = admin.User.Birthdate;
            AdminProfile.Age = admin.User.Age;
            AdminProfile.ProfilePicture = admin.User.ProfilePicture;
            
        }
        private void LoadToUserAndAdmin(AdminModel adminModel, User user,Admin Admin)
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
        }
        private bool DoesUserExistInDatabase(String userName)
        {
            IUserService user = ServiceFactory.GetUserService();
            if (user.Get(userName) != null) return true;
            else return false;
        }
        private bool isImageValid(AdminModel adminModel, User user, Admin admin)
        {
            if (adminModel.File != null && adminModel.File.ContentLength > 0)
            {
                string filename = Path.GetFileNameWithoutExtension(adminModel.File.FileName);
                string extension = Path.GetExtension(adminModel.File.FileName);

                if (extension.ToLower() == ".jpg" || extension.ToLower() == ".jpeg" || extension.ToLower() == ".png")
                {
                    filename = filename + user.UserName + extension;
                    user.ProfilePicture = "~/UploadedFiles/Images/" + filename;
                    filename = Path.Combine(Server.MapPath("~/UploadedFiles/Images/"), filename);
                    adminModel.File.SaveAs(filename);
                    admin.User = user;
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
        public JsonResult isUserExist(string order)
        {
            return Json(DoesUserExistInDatabase(order));
        }
        [HttpPost]
        public JsonResult GetSearchingData(String searchBy, String searchText)
        {
            IUserService service = ServiceFactory.GetUserService();

            IEnumerable<User> UserList = service.Search(searchBy,searchText);
            List<ShowUserListModel> UserListModel = new List<ShowUserListModel>();
            foreach (var item in UserList)
            {
                ShowUserListModel uModel = new ShowUserListModel();

                uModel.FirstName = item.FirstName;
                uModel.LastName = item.LastName;
                uModel.Email = item.Email;
                uModel.ProfilePicture = item.ProfilePicture;
                uModel.Type = item.Type;
                uModel.Age = item.Age;
                uModel.Gender = item.Gender;
                uModel.Id = item.Id;
                uModel.AccountAvailableStatus = item.AccountAvailableStatus;
                UserListModel.Add(uModel);
            }
            return Json(UserListModel, JsonRequestBehavior.AllowGet);
        }
    }
}