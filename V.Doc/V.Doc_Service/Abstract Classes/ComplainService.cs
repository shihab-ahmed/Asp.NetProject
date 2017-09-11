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
    class ComplainService : IComplainService
    {
       /* private IComplainDataAccess complainDataAccess;

        public ComplainService(IComplainDataAccess complainDataAccess)
        {
            this.complainDataAccess = complainDataAccess;
        }
        public int Delete(int id)
        {
            return this.complainDataAccess.Delete(id);
        }

        public Complain Get(int id)
        {
            return this.complainDataAccess.Get(id);
        }

        public IEnumerable<Complain> GetAll()
        {
            return this.complainDataAccess.GetAll();
        }

        public int Insert(Complain complain)
        {
            return this.complainDataAccess.Insert(complain);
        }

        public int Update(Complain complain)
        {
            return this.complainDataAccess.Update(complain);
        }*/
    }
}
