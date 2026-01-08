using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Solucoes.Domain.Entities.Projetos;
using Solucoes.Infrastructure.Data.Identity.Entities;

namespace Solucoes.Infrastructure.Data.Configurations
{
    public class ProjetoConviteConfiguration : IEntityTypeConfiguration<ProjetoConvite>
    {
        public void Configure(EntityTypeBuilder<ProjetoConvite> builder)
        {
            builder.ToTable("ProjetoConvites");

            builder.HasKey(pc => pc.Id);

            builder.Property(pc => pc.Id)
                .HasColumnType("int")
                .IsRequired()
                .ValueGeneratedOnAdd();

            builder.HasOne(pc => pc.Projeto)
                .WithMany(p => p.Convites)
                .HasForeignKey(pc => pc.ProjetoId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne<Usuario>()
                .WithMany()
                .HasForeignKey(pc => pc.UsuarioId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(pc => pc.ProjetoPapel)
                .WithMany()
                .HasForeignKey(pc => pc.ProjetoPapelId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Property(pc => pc.TokenHash)
                .HasColumnType("varbinary(32)")
                .IsRequired();

            builder.HasIndex(pc => pc.TokenHash)
                .IsUnique();

            builder.Property(pc => pc.ExpiraEm)
                .HasColumnType("datetime2")
                .IsRequired();

            builder.Property(pc => pc.Aceito)
                .HasColumnType("bit")
                .HasDefaultValueSql("0")
                .IsRequired();

            builder.HasOne(pc => pc.CriadoPorProjetoMembro)
                .WithMany(pm => pm.ProjetoConvites)
                .HasForeignKey(pc => pc.CriadoPorProjetoMembroId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Property(pc => pc.CriadoEm)
                .HasColumnType("datetime2")
                .HasDefaultValueSql("SYSUTCDATETIME()")
                .IsRequired();
        }
    }
}
