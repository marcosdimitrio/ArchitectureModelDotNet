using Academic.Domain.DAL.Repositories;
using Core.Services.DataTables.Interfaces.Dto;
using Core.Services.DataTables.Interfaces.Services;
using Microsoft.EntityFrameworkCore;

namespace Academic.Infra.Data.DAL.Repositories
{
    public abstract class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : class
    {
        private readonly IDataTablesService _dataTablesService;
        protected DbContext Context { get; private set; }
        protected DbSet<TEntity> DbSet { get; private set; }

        protected RepositoryBase(DbContext context, IDataTablesService dataTablesService)
        {
            ArgumentNullException.ThrowIfNull(context);

            Context = context;
            DbSet = context.Set<TEntity>();
            _dataTablesService = dataTablesService;
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

        public void Update(TEntity entity)
        {
            DbSet.Attach(entity);
            Context.Entry(entity).State = EntityState.Modified;
        }

        protected IQueryable<TEntity> Get()
        {
            return DbSet;
        }

        protected DataTablesResponse<TEntity> GetDataTablesResponse(DataTablesParameters dataTablesParameters)
        {
            var dataTablesResponse = _dataTablesService.GetDataTablesResponse(Get().AsNoTracking(), dataTablesParameters);

            return dataTablesResponse;
        }
    }
}
