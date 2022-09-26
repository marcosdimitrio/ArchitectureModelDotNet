using System.ComponentModel.DataAnnotations;

namespace Core.Services.DataTables.Interfaces.Dto
{
    public class DataTablesParameters
    {
        public string? Filters { get; set; }
        public string? Sorts { get; set; }
        [Range(1, int.MaxValue)]
        public int? Page { get; set; }
        [Range(1, int.MaxValue)]
        public int? PageSize { get; set; }
    }
}
