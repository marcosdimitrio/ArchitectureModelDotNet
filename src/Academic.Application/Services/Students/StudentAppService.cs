using Academic.Application.Services.Students.Dto;
using Academic.Application.Services.Students.Interfaces;
using Academic.Application.Services.Students.Mappers.Interfaces;
using Academic.Domain.DAL;
using Core.Services.DataTables.Interfaces.Dto;

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

        public DataTablesResponse<StudentAppDto> Get(DataTablesParameters dataTablesParameters)
        {
            var students = _unitOfWork.StudentRepository.Get(dataTablesParameters);

            var studentsAppDto = _mapperStudentToAppDto.Map(students);

            return studentsAppDto;
        }
    }
}
