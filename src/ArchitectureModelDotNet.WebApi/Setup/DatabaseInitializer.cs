using Core.Services.DatabaseInitializer.Interfaces;
using Microsoft.EntityFrameworkCore;
using SimpleInjector;
using SimpleInjector.Lifestyles;

namespace ArchitectureModelDotNet.WebApi.Setup
{
    public static class DatabaseInitializer
    {
        public static void InitializeDbContextDatabases(Container container)
        {
            ArgumentNullException.ThrowIfNull(container);

            using var scope = AsyncScopedLifestyle.BeginScope(container);

            var initializers = container
                .GetCurrentRegistrations()
                .Where(x =>
                    x.ImplementationType.GetInterfaces().Any(x =>
                        x.IsGenericType &&
                        x.GetGenericTypeDefinition() == typeof(IDatabaseInitializer<>)
                    )
                )
                .Select(x => x.GetInstance())
                .ToList();

            foreach (object initializer in initializers)
            {
                InitializeDatabase(initializer);
            }
        }

        private static void InitializeDatabase(object dbInitializer)
        {
            var dbInitializerInterfaceType = dbInitializer.GetType().GetInterfaces().Single();

            var methodName = nameof(IDatabaseInitializer<DbContext>.InitializeDatabase);

            dbInitializerInterfaceType
                .GetMethod(methodName)!
                .Invoke(dbInitializer, null);
        }
    }
}
