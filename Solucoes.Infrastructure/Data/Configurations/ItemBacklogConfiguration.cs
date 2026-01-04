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
    public class ItemBacklogConfiguration : IEntityTypeConfiguration<ItemBacklog>
    {
        public void Configure(EntityTypeBuilder<ItemBacklog> builder)
        {
            builder.ToTable("ItemBacklogs");

            builder.HasKey(ib => ib.Id);

            builder.Property(ib => ib.Id)
                .HasColumnType("int")
                .IsRequired()
                .ValueGeneratedOnAdd();

            builder.HasOne(ib => ib.Projeto)
                .WithMany(p => p.Backlog)
                .HasForeignKey(ib => ib.ProjetoId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(ib => ib.Sprint)
                .WithMany(s => s.Itens)
                .HasForeignKey(ib => ib.SprintId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Property(ib => ib.Titulo)
                .HasColumnType("nvarchar(100)")
                .IsRequired();

            builder.Property(ib => ib.Descricao)
                .HasColumnType("nvarchar(max)")
                .IsRequired();

            builder.HasOne(ib => ib.ItemBacklogTipo)
                .WithMany()
                .HasForeignKey(ib => ib.ItemBacklogTipoId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(ib => ib.ItemBacklogStatus)
                .WithMany()
                .HasForeignKey(ib => ib.ItemBacklogStatusId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(ib => ib.CriadoPorProjetoMembro)
                .WithMany()
                .HasForeignKey(ib => ib.CriadoPorProjetoMembroId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(ib => ib.ResponsavelProjetoMembro)
                .WithMany(pm => pm.Tarefas)
                .HasForeignKey(ib => ib.ResponsavelProjetoMembroId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Property(ib => ib.CriadoEm)
                .HasColumnType("datetime2")
                .HasDefaultValueSql("SYSUTCDATETIME()")
                .IsRequired();

            builder.HasMany(ib => ib.Comentarios)
                .WithOne(ibc => ibc.ItemBacklog)
                .HasForeignKey(ibc => ibc.ItemBacklogId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(ib => ib.Anexos)
                .WithOne(iba => iba.ItemBacklog)
                .HasForeignKey(iba => iba.ItemBacklogId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(ib => ib.Historico)
                .WithOne(ibh => ibh.ItemBacklog)
                .HasForeignKey(ibh => ibh.ItemBacklogId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
