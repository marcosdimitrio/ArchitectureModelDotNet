using Core.Services.DataTables;
using Core.Services.DataTables.Interfaces.Services;
using Core.Services.EnumTableCreators;
using Core.Services.EnumTableCreators.Interfaces;
using SimpleInjector;

namespace Core.CrossCutting.IoC
{
    public static class MappingsCore
    {
        public static void InitializeContainer(Container container, Lifestyle lifestyle)
        {
            ArgumentNullException.ThrowIfNull(container);

            container.Register<IEnumTableCreator, EnumTableCreator>(lifestyle);

            container.Register<IDataTablesService, DataTablesService>(lifestyle);
        }
    }
}