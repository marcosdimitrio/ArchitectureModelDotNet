using Microsoft.EntityFrameworkCore;

namespace Core.Services.DatabaseInitializer.Interfaces
{
    public interface IDatabaseInitializer<TContext> where TContext : DbContext
    {
        void InitializeDatabase();
    }
}
