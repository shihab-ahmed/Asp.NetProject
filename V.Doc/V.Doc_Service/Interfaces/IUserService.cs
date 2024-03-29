﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using V.Doc_Entity;

namespace V.Doc_Service.Interfaces
{
    public interface IUserService
    {
        IEnumerable<User> GetAll();
        IEnumerable<User> Search(String SearchBy, String SearchValue);
        User Get(int id);
        User Get(String UserName);
        int Insert(User user);
        int Update(User user);
        int Delete(int id);
        bool ValidateCredentials(User user);
    }
}
