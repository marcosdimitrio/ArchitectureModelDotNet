using Academic.Domain.DAL.Repositories;
using Academic.Domain.Entities.Students;
using Academic.Infra.Data.Context;
using Core.Services.DataTables.Interfaces.Dto;
using Core.Services.DataTables.Interfaces.Services;

namespace Academic.Infra.Data.DAL.Repositories
{
    public class StudentRepository : RepositoryBase<Student>, IStudentRepository
    {
        public StudentRepository(AcademicContext context, IDataTablesService dataTablesService)
            : base(context, dataTablesService)
        {
        }

        public DataTablesResponse<Student> Get(DataTablesParameters dataTablesParameters)
        {
            return GetDataTablesResponse(dataTablesParameters);
        }

    }
}
