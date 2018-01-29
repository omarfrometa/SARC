using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Linq.Expressions;
using SARC.Data;
using SARC.Data.Infraestructure;

namespace SARC.Repository.Framework
{
    public class Repository<T> : IRepository<T> where T : BaseEntity  
    {  
        private readonly ApplicationContext context;  
        private DbSet<T> entities;  
  
        public Repository(ApplicationContext context)  
        {  
            this.context = context;  
            entities = context.Set<T>();  
        }  
        public IEnumerable<T> GetAll()  
        {  
            return entities.AsEnumerable();  
        }  
  
        public IEnumerable<T> GetAll(Expression<Func<T, bool>> specification)
        {
            return entities.Where(specification).AsEnumerable();
        }

        public T Get(long id)  
        {  
            return entities.SingleOrDefault(s => s.Id == id);  
        }  

        public bool Insert(T entity)  
        {  
            if (entity == null)  
            {  
                throw new ArgumentNullException("entity");  
            }  

            try
            {    
                entities.Add(entity);  
                var Success = context.SaveChanges() > 0;

                return Success;
            }
            catch (Exception ex)
            {
                return false;
            }
        }  
  
        public bool Update(T entity)  
        {  
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }

            try
            {
                var Success = context.SaveChanges() > 0;

                return Success;
            }
            catch (Exception ex)
            {
                return false;
            }
        }  
  
        public bool Delete(T entity)  
        {  
            try
            {
                entities.Remove(entity);  
                var Success = context.SaveChanges() > 0;

                return Success;
            }
            catch (Exception ex)
            {
                return false;
            }
        }  

        public void Remove(T entity)  
        {  
            if (entity == null)  
            {  
                throw new ArgumentNullException("entity");  
            }  
            entities.Remove(entity);              
        }  
  
        public void SaveChanges()  
        {  
            context.SaveChanges();  
        }  
    }  
}
