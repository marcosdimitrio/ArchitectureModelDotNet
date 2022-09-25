using Academic.Application.Services.Students.Dto;
using ArchitectureModelDotNet.WebApi.Controllers.Students.Dto;

namespace ArchitectureModelDotNet.WebApi.Controllers.Students.Mappers.Interfaces
{
    public interface IMapperStudentToViewDto
    {
        IList<StudentViewDto> Map(IList<StudentAppDto> source);
    }
}
