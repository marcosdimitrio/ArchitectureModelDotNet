using Academic.Infra.Data.Context;
using Core.Services.DatabaseInitializer.Interfaces;

namespace Academic.Infra.Data.DatabaseInitializer
{
    public class AcademicDbInitializerDropCreateAlways : IDatabaseInitializer<AcademicContext>
    {
        private readonly AcademicContext Context;
        private readonly IDataImporter<AcademicContext> DataImporter;

        public AcademicDbInitializerDropCreateAlways(AcademicContext context, IDataImporter<AcademicContext> dataImporter)
        {
            Context = context;
            DataImporter = dataImporter;
        }

        public void InitializeDatabase()
        {
            Context.Database.EnsureDeleted();
            Context.Database.EnsureCreated();

            DataImporter.Seed();
        }
    }
}
