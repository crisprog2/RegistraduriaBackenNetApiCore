﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RegistraduriaBackenNetApiCore.DataBaseContext;

#nullable disable

namespace RegistraduriaBackenNetApiCore.Migrations
{
    [DbContext(typeof(DBContext))]
    [Migration("20221111040753_registraduriadb")]
    partial class registraduriadb
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Registraduria_Backend_Api.Models.Departamento", b =>
                {
                    b.Property<string>("codDepartamento")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("departamentoNombre")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("codDepartamento");

                    b.ToTable("Departamentos");
                });
#pragma warning restore 612, 618
        }
    }
}
