using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using V.Doc_Data.Interfaces;
using V.Doc_Entity;

namespace V.Doc_Data.Abstract_Classes
{
    class MedicineDataAccess : IMedicineDataAccess
    {
        private DatabaseContext databaseContext;

        public MedicineDataAccess(DatabaseContext databaseContext)
        {
            this.databaseContext = databaseContext;
        }
        public int Delete(int id)
        {
            Medicine medicine = this.databaseContext.Medicines.SingleOrDefault(x => x.Id == id);
            this.databaseContext.Medicines.Remove(medicine);
            return this.databaseContext.SaveChanges();
        }

        public Medicine Get(int id)
        {
            return this.databaseContext.Medicines.SingleOrDefault(x => x.Id == id);
        }

        public IEnumerable<Medicine> GetAll()
        {
            return this.databaseContext.Medicines.ToList();
        }

        public int Insert(Medicine medicine)
        {
            this.databaseContext.Medicines.Add(medicine);
            return this.databaseContext.SaveChanges();
        }

        public int Update(Medicine medicine)
        {
            Medicine MedicineToUpdate = this.databaseContext.Medicines.SingleOrDefault(x => x.Id == medicine.Id);

            MedicineToUpdate.Name = medicine.Name;
            MedicineToUpdate.Type = medicine.Type;

            return this.databaseContext.SaveChanges();
        }
    }
}
