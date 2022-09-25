using Academic.Application.Services.Students;
using Academic.Application.Services.Students.Interfaces;
using Academic.Application.Services.Students.Mappers;
using Academic.Application.Services.Students.Mappers.Interfaces;
using Academic.Domain.DAL;
using Academic.Domain.DAL.Repositories;
using Academic.Infra.Data.Context;
using Academic.Infra.Data.DAL;
using Academic.Infra.Data.DAL.Repositories;
using Academic.Infra.Data.DatabaseInitializer;
using Academic.Infra.Data.DatabaseInitializer.DataImporter;
using Core.Services.DatabaseInitializer.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SimpleInjector;

namespace Academic.Infra.CrossCutting.IoC
{
    public static class MappingsAcademic
    {
        public static void InitializeContainer(Container container, Lifestyle lifestyle, IConfiguration configuration)
        {
            RegisterApplication(container, lifestyle);

            RegisterDatabaseInitializer(container, lifestyle);

            RegisterUnitOfWork(container, lifestyle);

            RegisterDAL(container, lifestyle);

            RegisterDbContext(container, lifestyle, configuration);
        }

        private static void RegisterApplication(Container container, Lifestyle lifestyle)
        {
            container.Register<IStudentAppService, StudentAppService>(lifestyle);
            container.Register<IMapperStudentToAppDto, MapperStudentToAppDto>(lifestyle);
        }

        private static void RegisterDatabaseInitializer(Container container, Lifestyle lifestyle)
        {
            container.Register<IDataImporter<AcademicContext>, AcademicDataImporter>(lifestyle);
            container.Register<IDatabaseInitializer<AcademicContext>, AcademicDbInitializerCreateIfNotExists>(lifestyle);
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

    }
}