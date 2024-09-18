using Babel.Models;
using Microsoft.EntityFrameworkCore;

namespace Babel.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext (DbContextOptions<ApplicationDbContext> options) : base(options) {}

        // Add models
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserRol> UsersRoles { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configuración de la entidad UserRol
            modelBuilder.Entity<UserRol>()
                .HasKey(ur => new { ur.UsuarioId, ur.RoleId });

            modelBuilder.Entity<UserRol>()
                .HasOne(ur => ur.User)
                .WithMany(u => u.UserRoles)
                .HasForeignKey(ur => ur.UsuarioId);

            modelBuilder.Entity<UserRol>()
                .HasOne(ur => ur.Role)
                .WithMany(r => r.UserRoles)
                .HasForeignKey(ur => ur.RoleId);
        }


    }
}
