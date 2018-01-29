using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using SARC.Data.Entities;
using SARC.Data.Infraestructure;
using SARC.Repository.Framework;
using SARC.Service.Interfaces;

namespace SARC.Service
{
    public class UserService:IUserService  
    {  
        private IRepository<User> userRepository;  
  
        public UserService(IRepository<User> userRepository)  
        {  
            this.userRepository = userRepository;  
        }

        public bool Delete(long id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<User> GetAll()
        {
            throw new NotImplementedException();
        }

        public User Login(string Username, string Password)
        {
            return userRepository.GetAll(i => i.Username == Username.Trim() && i.Password == Password).FirstOrDefault();
        }

        public User GetById(long id)
        {
            throw new NotImplementedException();
        }

        public bool Insert(User user)
        {
            throw new NotImplementedException();
        }

        public bool Update(User user)
        {
            throw new NotImplementedException();
        }
    } 
}
