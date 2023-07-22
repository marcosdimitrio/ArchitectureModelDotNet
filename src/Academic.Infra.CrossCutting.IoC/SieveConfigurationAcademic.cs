using Academic.Domain.Entities.Students;
using Sieve.Services;

namespace Academic.Infra.CrossCutting.IoC
{
    public class SieveConfigurationAcademic : ISieveConfiguration
    {
        public void Configure(SievePropertyMapper mapper)
        {
            ArgumentNullException.ThrowIfNull(mapper);

            mapper.Property<Student>(x => x.Id)
                .CanSort();

            mapper.Property<Student>(x => x.Name)
                .CanFilter()
                .CanSort();

            mapper.Property<Student>(x => x.Email)
                 .CanFilter()
                 .CanSort();

            mapper.Property<Student>(x => x.RegisteredOn)
               .CanFilter()
               .CanSort();
        }
    }
}