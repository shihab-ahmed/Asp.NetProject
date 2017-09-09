using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using V.Doc_Data.Interfaces;
using V.Doc_Entity;

namespace V.Doc_Data.Abstract_Classes
{
    class DoctorDataAccess : IDoctorDataAccess
    {
        private DatabaseContext databaseContext;

        public DoctorDataAccess(DatabaseContext databaseContext)
        {
            this.databaseContext = databaseContext;
        }

        public int Delete(int id)
        {
            Doctor doctor = this.databaseContext.Doctors.SingleOrDefault(x => x.Id == id);
            this.databaseContext.Doctors.Remove(doctor);
            return this.databaseContext.SaveChanges();
        }

        public Doctor Get(int id, bool isIncludeUser_Specialist_ContactList = false)
        {
            if(isIncludeUser_Specialist_ContactList)
            {
                return this.databaseContext.Doctors.Include("User").Include("Specialist").Include("ContactLists").SingleOrDefault(x => x.Id == id);
            }
            else
            {
                return this.databaseContext.Doctors.SingleOrDefault(x => x.Id == id);
            }
           
        }

        public IEnumerable<Doctor> GetAll(bool isIncludeUser_Specialist_ContactList = false)
        {
            if(isIncludeUser_Specialist_ContactList)
            {
                return this.databaseContext.Doctors.Include("User").Include("Specialist").Include("ContactLists").ToList();
            }
            else
            {
                return this.databaseContext.Doctors.ToList();
            }
            
        }

        public int Insert(Doctor doctor)
        {
            this.databaseContext.Doctors.Add(doctor);
            return this.databaseContext.SaveChanges();
        }

        public int Update(Doctor doctor)
        {
            Doctor doctorToUpdate = this.databaseContext.Doctors.SingleOrDefault(x => x.Id == doctor.Id);

            doctorToUpdate.Experience = doctor.Experience;
            doctorToUpdate.Specialist = doctor.Specialist;
            doctorToUpdate.About = doctor.About;
            doctorToUpdate.isAvailable = doctor.isAvailable;

            return this.databaseContext.SaveChanges();
        }

    }
}
