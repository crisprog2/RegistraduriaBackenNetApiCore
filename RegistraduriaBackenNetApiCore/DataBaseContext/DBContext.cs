using Microsoft.EntityFrameworkCore;
using Registraduria_Backend_Api.Models;
using RegistraduriaBackenNetApiCore.Models;

namespace RegistraduriaBackenNetApiCore.DataBaseContext
{
    public class DBContext : DbContext
    {
        public DBContext(DbContextOptions<DBContext> options) : base(options)
        {

        }

        public DbSet<Departamento> Departamentos { get; set; }
        public DbSet<Ciudad> Ciudades { get; set; }
        public DbSet<LugarVoto> LugarVotaciones { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Ciudad>()
                       .HasOne(p => p.departamento)
                       .WithMany(c => c.Ciudades)
                       .HasForeignKey(p => p.codDepartamento);

            modelBuilder.Entity<LugarVoto>()
                       .HasOne(p => p.ciudad)
                       .WithMany(c => c.Lugares)
                       .HasForeignKey(p => p.codCiudad);
        }

    }
}
