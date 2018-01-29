using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using SARC.Data.Entities;
using SARC.Data.Infraestructure;

namespace SARC.Service.Interfaces
{
    public  interface IUserService  
    {  
        IEnumerable<User> GetAll();  
        User GetById(long id);  
        bool Insert(User user);  
        bool Update(User user);  
        bool Delete(long id);

        User Login(string Username, string Password);
    }  
}
