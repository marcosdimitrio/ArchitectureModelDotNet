using Academic.Application.Services.Students.Dto;

namespace Academic.Application.Services.Students.Interfaces
{
    public interface IStudentAppService
    {
        IList<StudentAppDto> GetAll();
    }
}
