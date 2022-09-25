using Academic.Application.Services.Students.Dto;
using Academic.Application.Services.Students.Mappers.Interfaces;
using Academic.Domain.Entities.Students;

namespace Academic.Application.Services.Students.Mappers
{
    public class MapperStudentToAppDto : IMapperStudentToAppDto
    {
        public IList<StudentAppDto> Map(IList<Student> source)
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
