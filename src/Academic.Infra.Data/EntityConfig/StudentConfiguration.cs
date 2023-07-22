using Academic.Domain.Entities.Students;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Academic.Infra.Data.EntityConfig
{
    public class StudentConfiguration : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            ArgumentNullException.ThrowIfNull(builder);

            builder.Property(x => x.Name)
                .HasMaxLength(100);

            builder.Property(x => x.Email)
                .HasMaxLength(255);
        }
    }
}
