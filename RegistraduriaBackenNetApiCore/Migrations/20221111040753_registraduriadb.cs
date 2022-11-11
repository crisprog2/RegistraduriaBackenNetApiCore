using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RegistraduriaBackenNetApiCore.Migrations
{
    /// <inheritdoc />
    public partial class registraduriadb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Departamentos",
                columns: table => new
                {
                    codDepartamento = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    departamentoNombre = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departamentos", x => x.codDepartamento);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Departamentos");
        }
    }
}
