using Academic.Application.Services.Students.Dto;
using Academic.Domain.Entities.Students;

namespace Academic.Application.Services.Students.Mappers.Interfaces
{
    public interface IMapperStudentToAppDto
    {
        IList<StudentAppDto> Map(IList<Student> source);
    }
}
