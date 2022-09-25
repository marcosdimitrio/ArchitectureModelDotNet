using Academic.Domain.DAL.Repositories;
using Academic.Domain.Entities.Students;
using Academic.Infra.Data.Context;

namespace Academic.Infra.Data.DAL.Repositories
{
    public class StudentRepository : RepositoryBase<Student>, IStudentRepository
    {
        public StudentRepository(AcademicContext context)
            : base(context)
        {
        }
    }
}
