using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using V.Doc_Service.Interfaces;
using V.Doc_Entity;
using V.Doc_Data.Interfaces;

namespace V.Doc_Service.Abstract_Classes
{
    class PrescriptionService : IPrescriptionService
    {
       /* private IPrescriptionDataAccess prescriptionDataAccess;

        public PrescriptionService(IPrescriptionDataAccess prescriptionDataAccess)
        {
            this.prescriptionDataAccess = prescriptionDataAccess;
        }
        public int Delete(int id)
        {
            return this.prescriptionDataAccess.Delete(id);
        }

        public Prescription Get(int id)
        {
            return this.prescriptionDataAccess.Get(id);
        }

        public IEnumerable<Prescription> GetAll()
        {
            return this.prescriptionDataAccess.GetAll();
        }

        public int Insert(Prescription prescription)
        {
            return this.prescriptionDataAccess.Insert(prescription);
        }

        public int Update(Prescription prescription)
        {
            return this.prescriptionDataAccess.Update(prescription);
        }*/
    }
}
