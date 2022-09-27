using Core.Services.DataTables.Interfaces.Dto;

namespace Core.Services.DataTables.Interfaces.Services
{
    public interface IDataTablesService
    {
        DataTablesResponse<TEntity> GetDataTablesResponse<TEntity>(IQueryable<TEntity> queryable, DataTablesParameters dataTablesParameters) where TEntity : class;
    }
}
