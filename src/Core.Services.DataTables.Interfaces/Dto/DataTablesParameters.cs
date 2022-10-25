using System.ComponentModel.DataAnnotations;

namespace Core.Services.DataTables.Interfaces.Dto
{
    public class DataTablesParameters
    {
        public string? Filters { get; init; }
        public string? Sorts { get; init; }
        [Range(1, int.MaxValue)]
        public int? Page { get; init; }
        [Range(1, int.MaxValue)]
        public int? PageSize { get; init; }
    }
}
