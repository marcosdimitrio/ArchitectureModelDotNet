using Academic.Domain.DAL.Repositories;
using Core.Services.DataTables.Interfaces.Dto;
using Microsoft.EntityFrameworkCore;
using Sieve.Models;
using Sieve.Services;

namespace Academic.Infra.Data.DAL.Repositories
{
    public abstract class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : class
    {
        private readonly ISieveProcessor _sieveProcessor;
        protected DbContext Context;
        protected DbSet<TEntity> DbSet;

        protected RepositoryBase(DbContext context, ISieveProcessor sieveProcessor)
        {
            Context = context;
            DbSet = context.Set<TEntity>();
            _sieveProcessor = sieveProcessor;
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

        //TODO: extract this as a dependency
        protected DataTablesResponse<TEntity> GetDataTablesResponse(DataTablesParameters dataTablesParameters)
        {
            var sieveModel = MapToSieveModel(dataTablesParameters);

            var questions = Get().AsNoTracking();

            questions = ApplyFilteringAndSorting(sieveModel, questions);

            var totalElements = questions.Count();

            questions = ApplyPagination(sieveModel, questions);

            var dataTablesResponse = new DataTablesResponse<TEntity>()
            {
                Content = questions.ToList(),
                Number = dataTablesParameters.Page ?? 1,
                Size = dataTablesParameters.PageSize ?? 10,
                TotalElements = totalElements,
            };

            return dataTablesResponse;
        }

        private IQueryable<TEntity> ApplyFilteringAndSorting(SieveModel sieveModel, IQueryable<TEntity> questions)
        {
            return _sieveProcessor.Apply(sieveModel, questions, applyPagination: false);
        }

        private IQueryable<TEntity> ApplyPagination(SieveModel sieveModel, IQueryable<TEntity> questions)
        {
            return _sieveProcessor.Apply(sieveModel, questions, applyFiltering: false, applySorting: false);
        }

        private static SieveModel MapToSieveModel(DataTablesParameters dataTablesParameters)
        {
            var newItem = new SieveModel()
            {
                Filters = dataTablesParameters.Filters,
                Sorts = dataTablesParameters.Sorts,
                Page = dataTablesParameters.Page,
                PageSize = dataTablesParameters.PageSize,
            };

            return newItem;
        }

    }
}
