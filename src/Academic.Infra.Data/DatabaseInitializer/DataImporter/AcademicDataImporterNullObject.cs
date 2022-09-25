using Academic.Infra.Data.Context;
using Core.Services.DatabaseInitializer.Interfaces;

namespace Academic.Infra.Data.DatabaseInitializer.DataImporter
{
    public class AcademicDataImporterNullObject : IDataImporter<AcademicContext>
    {
        public void Seed()
        {
        }
    }
}
