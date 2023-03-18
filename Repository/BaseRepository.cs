using Entity.Context;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
    public abstract class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        protected readonly JustBlogContext context;
        protected DbSet<T> dbSet;

        public BaseRepository(JustBlogContext context)
        {
            this.context = context;
            dbSet = context.Set<T>();
        }

        public void Add(T entity)
        {
            dbSet.Add(entity);
        }

        public void Update(T entity)
        {
            dbSet.Update(entity);
        }

        public void Delete(T entity)
        {
            dbSet.Remove(entity);
        }

        public void Delete(Guid Id)
        {
            var entity = dbSet.Find(Id);
            dbSet.Remove(entity);
        }

        public T Find(Guid Id)
        {
            return dbSet.Find(Id);
        }

        public IList<T> GetAll()
        {
            return dbSet.ToList();
        }

        public void RemoveRange(IEnumerable<T> entities)
        {
            dbSet.RemoveRange(entities);
        }
    }
}