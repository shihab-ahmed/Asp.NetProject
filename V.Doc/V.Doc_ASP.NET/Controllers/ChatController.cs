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
    public class ChatController : Controller
    {
        // GET: Chat
        public ActionResult ChatBox(int id)
        {
            if((Patient)Session["Patient"]!=null)
            {

                Patient pat = (Patient)Session["Patient"];
                IDoctorService ids = ServiceFactory.GetDoctorService();
                Doctor doc=ids.Get(id, true);

                ChatModel cm = new ChatModel();
                cm.SenderId = pat.Id;
                cm.SelectedUserId = id;
                cm.SelectedUserImage = doc.User.ProfilePicture;
                cm.SelectedUserName = doc.User.FirstName + " " + doc.User.LastName;
                cm.LastMessageId = 0;
                return View("PatientChatBox",cm);
            }
            if ((Doctor)Session["Doctor"] != null)
            {
                Doctor doc = (Doctor)Session["Doctor"];

                IPatientService ips = ServiceFactory.GetPatientService();
                Patient pat = ips.Get(id, true);

                ChatModel cm = new ChatModel();
                cm.SenderId = doc.Id;
                cm.SelectedUserId = id;
                cm.LastMessageId = 0;
                cm.SelectedUserImage = pat.User.ProfilePicture;
                cm.SelectedUserName = pat.User.FirstName + " " + pat.User.LastName;
                return View("DoctorChatBox",cm);
            }
            return View();
        }
        [HttpPost]
        public JsonResult AddMessage(String SenderId, String RecieverId,String Message)
        {
            IChatService cS = ServiceFactory.GetChatService();
            IPatientService patientService = ServiceFactory.GetPatientService();
            IDoctorService doctorService = ServiceFactory.GetDoctorService();

            if ((Doctor)Session["Doctor"]!=null)
            {
                Doctor doc = (Doctor)Session["Doctor"];
                Patient pat = patientService.Get(Int32.Parse(RecieverId));

                Chat chat = new Chat();
                chat.SenderId = Int32.Parse(SenderId);
                chat.SenderUserName = doc.User.UserName;

                chat.RecieverId = Int32.Parse(RecieverId);
                chat.RecieverUserName = pat.User.UserName;

                chat.Message = Message;
                chat.TimeCreated = DateTime.Now;
                chat.TimeUpdated = DateTime.Now;
                cS.Insert(chat);
            }
            else
            {
                Patient pat = (Patient)Session["Patient"];
                Doctor doc = doctorService.Get(Int32.Parse(RecieverId));

                Chat chat = new Chat();
                chat.SenderId = Int32.Parse(SenderId);
                chat.SenderUserName = pat.User.UserName;

                chat.RecieverId = Int32.Parse(RecieverId);
                chat.RecieverUserName = doc.User.UserName;

                chat.Message = Message;
                chat.TimeCreated = DateTime.Now;
                chat.TimeUpdated = DateTime.Now;
                cS.Insert(chat);
            }


            return Json(true, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult GetMessages(String RecieverId,string LastChatId)
        {
            IChatService service = ServiceFactory.GetChatService();
            IPatientService patientService = ServiceFactory.GetPatientService();
            IDoctorService doctorService = ServiceFactory.GetDoctorService();

            List<ChatMessageModel> cmmList = new List<ChatMessageModel>();

            if ((Doctor)Session["Doctor"] != null)
            {

                Patient pat = patientService.Get(Int32.Parse(RecieverId), true);

                Doctor doc = (Doctor)Session["Doctor"];
                int senderId = doc.Id;
                IEnumerable<Chat> chatList = service.GetNewChat(senderId,Int32.Parse(RecieverId),Int32.Parse(LastChatId));

                foreach (var chat in chatList)
                {
                    ChatMessageModel cmm = new ChatMessageModel();
                    cmm.id = chat.Id;
                    cmm.Message = chat.Message;

                    if(chat.SenderUserName==doc.User.UserName)
                    {
                        cmm.isSender = true;
                        cmm.image = doc.User.ProfilePicture;
                        cmm.Name = doc.User.FirstName;
                    }
                    else
                    {
                        cmm.isSender = false;
                        cmm.image = pat.User.ProfilePicture;
                        cmm.Name = pat.User.FirstName;
                    }

                    cmmList.Add(cmm);
                }


            }
            else
            {
                Doctor doc = doctorService.Get(Int32.Parse(RecieverId), true);

                Patient pat = (Patient)Session["Patient"];
                int senderId = doc.Id;
                IEnumerable<Chat> chatList = service.GetNewChat(senderId, Int32.Parse(RecieverId), Int32.Parse(LastChatId));

                foreach (var chat in chatList)
                {
                    ChatMessageModel cmm = new ChatMessageModel();
                    cmm.id = chat.Id;
                    cmm.Message = chat.Message;

                    if (chat.SenderUserName == pat.User.UserName)
                    {
                        cmm.isSender = true;
                        cmm.image = pat.User.ProfilePicture;
                        cmm.Name = pat.User.FirstName;
                    }
                    else
                    {
                        cmm.isSender = false;
                        cmm.image = doc.User.ProfilePicture;
                        cmm.Name = doc.User.FirstName;
                    }

                    cmmList.Add(cmm);
                }
            }


            return Json(cmmList, JsonRequestBehavior.AllowGet);
        }
    }
}