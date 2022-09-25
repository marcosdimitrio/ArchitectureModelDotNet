using Academic.Domain.DAL;
using Academic.Domain.DAL.Repositories;
using Academic.Infra.Data.Context;
using Academic.Infra.Data.DAL;
using Academic.Infra.Data.DAL.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SimpleInjector;

namespace Academic.Infra.CrossCutting.IoC
{
    public static class AcademicMappings
    {
        public static void InitializeContainer(Container container, Lifestyle lifestyle, IConfiguration configuration)
        {
            RegisterUnitOfWork(container, lifestyle);

            RegisterDbContext(container, lifestyle, configuration);

            RegisterDAL(container, lifestyle);
        }

        private static void RegisterDbContext(Container container, Lifestyle lifestyle, IConfiguration configuration)
        {
            var contextRegistration = lifestyle.CreateRegistration(() =>
            {
                var optionsBuilder = new DbContextOptionsBuilder<AcademicContext>()
                    .UseSqlServer(configuration.GetConnectionString("ArchitectureModelDotNetAcademic"));

                return new AcademicContext(optionsBuilder.Options);
            }, container);

            container.AddRegistration<AcademicContext>(contextRegistration);
        }

        private static void RegisterUnitOfWork(Container container, Lifestyle lifestyle)
        {
            container.Register<IUnitOfWork, UnitOfWork>(lifestyle);
        }

        private static void RegisterDAL(Container container, Lifestyle lifestyle)
        {
            var repositoryImplementationTypes = container.GetTypesToRegister(typeof(RepositoryBase<>), new[] { typeof(RepositoryBase<>).Assembly });

            foreach (var repositoryImplementationType in repositoryImplementationTypes)
            {
                var serviceType = repositoryImplementationType
                    .GetInterfaces()
                    .Where(x => x.Name != typeof(IRepositoryBase<>).Name)
                    .Single();

                container.RegisterConditional(
                    serviceType,
                    repositoryImplementationType,
                    lifestyle,
                    x => x.Consumer.ImplementationType == typeof(UnitOfWork)
                );
            }
        }
    }
}