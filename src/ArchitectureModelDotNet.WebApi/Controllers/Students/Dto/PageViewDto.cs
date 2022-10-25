namespace ArchitectureModelDotNet.WebApi.Controllers.Students.Dto
{
    public sealed class PageViewDto<T> where T : class
    {
        public IList<T> Content { get; init; } = new List<T>();
        public int TotalElements { get; init; }
        public int Size { get; init; }
        public int Number { get; init; }
    }
}
