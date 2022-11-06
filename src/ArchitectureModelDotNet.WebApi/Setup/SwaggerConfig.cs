using Swashbuckle.AspNetCore.SwaggerGen;

namespace ArchitectureModelDotNet.WebApi.Setup
{
    public static class SwaggerConfig
    {
        public static Action<SwaggerGenOptions> Configure => (setupAction) =>
        {
            setupAction.CustomSchemaIds(schemaIdSelector =>
            {
                var name = GetName(schemaIdSelector);

                var suffix = "ViewDto";
                if (name.EndsWith(suffix))
                {
                    return name.Substring(0, name.Length - suffix.Length);
                }

                return name;
            });
        };

        private static string GetName(Type schemaIdSelector)
        {
            if (schemaIdSelector.IsGenericType)
            {
                var name = schemaIdSelector.GetGenericTypeDefinition().Name;

                return name.Remove(name.IndexOf('`'));
            }

            return schemaIdSelector.Name;
        }
    }
}
