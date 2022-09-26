using Academic.Application.Services.Students.Dto;
using Academic.Domain.Entities.Students;
using Core.Services.DataTables.Interfaces.Dto;

namespace Academic.Application.Services.Students.Mappers.Interfaces
{
    public interface IMapperStudentToAppDto
    {
        DataTablesResponse<StudentAppDto> Map(DataTablesResponse<Student> item);
    }
}
