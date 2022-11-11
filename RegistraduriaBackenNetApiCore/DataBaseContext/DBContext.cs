using Microsoft.EntityFrameworkCore;
using RegistraduriaBackenNetApiCore.Models.Entities;

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
        public DbSet<Mesa> Mesas { get; set; }
        public DbSet<Persona> Personas { get; set; }
        public DbSet<Registro> Registros { get; set; }


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

            modelBuilder.Entity<Mesa>()
                       .HasOne(p => p.lugarVoto)
                       .WithMany(c => c.Mesas)
                       .HasForeignKey(p => p.codLugarVoto);

            modelBuilder.Entity<Persona>()
                       .HasOne(p => p.mesa)
                       .WithMany(c => c.Personas)
                       .HasForeignKey(p => p.codMesa);

            modelBuilder.Entity<Registro>()
                       .HasOne(p => p.persona)
                       .WithMany(c => c.Registros)
                       .HasForeignKey(p => p.cedula);
        }

        public DbSet<Mesa> Mesa { get; set; }

        public DbSet<Persona> Persona { get; set; }

        public DbSet<Registro> Registro { get; set; }

    }
}
