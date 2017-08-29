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
    class MedicineService : IMedicineService
    {
        private IMedicineDataAccess medicineDataAccess;

        public MedicineService(IMedicineDataAccess medicineDataAccess)
        {
            this.medicineDataAccess = medicineDataAccess;
        }
        public int Delete(int id)
        {
            return this.medicineDataAccess.Delete(id);
        }

        public Medicine Get(int id)
        {
            return this.medicineDataAccess.Get(id);
        }

        public IEnumerable<Medicine> GetAll()
        {
            return this.medicineDataAccess.GetAll();
        }

        public int Insert(Medicine medicine)
        {
            return this.medicineDataAccess.Insert(medicine);
        }

        public int Update(Medicine medicine)
        {
            return this.medicineDataAccess.Update(medicine);
        }
    }
}
