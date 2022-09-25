using Academic.Application.Services.Students.Interfaces;
using ArchitectureModelDotNet.WebApi.Controllers.Students.Dto;
using ArchitectureModelDotNet.WebApi.Controllers.Students.Mappers.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ArchitectureModelDotNet.WebApi.Controllers.Students
{
    [Route("api/students")]
    [ApiController]
    public sealed class StudentsController : ControllerBase
    {
        private readonly IStudentAppService _studentAppService;
        private readonly IMapperStudentToViewDto _mapperStudentToViewDto;

        public StudentsController(IStudentAppService studentAppService, IMapperStudentToViewDto mapperStudentToViewDto)
        {
            _studentAppService = studentAppService;
            _mapperStudentToViewDto = mapperStudentToViewDto;
        }

        [HttpGet]
        public PageDto<StudentViewDto> Get()
        {
            var students = _studentAppService.GetAll();

            var studentsViewDto = _mapperStudentToViewDto.Map(students);

            return new PageDto<StudentViewDto>()
            {
                Content = studentsViewDto,
                Number = 0,
                Size = studentsViewDto.Count,
                TotalElements = studentsViewDto.Count,
            };
        }
    }
}
