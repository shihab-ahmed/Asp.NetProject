using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using V.Doc_Entity;

namespace V.Doc_Data
{
    public class DatabaseContext:DbContext
    {
        public DbSet<Chat> Chats { get; set; }
        public DbSet<Complain> Complains { get; set; }
        public DbSet<Disease> Diseases { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Medicine> Medicines { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Prescription> Prescriptions { get; set; }
        public DbSet<Specialist> Specialists { get; set; }
        public DbSet<Symptom> Symptoms { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Contact> Contacts { get; set; }
    }
}
