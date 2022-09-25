namespace Academic.Domain.Entities.Students
{
    public class Student
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public string Email { get; private set; }
        public DateTime RegisteredOn { get; private set; }
    }
}
