using Academic.Application.Services.Students.Dto;
using Academic.Application.Services.Students.Interfaces;
using Academic.Application.Services.Students.Mappers.Interfaces;
using Academic.Domain.DAL;

namespace Academic.Application.Services.Students
{
    public class StudentAppService : IStudentAppService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapperStudentToAppDto _mapperStudentToAppDto;

        public StudentAppService(IUnitOfWork unitOfWork, IMapperStudentToAppDto mapperStudentToAppDto)
        {
            _unitOfWork = unitOfWork;
            _mapperStudentToAppDto = mapperStudentToAppDto;
        }

        public IList<StudentAppDto> GetAll()
        {
            var students = _unitOfWork.StudentRepository.GetAll();

            var studentsAppDto = _mapperStudentToAppDto.Map(students);

            return studentsAppDto;
        }
    }
}
