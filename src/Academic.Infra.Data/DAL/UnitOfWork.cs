using Academic.Domain.DAL;
using Academic.Domain.DAL.Repositories;
using Academic.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Academic.Infra.Data.DAL
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DbContext _dbContext;

        public IStudentRepository StudentRepository { get; }

        public UnitOfWork(AcademicContext dbContext, IStudentRepository studentRepository)
        {
            _dbContext = dbContext;
            StudentRepository = studentRepository;
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }
    }
}
