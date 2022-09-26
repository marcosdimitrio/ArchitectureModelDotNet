using Academic.Application.Services.Students.Dto;
using Academic.Application.Services.Students.Mappers.Interfaces;
using Academic.Domain.Entities.Students;
using Core.Services.DataTables.Interfaces.Dto;

namespace Academic.Application.Services.Students.Mappers
{
    public class MapperStudentToAppDto : IMapperStudentToAppDto
    {

        public DataTablesResponse<StudentAppDto> Map(DataTablesResponse<Student> item)
        {
            var newItem = new DataTablesResponse<StudentAppDto>()
            {
                Content = Map(item.Content),
                TotalElements = item.TotalElements,
                Size = item.Size,
                Number = item.Number,
            };

            return newItem;
        }

        private static IList<StudentAppDto> Map(IList<Student> source)
        {
            var destination = new List<StudentAppDto>();

            foreach (var item in source)
            {
                destination.Add(Map(item));
            }

            return destination;
        }

        private static StudentAppDto Map(Student item)
        {
            var newItem = new StudentAppDto()
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
