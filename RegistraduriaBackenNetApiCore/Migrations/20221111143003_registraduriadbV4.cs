using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RegistraduriaBackenNetApiCore.Migrations
{
    /// <inheritdoc />
    public partial class registraduriadbV4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Mesas",
                columns: table => new
                {
                    codMesa = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    mesa = table.Column<int>(type: "int", nullable: false),
                    codLugarVoto = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mesas", x => x.codMesa);
                    table.ForeignKey(
                        name: "FK_Mesas_LugarVotaciones_codLugarVoto",
                        column: x => x.codLugarVoto,
                        principalTable: "LugarVotaciones",
                        principalColumn: "codLugarVoto");
                });

            migrationBuilder.CreateTable(
                name: "Personas",
                columns: table => new
                {
                    cedula = table.Column<int>(type: "int", nullable: false),
                    primerNombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    segundoNombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    primerApellido = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    segundoApellido = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    genero = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    edad = table.Column<int>(type: "int", nullable: false),
                    jurado = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    codMesa = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Personas", x => x.cedula);
                    table.ForeignKey(
                        name: "FK_Personas_Mesas_codMesa",
                        column: x => x.codMesa,
                        principalTable: "Mesas",
                        principalColumn: "codMesa",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Registros",
                columns: table => new
                {
                    codRegistro = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    registro = table.Column<int>(type: "int", nullable: false),
                    cedula = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Registros", x => x.codRegistro);
                    table.ForeignKey(
                        name: "FK_Registros_Personas_cedula",
                        column: x => x.cedula,
                        principalTable: "Personas",
                        principalColumn: "cedula",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Mesas_codLugarVoto",
                table: "Mesas",
                column: "codLugarVoto");

            migrationBuilder.CreateIndex(
                name: "IX_Personas_codMesa",
                table: "Personas",
                column: "codMesa");

            migrationBuilder.CreateIndex(
                name: "IX_Registros_cedula",
                table: "Registros",
                column: "cedula");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Registros");

            migrationBuilder.DropTable(
                name: "Personas");

            migrationBuilder.DropTable(
                name: "Mesas");
        }
    }
}
