using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Solucoes.Domain.Entities.Projetos.ItemBacklogs;

namespace Solucoes.Infrastructure.Data.Configurations
{
    public class ItemBacklogHistoricoConfiguration : IEntityTypeConfiguration<ItemBacklogHistorico>
    {
        public void Configure(EntityTypeBuilder<ItemBacklogHistorico> builder)
        {
            builder.ToTable("ItemBacklogHistoricos");

            builder.HasKey(ibh => ibh.Id);

            builder.Property(ibh => ibh.Id)
                .HasColumnType("int")
                .IsRequired()
                .ValueGeneratedOnAdd();

            builder.HasOne(ibh => ibh.ItemBacklog)
                .WithMany(ib => ib.Historico)
                .HasForeignKey(ibh => ibh.ItemBacklogId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(ibh => ibh.ItemBacklogStatusAnterior)
                .WithMany()
                .HasForeignKey(ibh => ibh.ItemBacklogStatusAnteriorId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(ibh => ibh.ItemBacklogStatusAtual)
                .WithMany()
                .HasForeignKey(ibh => ibh.ItemBacklogStatusAtualId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(ibh => ibh.AlteradoPorProjetoMembro)
                .WithMany()
                .HasForeignKey(ibh => ibh.AlteradoPorProjetoMembroId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Property(ibh => ibh.AlteradoEm)
                .HasColumnType("datetime2")
                .HasDefaultValueSql("SYSUTCDATETIME()")
                .IsRequired();
        }
    }
}
