namespace ArchitectureModelDotNet.WebApi.Controllers.Students.Dto
{
    public sealed class StudentViewDto
    {
        public int Id { get; init; }
        public string Name { get; init; } = "";
        public string Email { get; init; } = "";
        public DateTime RegisteredOn { get; init; }
    }
}
