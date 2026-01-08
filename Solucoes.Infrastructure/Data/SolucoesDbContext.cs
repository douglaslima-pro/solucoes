using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Solucoes.Domain.Entities.Projetos;
using Solucoes.Domain.Entities.Projetos.ItemBacklogs;
using Solucoes.Domain.Entities.Projetos.Sprints;
using Solucoes.Infrastructure.Data.Configurations;
using Solucoes.Infrastructure.Data.Identity.Entities;

namespace Solucoes.Infrastructure.Data
{
    public class SolucoesDbContext : IdentityDbContext<Usuario, IdentityRole<int>, int>
    {
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Projeto> Projetos { get; set; }
        public DbSet<ProjetoMembro> ProjetoMembros { get; set; }
        public DbSet<ProjetoConvite> ProjetoConvites { get; set; }
        public DbSet<ProjetoPapel> ProjetoPapeis { get; set; }
        public DbSet<Sprint> Sprints { get; set; }
        public DbSet<SprintBacklog> SprintBacklogs { get; set; }
        public DbSet<ItemBacklog> ItemBacklogs { get; set; }
        public DbSet<ItemBacklogAnexo> ItemBacklogAnexos { get; set; }
        public DbSet<ItemBacklogComentario> ItemBacklogComentarios { get; set; }
        public DbSet<ItemBacklogHistorico> ItemBacklogHistoricos { get; set; }
        public DbSet<ItemBacklogStatus> ItemBacklogStatus { get; set; }
        public DbSet<ItemBacklogTipo> ItemBacklogTipos { get; set; }

        public SolucoesDbContext(DbContextOptions<SolucoesDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new UsuarioConfiguration());
            builder.ApplyConfiguration(new ProjetoConfiguration());
            builder.ApplyConfiguration(new ProjetoMembroConfiguration());
            builder.ApplyConfiguration(new ProjetoConviteConfiguration());
            builder.ApplyConfiguration(new ProjetoPapelConfiguration());
            builder.ApplyConfiguration(new SprintConfiguration());
            builder.ApplyConfiguration(new SprintBacklogConfiguration());
            builder.ApplyConfiguration(new ItemBacklogConfiguration());
            builder.ApplyConfiguration(new ItemBacklogAnexoConfiguration());
            builder.ApplyConfiguration(new ItemBacklogComentarioConfiguration());
            builder.ApplyConfiguration(new ItemBacklogHistoricoConfiguration());
            builder.ApplyConfiguration(new ItemBacklogStatusConfiguration());
            builder.ApplyConfiguration(new ItemBacklogTipoConfiguration());

            base.OnModelCreating(builder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.EnableSensitiveDataLogging();

            base.OnConfiguring(optionsBuilder);
        }
    }
}
