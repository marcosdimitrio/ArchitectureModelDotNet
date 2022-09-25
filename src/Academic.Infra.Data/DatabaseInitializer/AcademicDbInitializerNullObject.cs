using Academic.Infra.Data.Context;
using Core.Services.DatabaseInitializer.Interfaces;

namespace Academic.Infra.Data.DatabaseInitializer
{
    public class AcademicDbInitializerNullObject : IDatabaseInitializer<AcademicContext>
    {
        public void InitializeDatabase()
        {
        }
    }
}
