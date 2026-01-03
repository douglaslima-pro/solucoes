using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Solucoes.Infrastructure.Data.Configurations;
using Solucoes.Infrastructure.Data.Identity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solucoes.Infrastructure.Data
{
    public class SolucoesDbContext : IdentityDbContext<Usuario, IdentityRole<int>, int>
    {
        public DbSet<Usuario> Usuarios { get; set; }

        public SolucoesDbContext(DbContextOptions<SolucoesDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new UsuarioConfiguration());

            base.OnModelCreating(builder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.EnableSensitiveDataLogging();

            base.OnConfiguring(optionsBuilder);
        }
    }
}
