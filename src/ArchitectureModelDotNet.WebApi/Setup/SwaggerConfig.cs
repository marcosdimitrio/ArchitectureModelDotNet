using Swashbuckle.AspNetCore.SwaggerGen;

namespace ArchitectureModelDotNet.WebApi.Setup
{
    public static class SwaggerConfig
    {
        public static Action<SwaggerGenOptions> Configure => (setupAction) =>
        {
            setupAction.CustomSchemaIds(schemaIdSelector =>
            {
                var suffix = "ViewDto";
                if (schemaIdSelector.Name.EndsWith(suffix))
                {
                    return schemaIdSelector.Name.Substring(0, schemaIdSelector.Name.Length - suffix.Length);
                }

                return schemaIdSelector.Name;
            });
        };
    }
}
