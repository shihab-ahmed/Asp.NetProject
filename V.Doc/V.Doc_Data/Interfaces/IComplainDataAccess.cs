﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using V.Doc_Entity;

namespace V.Doc_Data.Interfaces
{
    public interface IComplainDataAccess
    {
        IEnumerable<Complain> GetAll();
        Complain Get(int id, bool includeDepartment = false);
        int Insert(Complain employee);
        int Update(Complain employee);
        int Delete(int id);
    }
}
