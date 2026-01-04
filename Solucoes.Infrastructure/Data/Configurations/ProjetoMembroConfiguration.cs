using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Solucoes.Domain.Entities.Tables;
using Solucoes.Infrastructure.Data.Identity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solucoes.Infrastructure.Data.Configurations
{
    public class ProjetoMembroConfiguration : IEntityTypeConfiguration<ProjetoMembro>
    {
        public void Configure(EntityTypeBuilder<ProjetoMembro> builder)
        {
            builder.ToTable("ProjetoMembros");

            builder.HasKey(pm => pm.Id);

            builder.Property(pm => pm.Id)
                .HasColumnType("int")
                .IsRequired()
                .ValueGeneratedOnAdd();

            builder.HasOne(pm => pm.Projeto)
                .WithMany(p => p.Membros)
                .HasForeignKey(pm => pm.ProjetoId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne<Usuario>()
                .WithMany(u => u.Projetos)
                .HasForeignKey(pm => pm.UsuarioId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(pm => pm.ProjetoPapel)
                .WithMany()
                .HasForeignKey(pm => pm.ProjetoPapelId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Property(pm => pm.EntrouEm)
                .HasColumnType("datetime2")
                .HasDefaultValueSql("SYSUTCDATETIME()")
                .IsRequired();

            builder.Property(pm => pm.Ativo)
                .HasColumnType("bit")
                .HasDefaultValueSql("1")
                .IsRequired();

            builder.HasMany(pm => pm.Tarefas)
                .WithOne(ib => ib.ResponsavelProjetoMembro)
                .HasForeignKey(ib => ib.ResponsavelProjetoMembroId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasMany(pm => pm.ProjetoConvites)
                .WithOne(pc => pc.CriadoPorProjetoMembro)
                .HasForeignKey(pc => pc.CriadoPorProjetoMembroId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
