﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RegistraduriaBackenNetApiCore.DataBaseContext;

#nullable disable

namespace RegistraduriaBackenNetApiCore.Migrations
{
    [DbContext(typeof(DBContext))]
    partial class DBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("RegistraduriaBackenNetApiCore.Models.Entities.Ciudad", b =>
                {
                    b.Property<string>("codCiudad")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ciudad")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("codDepartamento")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("codCiudad");

                    b.HasIndex("codDepartamento");

                    b.ToTable("Ciudades");
                });

            modelBuilder.Entity("RegistraduriaBackenNetApiCore.Models.Entities.Departamento", b =>
                {
                    b.Property<string>("codDepartamento")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("departamentoNombre")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("codDepartamento");

                    b.ToTable("Departamentos");
                });

            modelBuilder.Entity("RegistraduriaBackenNetApiCore.Models.Entities.LugarVoto", b =>
                {
                    b.Property<string>("codLugarVoto")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("codCiudad")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("direccionLugarVoto")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("nombreLugarVoto")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("codLugarVoto");

                    b.HasIndex("codCiudad");

                    b.ToTable("LugarVotaciones");
                });

            modelBuilder.Entity("RegistraduriaBackenNetApiCore.Models.Entities.Mesa", b =>
                {
                    b.Property<int>("codMesa")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("codMesa"));

                    b.Property<string>("codLugarVoto")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("mesa")
                        .HasColumnType("int");

                    b.HasKey("codMesa");

                    b.HasIndex("codLugarVoto");

                    b.ToTable("Mesas");
                });

            modelBuilder.Entity("RegistraduriaBackenNetApiCore.Models.Entities.Persona", b =>
                {
                    b.Property<int>("cedula")
                        .HasColumnType("int");

                    b.Property<int>("codMesa")
                        .HasColumnType("int");

                    b.Property<int>("edad")
                        .HasColumnType("int");

                    b.Property<string>("genero")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("jurado")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("primerApellido")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("primerNombre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("segundoApellido")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("segundoNombre")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("cedula");

                    b.HasIndex("codMesa");

                    b.ToTable("Personas");
                });

            modelBuilder.Entity("RegistraduriaBackenNetApiCore.Models.Entities.Registro", b =>
                {
                    b.Property<int>("codRegistro")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("codRegistro"));

                    b.Property<int>("cedula")
                        .HasColumnType("int");

                    b.Property<int>("registro")
                        .HasColumnType("int");

                    b.HasKey("codRegistro");

                    b.HasIndex("cedula");

                    b.ToTable("Registros");
                });

            modelBuilder.Entity("RegistraduriaBackenNetApiCore.Models.Entities.Ciudad", b =>
                {
                    b.HasOne("RegistraduriaBackenNetApiCore.Models.Entities.Departamento", "departamento")
                        .WithMany("Ciudades")
                        .HasForeignKey("codDepartamento");

                    b.Navigation("departamento");
                });

            modelBuilder.Entity("RegistraduriaBackenNetApiCore.Models.Entities.LugarVoto", b =>
                {
                    b.HasOne("RegistraduriaBackenNetApiCore.Models.Entities.Ciudad", "ciudad")
                        .WithMany("Lugares")
                        .HasForeignKey("codCiudad");

                    b.Navigation("ciudad");
                });

            modelBuilder.Entity("RegistraduriaBackenNetApiCore.Models.Entities.Mesa", b =>
                {
                    b.HasOne("RegistraduriaBackenNetApiCore.Models.Entities.LugarVoto", "lugarVoto")
                        .WithMany("Mesas")
                        .HasForeignKey("codLugarVoto");

                    b.Navigation("lugarVoto");
                });

            modelBuilder.Entity("RegistraduriaBackenNetApiCore.Models.Entities.Persona", b =>
                {
                    b.HasOne("RegistraduriaBackenNetApiCore.Models.Entities.Mesa", "mesa")
                        .WithMany("Personas")
                        .HasForeignKey("codMesa")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("mesa");
                });

            modelBuilder.Entity("RegistraduriaBackenNetApiCore.Models.Entities.Registro", b =>
                {
                    b.HasOne("RegistraduriaBackenNetApiCore.Models.Entities.Persona", "persona")
                        .WithMany("Registros")
                        .HasForeignKey("cedula")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("persona");
                });

            modelBuilder.Entity("RegistraduriaBackenNetApiCore.Models.Entities.Ciudad", b =>
                {
                    b.Navigation("Lugares");
                });

            modelBuilder.Entity("RegistraduriaBackenNetApiCore.Models.Entities.Departamento", b =>
                {
                    b.Navigation("Ciudades");
                });

            modelBuilder.Entity("RegistraduriaBackenNetApiCore.Models.Entities.LugarVoto", b =>
                {
                    b.Navigation("Mesas");
                });

            modelBuilder.Entity("RegistraduriaBackenNetApiCore.Models.Entities.Mesa", b =>
                {
                    b.Navigation("Personas");
                });

            modelBuilder.Entity("RegistraduriaBackenNetApiCore.Models.Entities.Persona", b =>
                {
                    b.Navigation("Registros");
                });
#pragma warning restore 612, 618
        }
    }
}
