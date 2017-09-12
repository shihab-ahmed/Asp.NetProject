using System;
using System.Collections.Generic;
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
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(LoginModel loginModel)
        {
            if(ModelState.IsValid)
            {
                IUserService userService = ServiceFactory.GetUserService();
                User user = new User();
                user.UserName = loginModel.UserName;
                user.Password = loginModel.Password;
                if(userService.ValidateCredentials(user))
                {
                    user = userService.Get(user.UserName);
                    String type = user.Type;
                    if(Enum_UserType.Admin.ToString()==type)
                    {
                        IAdminService adminService = ServiceFactory.GetAdminService();
                        Admin admin = adminService.GetUsingUser(user, true);
                        Session["Admin"] = admin;
                        return RedirectToAction("AccountDetails", "AdminAccount");
                    }
                    else if(Enum_UserType.Patient.ToString() == type)
                    {
                        IPatientService patientServie = ServiceFactory.GetPatientService();
                        Patient patient = patientServie.GetUsingUser(user,true);
                        Session["Patient"] = patient;
                        return RedirectToAction("AccountDetails", "PatientAccount");
                    }
                    else
                    {
                        IDoctorService doctorServie = ServiceFactory.GetDoctorService();
                        Doctor doctor = doctorServie.GetUsingUser(user, true);
                        Session["Doctor"] = doctor;
                        return RedirectToAction("AccountDetails", "DoctorAccount");
                    }
                    
                }
                else
                {
                    loginModel.ErrorMessage = "User Name or password didnt match";
                    return View(loginModel);
                }
            }
            return View();
        }
    }
}