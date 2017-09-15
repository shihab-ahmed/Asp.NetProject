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
    public class ContactController : Controller
    {

        // GET: Contact
        public ActionResult PendingIndex()
        {
            Doctor doc=(Doctor)Session["Doctor"];
            return View(getPendingContactListModel(Enum_UserType.Doctor,doc.Id));
        }
        public ActionResult AddToContact(int id)
        {
            IContactService cs = ServiceFactory.GetContactServie();
            Contact c = cs.Get(id);
            c.RequestStatus = Enum_RequestStatus.Accepted.ToString();
            cs.Update(c);
            return RedirectToAction("PendingIndex");
        }
        public IEnumerable<ContactListModel> getPendingContactListModel(Enum_UserType EUT,int id)
        {
            List<Contact> contactList = getContactList(EUT,id);
            IPatientService patientS = ServiceFactory.GetPatientService();
            IDoctorService doctorS = ServiceFactory.GetDoctorService();

            List<ContactListModel> pendingList = new List<ContactListModel>();
            foreach (var contact in contactList)
            {
                if(contact.RequestStatus==Enum_RequestStatus.Pending.ToString())
                {
                    ContactListModel d = new ContactListModel();

                    Patient pat= patientS.Get(contact.PatientId,true);
                    Doctor doc = doctorS.Get(contact.DoctorId,true);

                    d.PatientId = pat.Id;
                    d.PatientPic = pat.User.ProfilePicture;
                    d.DoctorId = doc.Id;
                    d.DoctorPic = doc.User.ProfilePicture;
                    d.message = contact.Message;

                    d.RequestStatus = contact.RequestStatus;
                    d.Time = contact.TimeCreated;
                    d.ContactID = contact.Id;
                    if(EUT==Enum_UserType.Doctor)
                    {
                        d.availableStatus = doc.isAvailable;
                    }
                    else
                    {
                        d.availableStatus = pat.isAvailable;
                    }


                    pendingList.Add(d);


                }
            }
            return pendingList;
        }

        public IEnumerable<ContactListModel> getAcceptedContactListModel(Enum_UserType EUT, int id)
        {
            IPatientService patientS = ServiceFactory.GetPatientService();
            IDoctorService doctorS = ServiceFactory.GetDoctorService();
            List<Contact> contactList = getContactList(EUT, id);

            List<ContactListModel> acceptedList = new List<ContactListModel>();
            foreach (var contact in contactList)
            {
                if (contact.RequestStatus == Enum_RequestStatus.Accepted.ToString())
                {
                    ContactListModel d = new ContactListModel();

                    Patient pat = patientS.Get(contact.PatientId, true);
                    Doctor doc = doctorS.Get(contact.DoctorId, true);

                    d.PatientId = pat.Id;
                    d.PatientPic = pat.User.ProfilePicture;
                    d.DoctorId = doc.Id;
                    d.DoctorPic = doc.User.ProfilePicture;
                    d.message = contact.Message;

                    d.RequestStatus = contact.RequestStatus;
                    d.Time = contact.TimeCreated;
                    d.ContactID = contact.Id;

                    if (EUT == Enum_UserType.Doctor)
                    {
                        d.availableStatus = doc.isAvailable;
                    }
                    else
                    {
                        d.availableStatus = pat.isAvailable;
                    }


                    acceptedList.Add(d);


                }
            }
            return acceptedList;
        }



        private List<Contact>getContactList(Enum_UserType EUT,int id)
        {
            if(EUT==Enum_UserType.Doctor)
            {
                IContactService cs = ServiceFactory.GetContactServie();
                return cs.GetUsingDoctor(id);
            }
            else if (EUT == Enum_UserType.Patient)
            {
                IContactService cs = ServiceFactory.GetContactServie();
                return cs.GetUsingPatient(id);
            }
            else
            {
                return new List<Contact>();
            }
            
        }
        public ActionResult GetContactListPartialView()
        {
           
            if((Patient)Session["Patient"]!=null)
            {
                Patient p = (Patient)Session["Patient"];
                return PartialView("ContactList", getAcceptedContactListModel(Enum_UserType.Patient, p.Id));
            }
            else if(((Doctor)Session["Doctor"] != null))
            {
                Doctor d = (Doctor)Session["Doctor"];
                return PartialView("ContactList", getAcceptedContactListModel(Enum_UserType.Doctor, d.Id));
            }
            else
            {
                return PartialView("ContactList");
            }           
        }
    }
}
