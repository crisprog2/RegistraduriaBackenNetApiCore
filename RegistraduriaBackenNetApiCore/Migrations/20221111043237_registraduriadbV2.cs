using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RegistraduriaBackenNetApiCore.Migrations
{
    /// <inheritdoc />
    public partial class registraduriadbV2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Ciudades",
                columns: table => new
                {
                    codCiudad = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ciudad = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    codDepartamento = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ciudades", x => x.codCiudad);
                    table.ForeignKey(
                        name: "FK_Ciudades_Departamentos_codDepartamento",
                        column: x => x.codDepartamento,
                        principalTable: "Departamentos",
                        principalColumn: "codDepartamento");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Ciudades_codDepartamento",
                table: "Ciudades",
                column: "codDepartamento");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ciudades");
        }
    }
}
