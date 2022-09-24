using ArchitectureModelDotNet.WebApi.Controllers.Students.Dto;
using Microsoft.AspNetCore.Mvc;

namespace ArchitectureModelDotNet.WebApi.Controllers.Students
{
    [Route("api/students")]
    [ApiController]
    public sealed class StudentsController : ControllerBase
    {
        [HttpGet]
        public PageDto<StudentViewDto> Get()
        {
            var list = new List<StudentViewDto>()
            {
                new StudentViewDto()
                {
                    Id = 1,
                    Name = "Test1",
                    Email = "test1@nowhere.com",
                    RegisteredOn = new DateTime(2022, 1, 5),
                },
                new StudentViewDto()
                {
                    Id = 2,
                    Name = "Test2",
                    Email = "test2@nowhere.com",
                    RegisteredOn = new DateTime(2022, 7, 23),
                },
                new StudentViewDto()
                {
                    Id = 3,
                    Name = "Test3",
                    Email = "test3@nowhere.com",
                    RegisteredOn = new DateTime(2022, 9, 11),
                },
            };

            return new PageDto<StudentViewDto>()
            {
                Content = list,
                Number = 0,
                Size = list.Count,
                TotalElements = list.Count,
            };
        }
    }
}
