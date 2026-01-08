using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Solucoes.Infrastructure.Data.Identity.Entities;

namespace Solucoes.Infrastructure.Data.Configurations
{
    public class UsuarioConfiguration : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable("AspNetUsers");

            builder.Property(u => u.PrimeiroNome)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(u => u.Sobrenome)
                .HasMaxLength(100)
                .IsRequired(false);

            builder.Property(u => u.IsActive)
                .HasDefaultValue(true)
                .IsRequired();

            builder.HasMany(x => x.Projetos)
                .WithOne();
        }
    }
}
