using DALL.Context;
using DALL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALL.Repositories
{
    public class Repository<TEntity>:IRepository<TEntity> where TEntity:class
    {
        protected readonly ApContext context;
        public Repository (ApContext app)
        {
            context = app;
        }

        public void Create(TEntity item)
        {
            context.Set<TEntity>().Add(item);
        }

        public void Delete(int id)
        {
            TEntity entity= context.Set<TEntity>().Find(id);
            if (entity != null)
                context.Set<TEntity>().Remove(entity);

        }

        public IEnumerable<TEntity> Find(Func<TEntity, bool> predicate)
        {
            return context.Set<TEntity>().Where(predicate).ToList();
        }

        public TEntity Get(int id)
        {
            return context.Set<TEntity>().Find(id);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return context.Set<TEntity>();
        }

        public void Update(TEntity item)
        {
            context.Entry(item).State=System.Data.Entity.EntityState.Modified;
        }
    }
}
