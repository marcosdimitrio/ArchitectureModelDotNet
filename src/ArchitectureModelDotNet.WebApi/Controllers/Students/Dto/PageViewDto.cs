namespace ArchitectureModelDotNet.WebApi.Controllers.Students.Dto
{
    public sealed class PageViewDto<T> where T : class
    {
        public IList<T> Content { get; set; } = new List<T>();
        public int TotalElements { get; set; }
        public int Size { get; set; }
        public int Number { get; set; }
    }
}
