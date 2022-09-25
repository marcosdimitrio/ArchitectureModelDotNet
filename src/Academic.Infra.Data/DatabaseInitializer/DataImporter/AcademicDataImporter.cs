using Academic.Infra.Data.Context;
using Core.Services.DatabaseInitializer.Interfaces;
using Core.Services.EnumTableCreators.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Academic.Infra.Data.DatabaseInitializer.DataImporter
{
    public class AcademicDataImporter : IDataImporter<AcademicContext>
    {
        private readonly AcademicContext _context;
        private readonly IEnumTableCreator _enumTableCreator;

        public AcademicDataImporter(AcademicContext context, IEnumTableCreator enumTableCreator)
        {
            _context = context;
            _enumTableCreator = enumTableCreator;
        }

        public void Seed()
        {
            //_enumTableCreator.CreateAndFillTable<SomeEnum>(Context);

            var path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "SqlScripts", nameof(Academic));

            var allSqlFiles = GetFiles(path);

            foreach (var sqlFile in allSqlFiles)
            {
                _context.Database.ExecuteSqlRaw(File.ReadAllText(sqlFile));
            }
        }

        private static IList<string> GetFiles(string path)
        {
            if (!Directory.Exists(path))
            {
                throw new InvalidOperationException($"Error trying to import to database: Path \"{path}\" doesn't exist.");
            }

            var sqlFiles = Directory.GetFiles(path, "*.sql").OrderBy(x => x).ToList();

            var seedFiles = GetSeedFiles(path);

            var allFiles = new List<string>();
            allFiles.AddRange(sqlFiles);
            allFiles.AddRange(seedFiles);

            return allFiles;
        }

        private static IList<string> GetSeedFiles(string path)
        {
            var seedPath = Path.Combine(path, "Seed");

            if (!Directory.Exists(seedPath))
            {
                return new List<string>();
            }

            return Directory.GetFiles(seedPath, "*.sql").OrderBy(x => x).ToList();
        }

    }
}
