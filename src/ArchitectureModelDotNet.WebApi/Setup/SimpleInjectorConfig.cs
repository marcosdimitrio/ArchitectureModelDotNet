using Academic.Infra.CrossCutting.IoC;
using Core.CrossCutting.IoC;
using SimpleInjector;

namespace ArchitectureModelDotNet.WebApi.Setup
{
    public static class SimpleInjectorConfig
    {
        public static void InitializeContainer(Container container, Lifestyle lifestyle, IConfiguration configuration)
        {
            MappingsCore.InitializeContainer(container, lifestyle);
            MappingsAcademic.InitializeContainer(container, lifestyle, configuration);
            MappingsWebApi.InitializeContainer(container, lifestyle);
        }

    }
}
