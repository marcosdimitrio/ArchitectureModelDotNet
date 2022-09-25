using Academic.Domain.DAL.Repositories;

namespace Academic.Domain.DAL
{
    public interface IUnitOfWork
    {
        IStudentRepository StudentRepository { get; }

        void Save();
    }
}
