using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SARC.Data.Entities;
using SARC.Models;
using SARC.Repository.Framework;
using SARC.Service;
using SARC.Service.Infraestructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using SARC.Service.Helpers;
using SARC.Service.Interfaces;
using SARC.Data.Infraestructure;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SARC.WebAPI.Controllers
{
    [Route("api/[controller]")]
    public class AccountController : Controller
    {
        private readonly IUserService userService;  
  
        public AccountController(IUserService userService)  
        {  
            this.userService = userService;  
        }  

        // GET: /<controller>/
        [HttpGet("AllUsers")]
        public IEnumerable<User> All()
        {
            var result = userService.GetAll();

            return result;
        }

        // GET: /<controller>/
        [HttpPost("Login")]
        public DataResult<UserViewModel> Login(string Username, string Password)
        {
            var result = new DataResult<UserViewModel>();

            if(string.IsNullOrEmpty(Username) || string.IsNullOrEmpty(Password)){
                result.ActionTitle = "Warning";
                result.Messages.Add("Username and Password Required.");
                result.Success = false;

                return result;
            }

            Password = OFUtility.Security.EncryptPassword(Password.Trim());
            var x = userService.Login(Username, Password);
            if(x == null){
                result.ActionTitle = "Warning";
                result.Messages.Add("Invalid Credentials");
                result.Success = false;

                return result;
            }

            result.ActionTitle = "Success";
            result.Success = true;
            result.ResultObject = new UserViewModel
            {
                Id = x.Id,
                Username = x.Username,
                UserRolId = x.UserRolId,
                RowId = x.RowId,
                Created = x.Created
            };

            return result;
        }
    }
}
