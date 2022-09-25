using Academic.Domain.Entities.Students;
using Academic.Infra.Data.EntityConfig;
using Microsoft.EntityFrameworkCore;

namespace Academic.Infra.Data.Context
{
    public class AcademicContext : DbContext
    {
        public AcademicContext(DbContextOptions options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema(GetBoundedContextName());

            ModelConfiguration(modelBuilder);
        }

        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {
            configurationBuilder
                .Properties<string>()
                .HaveMaxLength(255);

            configurationBuilder
                .Properties<DateTime>()
                .HaveColumnType("datetime2(0)");

            configurationBuilder
                .Properties<DateTime?>()
                .HaveColumnType("datetime2(0)");

            configurationBuilder
                .Properties<decimal>()
                .HavePrecision(18, 2);
        }

        private void ModelConfiguration(ModelBuilder modelBuilder)
        {
            new StudentConfiguration().Configure(modelBuilder.Entity<Student>());
        }

        private string GetBoundedContextName()
        {
            return GetType().Namespace!.Split('.')[0];
        }
    }
}
