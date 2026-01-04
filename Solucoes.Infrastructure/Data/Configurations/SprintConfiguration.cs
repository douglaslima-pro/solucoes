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
    public class SprintConfiguration : IEntityTypeConfiguration<Sprint>
    {
        public void Configure(EntityTypeBuilder<Sprint> builder)
        {
            builder.ToTable("Sprints");

            builder.HasKey(s => s.Id);

            builder.Property(s => s.Id)
                .HasColumnType("int")
                .IsRequired()
                .ValueGeneratedOnAdd();

            builder.HasOne(s => s.Projeto)
                .WithMany(p => p.Sprints)
                .HasForeignKey(s => s.ProjetoId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Property(s => s.Nome)
                .HasColumnType("nvarchar(100)")
                .IsRequired();

            builder.Property(s => s.DataInicio)
                .HasColumnType("datetime2")
                .IsRequired();

            builder.Property(s => s.DataFim)
                .HasColumnType("datetime2")
                .IsRequired();

            builder.Property(s => s.Encerrada)
                .HasColumnType("bit")
                .HasDefaultValueSql("0")
                .IsRequired();

            builder.HasOne(s => s.CriadoPorProjetoMembro)
                .WithMany()
                .HasForeignKey(s => s.CriadoPorProjetoMembroId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Property(s => s.CriadoEm)
                .HasColumnType("datetime2")
                .HasDefaultValueSql("SYSUTCDATETIME()")
                .IsRequired();

            builder.HasMany(s => s.Itens)
                .WithOne(i => i.Sprint)
                .HasForeignKey(i => i.SprintId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
