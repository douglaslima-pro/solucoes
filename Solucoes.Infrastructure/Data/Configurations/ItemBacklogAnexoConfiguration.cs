using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Solucoes.Domain.Entities.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solucoes.Infrastructure.Data.Configurations
{
    public class ItemBacklogAnexoConfiguration : IEntityTypeConfiguration<ItemBacklogAnexo>
    {
        public void Configure(EntityTypeBuilder<ItemBacklogAnexo> builder)
        {
            builder.ToTable("ItemBacklogAnexos");

            builder.HasKey(iba => iba.Id);

            builder.Property(iba => iba.Id)
                .HasColumnType("int")
                .IsRequired()
                .ValueGeneratedOnAdd();

            builder.HasOne(ibc => ibc.ItemBacklog)
                .WithMany(ib => ib.Anexos)
                .HasForeignKey(ibc => ibc.ItemBacklogId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Property(iba => iba.Nome)
                .HasColumnType("nvarchar(max)")
                .IsRequired();

            builder.Property(iba => iba.Url)
                .HasColumnType("nvarchar(max)")
                .IsRequired();

            builder.HasOne(iba => iba.CriadoPorProjetoMembro)
                .WithMany()
                .HasForeignKey(iba => iba.CriadoPorProjetoMembroId);

            builder.Property(iba => iba.CriadoEm)
                .HasColumnType("datetime2")
                .HasDefaultValueSql("SYSUTCDATETIME()")
                .IsRequired();
        }
    }
}
