using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using V.Doc_Data.Abstract_Classes;
using V.Doc_Data.Interfaces;

namespace V.Doc_Data
{
    public abstract class DataAccessFactory
    {
        public static DatabaseContext context = new DatabaseContext();
        public static IChatDataAccess GetChatDataAccess()
        {
            return new ChatDataAccess(context);
        }
        public static IComplainDataAccess GetComplainDataAccess()
        {
            return new ComplainDataAccess(context);
        }
        public static IDiseaseDataAccess GetDiseaseDataAccess()
        {
            return new DiseaseDataAccess(context);
        }
        public static IDoctorDataAccess GetDoctorDataAccess()
        {
            return new DoctorDataAccess(context);
        }
        public static IMedicineDataAccess GetMedicineDataAccess()
        {
            return new MedicineDataAccess(context);
        }
        public static IPatientDataAccess GetPatientDataAccess()
        {
            return new PatientDataAccess(context);
        }
        public static IPrescriptionDataAccess GetPrescriptionDataAccess()
        {
            return new PrescriptionDataAccess(context);
        }
        public static ISpecialistDataAccess GetSpecialistDataAccess()
        {
            return new SpecialistDataAccess(context);
        }
        public static ISymptomDataAccess GetSymtomDataAccess()
        {
            return new SymptomDataAccess(context);
        }
        public static IUserDataAccess GetUserDataAccess()
        {
            return new UserDataAccess(context);
        }
    }
}
