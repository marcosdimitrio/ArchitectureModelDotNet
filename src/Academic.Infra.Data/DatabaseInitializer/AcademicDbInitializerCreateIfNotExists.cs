using Academic.Infra.Data.Context;
using Core.Services.DatabaseInitializer.Interfaces;

namespace Academic.Infra.Data.DatabaseInitializer
{
    public class AcademicDbInitializerCreateIfNotExists : IDatabaseInitializer<AcademicContext>
    {
        private readonly AcademicContext Context;
        private readonly IDataImporter<AcademicContext> DataImporter;

        public AcademicDbInitializerCreateIfNotExists(AcademicContext context, IDataImporter<AcademicContext> dataImporter)
        {
            Context = context;
            DataImporter = dataImporter;
        }

        public void InitializeDatabase()
        {
            var databaseWasCreated = Context.Database.EnsureCreated();

            if (databaseWasCreated)
            {
                DataImporter.Seed();
            }
        }
    }
}
