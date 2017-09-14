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
    public class PatientSearchDoctorController : Controller
    {
        // GET: PatientSearchDoctor
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult GetDoctorList(String searchBy, String searchText)
        {
            Patient pat = (Patient)Session["Patient"];
            IContactService contactService = ServiceFactory.GetContactServie();

            List<Contact> contactlist=contactService.GetUsingPatient(pat.Id);



            IDoctorService service = ServiceFactory.GetDoctorService();
            IEnumerable<Doctor> doctorList = service.Search(searchBy, searchText);
            List<DoctorListModel> UserListModel = new List<DoctorListModel>();
            foreach (var item in doctorList)
            {
                DoctorListModel uModel = new DoctorListModel();
                uModel.User = new User();
                uModel.Specialist = new Specialist();

                uModel.User.FirstName = item.User.FirstName;
                uModel.User.LastName = item.User.LastName;
                uModel.User.Gender = item.User.Gender;
                uModel.User.Age = item.User.Age;
                uModel.Specialist.Type = item.Specialist.Type;
                uModel.Id = item.Id;

                foreach (var contact in contactlist)
                {
                    if(contact.DoctorId==item.Id)
                    {
                        uModel.isContact = true;
                        break;
                    }
                    else
                    {
                        uModel.isContact = false;
                    }
                    
                }
                
                UserListModel.Add(uModel);


            }
            return Json(UserListModel, JsonRequestBehavior.AllowGet);
        }

        public ActionResult AddContact(int id)
        {
            bool result = false;

            IContactService contactService = ServiceFactory.GetContactServie();
            Patient pat = (Patient)Session["Patient"];
            Contact contact = new Contact();

            contact.Message = "Request to add u in contact";
            contact.PatientId = pat.Id;
            contact.DoctorId = id;
            contact.RequestStatus = Enum_RequestStatus.Pending.ToString();
            contact.TimeCreated = DateTime.Now;
            contact.TimeUpdated = DateTime.Now;

            contactService.Insert(contact);

            result = true;
            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}