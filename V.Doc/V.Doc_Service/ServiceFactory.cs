using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using V.Doc_Data.Abstract_Classes;
using V.Doc_Service.Interfaces;
using V.Doc_Service.Abstract_Classes;
using V.Doc_Data;

namespace V.Doc_Service
{
    public abstract class ServiceFactory
    {
        /*public static IChatService GetChatService()
        {
            return new ChatService(DataAccessFactory.GetChatDataAccess());
        }
        public static IContactService GetContactServie()
        {
            return new ContactService(DataAccessFactory.GetContactDataAccess());
        }
        public static IComplainService GetComplainService()
        {
            return new ComplainService(DataAccessFactory.GetComplainDataAccess());
        }
        public static IDiseaseService GetDiseaseService()
        {
            return new DiseaseService(DataAccessFactory.GetDiseaseDataAccess());
        }*/
        public static IAdminService GetAdminService()
        {
            return new AdminService(DataAccessFactory.GetAdminDataAccess());
        }
        public static IDoctorService GetDoctorService()
        {
            return new DoctorService(DataAccessFactory.GetDoctorDataAccess());
        }
        /*public static IMedicineService GetMedicineService()
        {
            return new MedicineService(DataAccessFactory.GetMedicineDataAccess());
        }*/
        public static IPatientService GetPatientService()
        {
            return new PatientService(DataAccessFactory.GetPatientDataAccess());
        }
        /*public static IPrescriptionService GetPrescriptionService()
        {
            return new PrescriptionService(DataAccessFactory.GetPrescriptionDataAccess());
        }
        public static ISpecialistService GetSpecialistService()
        {
            return new SpecialistService(DataAccessFactory.GetSpecialistDataAccess());
        }
        public static ISymptomService GetSymtomService()
        {
            return new SymptomService(DataAccessFactory.GetSymtomDataAccess());
        }*/
        public static IUserService GetUserService()
        {
            return new UserService(DataAccessFactory.GetUserDataAccess());
        }
    }
}
