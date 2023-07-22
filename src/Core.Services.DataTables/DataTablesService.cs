using Core.Services.DataTables.Interfaces.Dto;
using Core.Services.DataTables.Interfaces.Services;
using Sieve.Models;
using Sieve.Services;

namespace Core.Services.DataTables
{
    public class DataTablesService : IDataTablesService
    {
        private readonly ISieveProcessor _sieveProcessor;

        public DataTablesService(ISieveProcessor sieveProcessor)
        {
            _sieveProcessor = sieveProcessor;
        }

        public DataTablesResponse<TEntity> GetDataTablesResponse<TEntity>(IQueryable<TEntity> queryable, DataTablesParameters dataTablesParameters) where TEntity : class
        {
            ArgumentNullException.ThrowIfNull(dataTablesParameters);

            var sieveModel = MapToSieveModel(dataTablesParameters);

            queryable = ApplyFilteringAndSorting(sieveModel, queryable);
            var totalElements = queryable.Count();
            queryable = ApplyPagination(sieveModel, queryable);

            var dataTablesResponse = new DataTablesResponse<TEntity>()
            {
                Content = queryable.ToList(),
                Number = dataTablesParameters.Page ?? 1,
                Size = dataTablesParameters.PageSize ?? 10,
                TotalElements = totalElements,
            };

            return dataTablesResponse;
        }

        private IQueryable<TEntity> ApplyFilteringAndSorting<TEntity>(SieveModel sieveModel, IQueryable<TEntity> questions)
        {
            return _sieveProcessor.Apply(sieveModel, questions, applyPagination: false);
        }

        private IQueryable<TEntity> ApplyPagination<TEntity>(SieveModel sieveModel, IQueryable<TEntity> questions)
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