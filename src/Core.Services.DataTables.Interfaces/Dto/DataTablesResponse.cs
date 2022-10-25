namespace Core.Services.DataTables.Interfaces.Dto
{
    public class DataTablesResponse<TEntity> where TEntity : class
    {
        public IList<TEntity> Content { get; init; }
        public int TotalElements { get; init; }
        public int Size { get; init; }
        public int Number { get; init; }
    }
}
