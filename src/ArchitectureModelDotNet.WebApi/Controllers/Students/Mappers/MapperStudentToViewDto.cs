using Academic.Application.Services.Students.Dto;
using ArchitectureModelDotNet.WebApi.Controllers.Students.Dto;
using ArchitectureModelDotNet.WebApi.Controllers.Students.Mappers.Interfaces;

namespace ArchitectureModelDotNet.WebApi.Controllers.Students.Mappers
{
    public class MapperStudentToViewDto : IMapperStudentToViewDto
    {
        public IList<StudentViewDto> Map(IList<StudentAppDto> source)
        {
            var destination = new List<StudentViewDto>();

            foreach (var item in source)
            {
                destination.Add(Map(item));
            }

            return destination;
        }

        private StudentViewDto Map(StudentAppDto item)
        {
            var newItem = new StudentViewDto()
            {
                Id = item.Id,
                Name = item.Name,
                Email = item.Email,
                RegisteredOn = item.RegisteredOn,
            };

            return newItem;
        }
    }
}
