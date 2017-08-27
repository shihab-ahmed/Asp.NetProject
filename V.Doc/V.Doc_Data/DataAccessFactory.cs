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
        public static IChatDataAccess GetChatDataAccess()
        {
            return new ChatDataAccess(new DatabaseContext());
        }
        public static IComplainDataAccess GetComplainDataAccess()
        {
            return new ComplainDataAccess(new DatabaseContext());
        }
        public static IDiseaseDataAccess GetDiseaseDataAccess()
        {
            return new DiseaseDataAccess(new DatabaseContext());
        }
        public static IDoctorDataAccess GetDoctorDataAccess()
        {
            return new DoctorDataAccess(new DatabaseContext());
        }
        public static IMedicineDataAccess GetMedicineDataAccess()
        {
            return new MedicineDataAccess(new DatabaseContext());
        }
        public static IPatientDataAccess GetPatientDataAccess()
        {
            return new PatientDataAccess(new DatabaseContext());
        }
        public static IPrescriptionDataAccess GetPrescriptionDataAccess()
        {
            return new PrescriptionDataAccess(new DatabaseContext());
        }
        public static ISpecialistDataAccess GetSpecialistDataAccess()
        {
            return new SpecialistDataAccess(new DatabaseContext());
        }
        public static ISymptomDataAccess GetSymtomDataAccess()
        {
            return new SymptomDataAccess(new DatabaseContext());
        }
        public static IUserDataAccess GetUserDataAccess()
        {
            return new UserDataAccess(new DatabaseContext());
        }
    }
}
