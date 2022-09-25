using ArchitectureModelDotNet.WebApi.Controllers.Students.Mappers;
using ArchitectureModelDotNet.WebApi.Controllers.Students.Mappers.Interfaces;
using SimpleInjector;

namespace ArchitectureModelDotNet.WebApi.Setup
{
    public static class MappingsWebApi
    {
        public static void InitializeContainer(Container container, Lifestyle lifestyle)
        {
            container.Register<IMapperStudentToViewDto, MapperStudentToViewDto>(lifestyle);
        }
    }
}
