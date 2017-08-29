﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using V.Doc_Service.Interfaces;
using V.Doc_Entity;

namespace V.Doc_Service.Abstract_Classes
{
    class DoctorService : IDoctorDataAccess
    {
        private DatabaseContext databaseContext;

        public DoctorService(DatabaseContext databaseContext)
        {
            this.databaseContext = databaseContext;
        }

        public int Delete(int id)
        {
            Doctor doctor = this.databaseContext.Doctors.SingleOrDefault(x => x.Id == id);
            this.databaseContext.Doctors.Remove(doctor);
            return this.databaseContext.SaveChanges();
        }

        public Doctor Get(int id)
        {
            return this.databaseContext.Doctors.SingleOrDefault(x => x.Id == id);
        }

        public IEnumerable<Doctor> GetAll()
        {
            return this.databaseContext.Doctors.ToList();
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
