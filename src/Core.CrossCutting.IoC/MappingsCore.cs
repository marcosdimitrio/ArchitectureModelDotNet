using Core.Services.EnumTableCreators;
using Core.Services.EnumTableCreators.Interfaces;
using SimpleInjector;

namespace Core.CrossCutting.IoC
{
    public static class MappingsCore
    {
        public static void InitializeContainer(Container container, Lifestyle lifestyle)
        {
            container.Register<IEnumTableCreator, EnumTableCreator>(lifestyle);
        }
    }
}