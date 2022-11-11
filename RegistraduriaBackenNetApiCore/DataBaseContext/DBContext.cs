using Microsoft.EntityFrameworkCore;
using Registraduria_Backend_Api.Models;

namespace RegistraduriaBackenNetApiCore.DataBaseContext
{
    public class DBContext : DbContext
    {
        public DBContext(DbContextOptions<DBContext> options) : base(options)
        {

        }

        public DbSet<Departamento> Departamentos { get; set; }
        public DbSet<Ciudad> Ciudades { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Ciudad>()
                       .HasOne(p => p.departamento)
                       .WithMany(c => c.Ciudades)
                       .HasForeignKey(p => p.codDepartamento);
        }

    }
}
