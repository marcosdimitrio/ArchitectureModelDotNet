using Academic.Domain.DAL.Repositories;
using Academic.Domain.Entities.Students;
using Academic.Infra.Data.Context;
using Core.Services.DataTables.Interfaces.Dto;
using Sieve.Services;

namespace Academic.Infra.Data.DAL.Repositories
{
    public class StudentRepository : RepositoryBase<Student>, IStudentRepository
    {
        public StudentRepository(AcademicContext context, ISieveProcessor sieveProcessor)
            : base(context, sieveProcessor)
        {
        }

        public DataTablesResponse<Student> Get(DataTablesParameters dataTablesParameters)
        {
            return GetDataTablesResponse(dataTablesParameters);
        }

    }
}
