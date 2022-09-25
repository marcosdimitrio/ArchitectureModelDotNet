using Academic.Infra.CrossCutting.IoC;
using SimpleInjector;

namespace ArchitectureModelDotNet.WebApi.Setup
{
    public static class SimpleInjectorConfig
    {
        public static void InitializeContainer(Container container, Lifestyle lifestyle, IConfiguration configuration)
        {
            RegisterWebApiMappings(container, lifestyle);

            AcademicMappings.InitializeContainer(container, lifestyle, configuration);
        }

        private static void RegisterWebApiMappings(Container container, Lifestyle lifestyle)
        {
        }
    }
}
