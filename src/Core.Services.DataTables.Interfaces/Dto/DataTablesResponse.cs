namespace Core.Services.DataTables.Interfaces.Dto
{
    public class DataTablesResponse<TEntity> where TEntity : class
    {
        public IList<TEntity> Content { get; init; }
        public int TotalElements { get; set; }
        public int Size { get; set; }
        public int Number { get; set; }
    }
}
