using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlapBott.Data.Repos
{
    public interface IRepo<T> where T : class
    {


        public T? GetById(int Id);       
        public T? GetById(string Id);
        public IEnumerable<T> GetAll();
        public T Update(T entity);
        public T? DeleteById(int Id);
        public T? DeleteById(string Id);
        public T Add(T entity);
        public T GetByIdOrNew(int Id); 
        public T GetByIdOrNew(string Id);
        public T AddOrUpdateEntity(T Entity);
    }
}
