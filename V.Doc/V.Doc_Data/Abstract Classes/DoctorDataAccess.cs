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
                return this.databaseContext.Doctors.Include("User").Include("Specialist").SingleOrDefault(x => x.Id == id);
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
                return this.databaseContext.Doctors.Include("User").Include("Specialist").ToList();
            }
            else
            {
                return this.databaseContext.Doctors.ToList();
            }
            
        }

        public Doctor GetUsingUser(User user, bool isExtra = false)
        {
            if (isExtra)
            {
                return this.databaseContext.Doctors.Include("User").Include("Specialist").SingleOrDefault(x => x.User.Id == user.Id);
            }
            else
            {
                return this.databaseContext.Doctors.SingleOrDefault(x => x.User.Id == user.Id);
            }
        }

        public int Insert(Doctor doctor)
        {
            this.databaseContext.Doctors.Add(doctor);
            return this.databaseContext.SaveChanges();
        }

        public IEnumerable<Doctor> Search(string SearchBy, string SearchValue)
        {
            List<Doctor> doctorList = new List<Doctor>();

            if (SearchValue != "")
            {
                if (SearchBy == "FirstName")
                {
                    doctorList = this.databaseContext.Doctors.Include("User").Where(x => x.User.FirstName.StartsWith(SearchValue)).ToList();
                }
                else if (SearchBy == "LastName")
                {
                    doctorList = this.databaseContext.Doctors.Include("User").Where(x => x.User.LastName.StartsWith(SearchValue)).ToList();
                }
                else if (SearchBy == "Gender")
                {
                    doctorList = this.databaseContext.Doctors.Include("User").Where(x => x.User.Gender.StartsWith(SearchValue)).ToList();
                }
                else if (SearchBy == "Specialist")
                {
                    doctorList = this.databaseContext.Doctors.Include("User").Include("Specialist").Where(x => x.Specialist.Type.StartsWith(SearchValue)).ToList();
                }
            }
            else
            {
                return this.databaseContext.Doctors.Include("User").Include("Specialist").ToList();
            }
            return doctorList;
        }

        public int Update(Doctor doctor)
        {
            Doctor doctorToUpdate = this.databaseContext.Doctors.SingleOrDefault(x => x.Id == doctor.Id);

            doctorToUpdate.Experience = doctor.Experience;
            //doctorToUpdate.Specialist = doctor.Specialist;
            doctorToUpdate.About = doctor.About;
            doctorToUpdate.isAvailable = doctor.isAvailable;

            return this.databaseContext.SaveChanges();
        }

    }
}
