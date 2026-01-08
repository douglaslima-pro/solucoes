using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Solucoes.Domain.Entities.Projetos.ItemBacklogs;

namespace Solucoes.Infrastructure.Data.Configurations
{
    public class ItemBacklogTipoConfiguration : IEntityTypeConfiguration<ItemBacklogTipo>
    {
        public void Configure(EntityTypeBuilder<ItemBacklogTipo> builder)
        {
            builder.ToTable("ItemBacklogTipos");

            builder.HasKey(ibt => ibt.Id);

            builder.Property(ibt => ibt.Id)
                .HasColumnType("int")
                .IsRequired()
                .ValueGeneratedOnAdd();

            builder.Property(ibt => ibt.Codigo)
                .HasColumnType("nvarchar(50)")
                .IsRequired();

            builder.Property(ibt => ibt.Nome)
                .HasColumnType("nvarchar(100)")
                .IsRequired();

            builder.Property(ibt => ibt.Ativo)
                .HasColumnType("bit")
                .HasDefaultValueSql("1")
                .IsRequired();

            builder.HasData(new List<ItemBacklogTipo>
            {
                new ItemBacklogTipo(1, "HISTORIA_USUARIO", "História de Usuário"),
                new ItemBacklogTipo(2, "TAREFA", "Tarefa"),
                new ItemBacklogTipo(3, "BUG", "Bug"),
            });
        }
    }
}
