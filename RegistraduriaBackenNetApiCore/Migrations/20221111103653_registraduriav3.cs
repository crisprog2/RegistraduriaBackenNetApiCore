using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RegistraduriaBackenNetApiCore.Migrations
{
    /// <inheritdoc />
    public partial class registraduriav3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LugarVotaciones",
                columns: table => new
                {
                    codLugarVoto = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    nombreLugarVoto = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    direccionLugarVoto = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    codCiudad = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LugarVotaciones", x => x.codLugarVoto);
                    table.ForeignKey(
                        name: "FK_LugarVotaciones_Ciudades_codCiudad",
                        column: x => x.codCiudad,
                        principalTable: "Ciudades",
                        principalColumn: "codCiudad");
                });

            migrationBuilder.CreateIndex(
                name: "IX_LugarVotaciones_codCiudad",
                table: "LugarVotaciones",
                column: "codCiudad");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LugarVotaciones");
        }
    }
}
