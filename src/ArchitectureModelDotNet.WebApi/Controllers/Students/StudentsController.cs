using Academic.Application.Services.Students.Interfaces;
using ArchitectureModelDotNet.WebApi.Controllers.Students.Dto;
using ArchitectureModelDotNet.WebApi.Controllers.Students.Mappers.Interfaces;
using Core.Services.DataTables.Interfaces.Dto;
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
        public PageViewDto<StudentViewDto> Get([FromQuery] DataTablesParameters dataTablesParameters)
        {
            var students = _studentAppService.Get(dataTablesParameters);

            var dataTablesResponse = _mapperStudentToViewDto.Map(students);

            return new PageViewDto<StudentViewDto>()
            {
                Content = dataTablesResponse.Content,
                Number = dataTablesResponse.Number,
                Size = dataTablesResponse.Size,
                TotalElements = dataTablesResponse.TotalElements,
            };
        }
    }
}
