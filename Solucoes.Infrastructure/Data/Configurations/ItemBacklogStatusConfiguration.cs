using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Solucoes.Domain.Entities.Projetos.ItemBacklogs;

namespace Solucoes.Infrastructure.Data.Configurations
{
    public class ItemBacklogStatusConfiguration : IEntityTypeConfiguration<ItemBacklogStatus>
    {
        public void Configure(EntityTypeBuilder<ItemBacklogStatus> builder)
        {
            builder.ToTable("ItemBacklogStatus");

            builder.HasKey(ibs => ibs.Id);

            builder.Property(ibs => ibs.Id)
                .HasColumnType("int")
                .IsRequired()
                .ValueGeneratedOnAdd();

            builder.Property(ibs => ibs.Codigo)
                .HasColumnType("nvarchar(50)")
                .IsRequired();

            builder.Property(ibs => ibs.Nome)
                .HasColumnType("nvarchar(100)")
                .IsRequired();

            builder.Property(ibs => ibs.Ativo)
                .HasColumnType("bit")
                .HasDefaultValueSql("1")
                .IsRequired();

            builder.HasData(new List<ItemBacklogStatus>
            {
                new ItemBacklogStatus(1, "BACKLOG", "Backlog"),
                new ItemBacklogStatus(2, "EM_ANDAMENTO", "Em Andamento"),
                new ItemBacklogStatus(3, "EM_REVISAO", "Em revisão"),
                new ItemBacklogStatus(4, "CONCLUIDO", "Concluído"),
                new ItemBacklogStatus(5, "CANCELADO", "Cancelado"),
            });
        }
    }
}
