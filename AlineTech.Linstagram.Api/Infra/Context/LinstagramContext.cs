using AlineTech.Linstagram.Api.Infra.Mappings;
using AlineTech.Linstagram.Api.Models.Entitys;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore;

namespace AlineTech.Linstagram.Api.Infra.Context
{
    public class LinstagramContext : DbContext
    {
        public LinstagramContext(DbContextOptions<LinstagramContext> options) : base(options) { }

        public DbSet<Usuario>? Usuarios { get; set; }
        public DbSet<Perfil>? Perfils { get; set; }
        public DbSet<Publicacao>? Publicacoes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
                relationship.DeleteBehavior = DeleteBehavior.ClientSetNull;

            base.OnModelCreating(modelBuilder);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var entry in ChangeTracker.Entries().Where(entry =>
            entry.Entity.GetType().GetProperty("DataCadastro") != null &&
            entry.Entity.GetType().GetProperty("DataAtualizacao") != null))
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Property("DataCadastro").CurrentValue = DateTime.Now;
                    entry.Property("DataAtualizacao").CurrentValue = DateTime.Now;
                }

                if (entry.State == EntityState.Modified)
                {
                    entry.Property("DataCadastro").IsModified = false;
                    entry.Property("DataAtualizacao").CurrentValue = DateTime.Now;
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
