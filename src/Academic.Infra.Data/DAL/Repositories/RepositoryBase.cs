using Academic.Domain.DAL.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Academic.Infra.Data.DAL.Repositories
{
    public abstract class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : class
    {
        protected DbContext Context;
        protected DbSet<TEntity> DbSet;

        protected RepositoryBase(DbContext context)
        {
            Context = context;
            DbSet = context.Set<TEntity>();
        }

        public TEntity? GetById(object id)
        {
            return DbSet.Find(id);
        }

        public void Insert(TEntity entity)
        {
            DbSet.Add(entity);
        }

        public void Delete(TEntity entity)
        {
            if (Context.Entry(entity).State == EntityState.Detached)
            {
                DbSet.Attach(entity);
            }

            DbSet.Remove(entity);
        }

        public void Update(TEntity entityToUpdate)
        {
            DbSet.Attach(entityToUpdate);
            Context.Entry(entityToUpdate).State = EntityState.Modified;
        }

        protected IQueryable<TEntity> Get()
        {
            return DbSet;
        }

    }
}
