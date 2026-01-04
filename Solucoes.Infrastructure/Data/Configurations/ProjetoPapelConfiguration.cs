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
    public class ProjetoPapelConfiguration : IEntityTypeConfiguration<ProjetoPapel>
    {
        public void Configure(EntityTypeBuilder<ProjetoPapel> builder)
        {
            builder.ToTable("ProjetoPapeis");

            builder.HasKey(pp => pp.Id);

            builder.Property(pp => pp.Id)
                .HasColumnType("int")
                .IsRequired()
                .ValueGeneratedOnAdd();

            builder.Property(pp => pp.Codigo)
                .HasColumnType("nvarchar(50)")
                .IsRequired();

            builder.Property(pp => pp.Nome)
                .HasColumnType("nvarchar(100)")
                .IsRequired();

            builder.Property(pp => pp.Ativo)
                .HasColumnType("bit")
                .HasDefaultValueSql("1")
                .IsRequired();

            builder.HasData(new List<ProjetoPapel>
            {
                new ProjetoPapel(1, "PRODUCT_OWNER", "Product Owner"),
                new ProjetoPapel(2, "SCRUM_MASTER", "Scrum Master"),
                new ProjetoPapel(3, "DESENVOLVEDOR", "Desenvolvedor"),
                new ProjetoPapel(4, "STAKEHOLDER", "Stakeholder"),
            });
        }
    }
}
