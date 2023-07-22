namespace Academic.Application.Services.Students.Dto
{
    public class StudentAppDto
    {
        public int Id { get; init; }
        public string Name { get; init; } = "";
        public string Email { get; init; } = "";
        public DateTime RegisteredOn { get; init; }
    }
}
