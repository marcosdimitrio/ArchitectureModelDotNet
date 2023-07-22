using Academic.Application.Services.Students.Dto;
using ArchitectureModelDotNet.WebApi.Controllers.Students.Dto;
using ArchitectureModelDotNet.WebApi.Controllers.Students.Mappers.Interfaces;
using Core.Services.DataTables.Interfaces.Dto;

namespace ArchitectureModelDotNet.WebApi.Controllers.Students.Mappers
{
    public class MapperStudentToViewDto : IMapperStudentToViewDto
    {

        public DataTablesResponse<StudentViewDto> Map(DataTablesResponse<StudentAppDto> source)
        {
            ArgumentNullException.ThrowIfNull(source);

            var newItem = new DataTablesResponse<StudentViewDto>()
            {
                Content = Map(source.Content),
                TotalElements = source.TotalElements,
                Size = source.Size,
                Number = source.Number,
            };

            return newItem;
        }

        private static IList<StudentViewDto> Map(IList<StudentAppDto> source)
        {
            var destination = new List<StudentViewDto>();

            foreach (var item in source)
            {
                destination.Add(Map(item));
            }

            return destination;
        }

        private static StudentViewDto Map(StudentAppDto item)
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
