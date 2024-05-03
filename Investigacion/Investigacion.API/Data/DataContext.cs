using Microsoft.EntityFrameworkCore;
using Investigacion.Shared.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Investigacion.Shared.Entities;

namespace Investigacion.API.Data
{
    public class DataContext : IdentityDbContext<User>
    {
        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {
        }

        public DbSet<Investigador> Investigadores { get; set; }
        public DbSet<Proyecto> Proyectos { get; set; }
        public DbSet<RecursoEspecializado> RecursosEspecializados { get; set; }
        public DbSet<ActividadInvestigacion> ActividadesInvestigacion { get; set; }
        public DbSet<Publicacion> Publicaciones { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ParticipacionInvestigadoresProyectos>()
                .HasKey(ip => new { ip.ID_Investigador, ip.ID_Proyecto });

            modelBuilder.Entity<AsignacionRecursosEspecializadosActividadesInvestigacion>()
                .HasKey(ar => new { ar.ID_Actividad, ar.ID_RecursoEspecializado });

            modelBuilder.Entity<Publicacion>()
                .HasKey(p => p.Id);

            modelBuilder.Entity<Publicacion>()
                .HasOne(p => p.Proyecto)
                .WithMany(pr => pr.Publicaciones)
                .HasForeignKey(p => p.ID_Proyecto);

            modelBuilder.Entity<ActividadInvestigacion>()
               .HasKey(ai => ai.Id);

            modelBuilder.Entity<Investigador>()
                .HasKey(i => i.Id);

            modelBuilder.Entity<Proyecto>()
               .HasKey(p => p.Id);

            modelBuilder.Entity<RecursoEspecializado>()
               .HasKey(r => r.Id);

            base.OnModelCreating(modelBuilder);
        }
    }
}
