using Academic.Application.Services.Students.Dto;
using ArchitectureModelDotNet.WebApi.Controllers.Students.Dto;
using Core.Services.DataTables.Interfaces.Dto;

namespace ArchitectureModelDotNet.WebApi.Controllers.Students.Mappers.Interfaces
{
    public interface IMapperStudentToViewDto
    {
        DataTablesResponse<StudentViewDto> Map(DataTablesResponse<StudentAppDto> source);
    }
}
