using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using V.Doc_Data.Interfaces;
using V.Doc_Entity;

namespace V.Doc_Data.Abstract_Classes
{
    class PrescriptionDataAccess : IPrescriptionDataAccess
    {
        private DatabaseContext databaseContext;

        public PrescriptionDataAccess(DatabaseContext databaseContext)
        {
            this.databaseContext = databaseContext;
        }

        public int Delete(int id)
        {
            Prescription prescription = this.databaseContext.Prescriptions.SingleOrDefault(x => x.Id == id);
            this.databaseContext.Prescriptions.Remove(prescription);
            return this.databaseContext.SaveChanges();
        }

        public Prescription Get(int id)
        {
            return this.databaseContext.Prescriptions.SingleOrDefault(x => x.Id == id);
        }

        public IEnumerable<Prescription> GetAll()
        {
            return this.databaseContext.Prescriptions.ToList();
        }

        public int Insert(Prescription prescription)
        {
            this.databaseContext.Prescriptions.Add(prescription);
            return this.databaseContext.SaveChanges();
        }

        public int Update(Prescription prescription)
        {
            Prescription prescriptionToUpdate = this.databaseContext.Prescriptions.SingleOrDefault(x => x.Id == prescription.Id);

            prescriptionToUpdate.isSeenByReciever = prescription.isSeenByReciever;
            prescriptionToUpdate.isSeenBySender = prescription.isSeenBySender;
            prescriptionToUpdate.Details = prescription.Details;

            return this.databaseContext.SaveChanges();
        }
    }
}
