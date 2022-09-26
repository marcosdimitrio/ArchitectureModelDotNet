using Academic.Application.Services.Students.Dto;
using Core.Services.DataTables.Interfaces.Dto;

namespace Academic.Application.Services.Students.Interfaces
{
    public interface IStudentAppService
    {
        DataTablesResponse<StudentAppDto> Get(DataTablesParameters dataTablesParameters);
    }
}
