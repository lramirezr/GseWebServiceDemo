using System.Data.Entity;

namespace Gse.WebService.Data
{
    public class GseDbContext : DbContext
    {
        public GseDbContext()
            : base("DbUserConnection")
        {
        }

        public static GseDbContext Create()
        {
            return new GseDbContext();
        }

        public System.Data.Entity.DbSet<Gse.WebService.Data.Usuario> Usuarios { get; set; }
        public System.Data.Entity.DbSet<Gse.WebService.Data.Empresa> Empresas { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Empresa>()
                .HasOptional(e => e.Usuario)
                .WithMany(u => u.Empresas)
                .HasForeignKey(e => e.UsuarioId);
        }
    }
}
