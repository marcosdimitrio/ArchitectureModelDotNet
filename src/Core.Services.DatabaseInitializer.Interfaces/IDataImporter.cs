using Microsoft.EntityFrameworkCore;

namespace Core.Services.DatabaseInitializer.Interfaces
{
    public interface IDataImporter<TContext> where TContext : DbContext
    {
        void Seed();
    }
}
