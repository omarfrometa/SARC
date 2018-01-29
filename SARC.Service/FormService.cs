using System;
using System.Collections.Generic;
using SARC.Models;
using SARC.Repository.Framework;
using SARC.Service.Helpers;
using SARC.Service.Infraestructure;
using SARC.Data.Entities;
using Microsoft.EntityFrameworkCore;
using SARC.Repository;

namespace SARC.Service
{
    public class FormService
    {
        IRepository<Process> processRepository = null;
        public FormService(string conString)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationContext>();
            optionsBuilder.UseSqlServer(conString);

            processRepository = new Repository<Process>(new ApplicationContext(optionsBuilder.Options));
        }

        public ServiceResult<ProcessViewModel> AllProcess()
        {
            ServiceResult<ProcessViewModel> sr = new ServiceResult<ProcessViewModel>
            {
                Success = false,
                ResultObject = new ProcessViewModel(),
                Messages = new List<string>(new string[] { Error.GetErrorMessage(Error.InternalServerError) })
            };

            var x = this.processRepository.ListAll();


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
    }
}
