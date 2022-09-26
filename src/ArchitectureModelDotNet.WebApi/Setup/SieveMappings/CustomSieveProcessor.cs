using Academic.Infra.CrossCutting.IoC;
using Microsoft.Extensions.Options;
using Sieve.Models;
using Sieve.Services;

namespace ArchitectureModelDotNet.WebApi.Setup.SieveMappings
{
    public class CustomSieveProcessor : SieveProcessor
    {
        public CustomSieveProcessor(IOptions<SieveOptions> options)
            : base(options)
        {
        }

        protected override SievePropertyMapper MapProperties(SievePropertyMapper mapper)
        {
            return mapper
                .ApplyConfiguration<SieveConfigurationAcademic>();
        }
    }
}
