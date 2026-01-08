using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Solucoes.Domain.Entities.Projetos.ItemBacklogs;

namespace Solucoes.Infrastructure.Data.Configurations
{
    public class ItemBacklogComentarioConfiguration : IEntityTypeConfiguration<ItemBacklogComentario>
    {
        public void Configure(EntityTypeBuilder<ItemBacklogComentario> builder)
        {
            builder.ToTable("ItemBacklogComentarios");

            builder.HasKey(ibc => ibc.Id);

            builder.Property(ibc => ibc.Id)
                .HasColumnType("int")
                .IsRequired()
                .ValueGeneratedOnAdd();

            builder.HasOne(ibc => ibc.ItemBacklog)
                .WithMany(ib => ib.Comentarios)
                .HasForeignKey(ibc => ibc.ItemBacklogId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(ibc => ibc.CriadoPorProjetoMembro)
                .WithMany()
                .HasForeignKey(ibc => ibc.CriadoPorProjetoMembroId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Property(ibc => ibc.Texto)
                .HasColumnType("nvarchar(max)")
                .IsRequired();

            builder.Property(ibc => ibc.CriadoEm)
                .HasColumnType("datetime2")
                .HasDefaultValueSql("SYSUTCDATETIME()")
                .IsRequired();
        }
    }
}
