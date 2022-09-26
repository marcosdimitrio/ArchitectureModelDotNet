using ArchitectureModelDotNet.WebApi.Controllers.Students.Mappers;
using ArchitectureModelDotNet.WebApi.Controllers.Students.Mappers.Interfaces;
using ArchitectureModelDotNet.WebApi.Setup.SieveMappings;
using Sieve.Services;
using SimpleInjector;

namespace ArchitectureModelDotNet.WebApi.Setup
{
    public static class MappingsWebApi
    {
        public static void InitializeContainer(Container container, Lifestyle lifestyle)
        {
            RegisterServices(container, lifestyle);

            RegisterMappers(container, lifestyle);
        }

        private static void RegisterServices(Container container, Lifestyle lifestyle)
        {
            container.Register<ISieveProcessor, CustomSieveProcessor>(lifestyle);
        }

        private static void RegisterMappers(Container container, Lifestyle lifestyle)
        {
            container.Register<IMapperStudentToViewDto, MapperStudentToViewDto>(lifestyle);
        }
    }
}
