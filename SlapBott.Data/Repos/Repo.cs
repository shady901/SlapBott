using Microsoft.EntityFrameworkCore;
using SlapBott.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlapBott.Data.Repos
{
    public abstract class Repo<T> : IRepo<T> where T : class
    {
        protected SlapbottDbContext _dbContext { get; set; }

        public Repo(SlapbottDbContext dBContext)
        {
            _dbContext = dBContext;

        }
        public T Add(T entity)
        {
            _dbContext.Set<T>().Add(entity);
            _dbContext.SaveChanges();
            return entity;
        }

        public T? DeleteById(int Id)
        {
            return DeleteEnity(GetById(Id));
        }

        public T? DeleteById(string Id)
        {
            
            return DeleteEnity(GetById(Id));
        }

        public IEnumerable<T> GetAll()
        {
            return _dbContext.Set<T>().ToList();
        }

        public T? GetById(int Id)
        {
            return _dbContext.Set<T>().Find(Id);
        }

        public T? GetById(string Id)
        {
            return _dbContext.Set<T>().Find(Id);
        }

        public T Update(T entity)
        {
            _dbContext.Set<T>().Update(entity);
            _dbContext.SaveChanges(); // Save changes to reflect the update in the database
            return entity; // Return the updated entity
        }
        public T GetByIdOrNew(int Id)
        {
            return GetById(Id) ?? New();
        }

        public T GetByIdOrNew(string Id)
        {
            return GetById(Id) ?? New();
        }
      

        private T? DeleteEnity(T? Entity)
        {
            if (Entity == null) return null;
            _dbContext.Set<T>().Remove(Entity);
            _dbContext.SaveChanges();
            return Entity;
        }
        private T New()
        {
            return Activator.CreateInstance<T>();

        }

        public T AddOrUpdateEntity(T Entity)
        {
            
            if (isTracked(Entity))
            {
                return Update(Entity);

            }

            return Add(Entity);

        }

        private bool isTracked(T Entity)
        {

            var id = GetIdPropertyValue<int>(Entity);

            return _dbContext.ChangeTracker.Entries<T>().FirstOrDefault(x => GetIdPropertyValue<int>(x.Entity) == id) != null;
        }

   
        private B? GetIdPropertyValue<B>(object entity) where B : struct
        {
            var property = entity.GetType().GetProperty("Id");
            if (property != null)
            {
                return (B)property.GetValue(entity);
            }
            return null; // Or whatever default value you want to return if the Id property doesn't exist or is not an integer.
        }


    }
}
