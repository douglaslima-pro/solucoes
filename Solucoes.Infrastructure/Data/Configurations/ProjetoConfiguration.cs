using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Solucoes.Domain.Entities.Projetos;
using Solucoes.Infrastructure.Data.Identity.Entities;

namespace Solucoes.Infrastructure.Data.Configurations
{
    public class ProjetoConfiguration : IEntityTypeConfiguration<Projeto>
    {
        public void Configure(EntityTypeBuilder<Projeto> builder)
        {
            builder.ToTable("Projetos");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id)
                .HasColumnType("int")
                .IsRequired()
                .ValueGeneratedOnAdd();

            builder.Property(p => p.Nome)
                .HasColumnType("nvarchar(100)")
                .IsRequired();

            builder.Property(p => p.Descricao)
                .HasColumnType("nvarchar(max)")
                .IsRequired(false);

            builder.HasOne<Usuario>()
                .WithMany()
                .HasForeignKey(p => p.CriadoPorUsuarioId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Property(p => p.CriadoEm)
                .HasColumnType("datetime2")
                .HasDefaultValueSql("SYSUTCDATETIME()")
                .IsRequired();

            builder.Property(p => p.Ativo)
                .HasColumnType("bit")
                .HasDefaultValueSql("1")
                .IsRequired();

            builder.HasMany(p => p.Membros)
                .WithOne(p => p.Projeto)
                .HasForeignKey(p => p.ProjetoId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(p => p.Backlog)
                .WithOne(b => b.Projeto)
                .HasForeignKey(b => b.ProjetoId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(p => p.Sprints)
                .WithOne(s => s.Projeto)
                .HasForeignKey(s => s.ProjetoId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(p => p.Convites)
                .WithOne(c => c.Projeto)
                .HasForeignKey(c => c.ProjetoId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
