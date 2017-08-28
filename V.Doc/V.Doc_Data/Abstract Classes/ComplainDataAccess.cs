using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using V.Doc_Data.Interfaces;
using V.Doc_Entity;

namespace V.Doc_Data.Abstract_Classes
{
    class ComplainDataAccess: IComplainDataAccess
    {
        private DatabaseContext databaseContext;

        public ComplainDataAccess(DatabaseContext databaseContext)
        {
            this.databaseContext = databaseContext;
        }
        public int Delete(int id)
        {
            Complain complain = this.databaseContext.Complains.SingleOrDefault(x => x.Id == id);
            this.databaseContext.Complains.Remove(complain);
            return this.databaseContext.SaveChanges();
        }

        public Complain Get(int id)
        {
            return this.databaseContext.Complains.SingleOrDefault(x => x.Id == id);
        }

        public IEnumerable<Complain> GetAll()
        {
            return this.databaseContext.Complains.ToList();
        }

        public int Insert(Complain complain)
        {
            this.databaseContext.Complains.Add(complain);
            return this.databaseContext.SaveChanges();
        }

        public int Update(Complain complain)
        {
            Complain ComplainToUpdate = this.databaseContext.Complains.SingleOrDefault(x => x.Id == complain.Id);

            ComplainToUpdate.Details = complain.Details;
            ComplainToUpdate.isSeenByAdmin = complain.isSeenByAdmin;
            return this.databaseContext.SaveChanges();
        }
    }
}
