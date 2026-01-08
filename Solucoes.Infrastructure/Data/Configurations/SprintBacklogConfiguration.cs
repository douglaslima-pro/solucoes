using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Solucoes.Domain.Entities.Projetos.Sprints;

namespace Solucoes.Infrastructure.Data.Configurations
{
    public class SprintBacklogConfiguration : IEntityTypeConfiguration<SprintBacklog>
    {
        public void Configure(EntityTypeBuilder<SprintBacklog> builder)
        {
            builder.ToTable("SprintBacklogs");

            builder.HasKey(sb => sb.Id);

            builder.Property(sb => sb.Id)
                .HasColumnType("int")
                .IsRequired()
                .ValueGeneratedOnAdd();

            builder.HasOne(sb => sb.Sprint)
                .WithMany(s => s.Backlog)
                .HasForeignKey(sb => sb.SprintId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(sb => sb.ItemBacklog)
                .WithMany(ib => ib.Sprints)
                .HasForeignKey(sb => sb.ItemBacklogId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
