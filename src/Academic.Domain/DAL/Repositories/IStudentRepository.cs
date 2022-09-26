using Academic.Domain.Entities.Students;
using Core.Services.DataTables.Interfaces.Dto;

namespace Academic.Domain.DAL.Repositories
{
    public interface IStudentRepository : IRepositoryBase<Student>
    {
        DataTablesResponse<Student> Get(DataTablesParameters dataTablesParameters);
    }
}
