using Academic.Domain.Entities.Students;

namespace Academic.Domain.DAL.Repositories
{
    public interface IStudentRepository : IRepositoryBase<Student>
    {
        IList<Student> GetAll();
    }
}
