using System;
using System.Collections.Generic;
using SARC.Data.Entities;
using SARC.Models;
using SARC.Repository.Framework;
using SARC.Service.Helpers;
using SARC.Service.Infraestructure;
using Microsoft.EntityFrameworkCore;
using SARC.Repository;

namespace SARC.Service
{
    public class AuthenticationService
    {
        IRepository<User> userRepository = null;
        public AuthenticationService(string conString)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationContext>();
            optionsBuilder.UseSqlServer(conString);

            userRepository = new Repository<User>(new ApplicationContext(optionsBuilder.Options));
        }

        public ServiceResult<UserViewModel> AllUsers()
        {
            ServiceResult<UserViewModel> sr = new ServiceResult<UserViewModel>
            {
                Success = false,
                ResultObject = new UserViewModel(),
                Messages = new List<string>(new string[] { Error.GetErrorMessage(Error.InternalServerError) })
            };

            var x = this.userRepository.ListAll();

            var y = this.userRepository.GetAll(i => i.DisplayName == "");

            /*
            if (x.Successfull)
            {
                sr.Success = x.Successfull;
                sr.ResultObject = x.Data;
                sr.Messages.Add(Error.GetErrorMessage(Error.NotFoundError));
            }
            else
            {
                sr.Success = false;
                sr.ResultObject = x.Data;
                sr.Messages.Add(Error.GetErrorMessage(Error.RecordNotFound));
            }
*/
            return sr;
        }

        public ServiceResult<UserViewModel> RequestAccess(ServiceRequest<UserViewModel> model)
        {
            ServiceResult<UserViewModel> sr = new ServiceResult<UserViewModel>
            {
                Success = false,
                ResultObject = new UserViewModel(),
                Messages = new List<string>(new string[] { Error.GetErrorMessage(Error.InternalServerError) })
            };

            if (model == null)
            {
                sr.Messages = new List<string>(new string[] { Error.GetErrorMessage(Error.ModelIsNotValid) });
                return sr;
            }


            var x = this.userRepository.GetAll(i => i.Username == model.RequestObject.Username.Trim());
                                               //&& i.Password == model.RequestObject.Password.Trim());

            if (x.Successfull)
            {
                sr.Success = x.Successfull;
                sr.ResultObject = model.RequestObject.GetUserModel(x.Data);
                sr.Messages.Add(Error.GetErrorMessage(Error.NotFoundError));
            }else
            {
                sr.Success = false;
                sr.ResultObject = model.RequestObject.GetUserModel(x.Data);
                sr.Messages.Add(Error.GetErrorMessage(Error.LoginFail));
            }

            return sr;
        }
    }
}
