using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using SARC.Data;
using SARC.Data.Infraestructure;

namespace SARC.Repository.Framework
{
    public interface IRepository<T> where T : BaseEntity  
    {  
        IEnumerable<T> GetAll();
        IEnumerable<T> GetAll(Expression<Func<T, bool>> specification);
        T Get(long id);  
        bool Insert(T entity);  
        bool Update(T entity);  
        bool Delete(T entity);  
        void Remove(T entity);  
        void SaveChanges();  
    }  
}
