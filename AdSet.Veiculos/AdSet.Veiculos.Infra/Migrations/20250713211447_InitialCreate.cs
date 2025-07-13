using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AdSet.Veiculos.Infra.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Opcionais",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Opcionais", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Veiculos",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Marca = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Modelo = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Ano = table.Column<int>(type: "int", nullable: false),
                    Placa = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Cor = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Preco = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    Km = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Veiculos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FotosVeiculo",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CaminhoArquivo = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    VeiculoId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FotosVeiculo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FotosVeiculo_Veiculos_VeiculoId",
                        column: x => x.VeiculoId,
                        principalTable: "Veiculos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VeiculoOpcionais",
                columns: table => new
                {
                    VeiculoId = table.Column<long>(type: "bigint", nullable: false),
                    OpcionalId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VeiculoOpcionais", x => new { x.VeiculoId, x.OpcionalId });
                    table.ForeignKey(
                        name: "FK_VeiculoOpcionais_Opcionais_OpcionalId",
                        column: x => x.OpcionalId,
                        principalTable: "Opcionais",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VeiculoOpcionais_Veiculos_VeiculoId",
                        column: x => x.VeiculoId,
                        principalTable: "Veiculos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VeiculoPacotes",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VeiculoId = table.Column<long>(type: "bigint", nullable: false),
                    Portal = table.Column<int>(type: "int", nullable: false),
                    Pacote = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VeiculoPacotes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VeiculoPacotes_Veiculos_VeiculoId",
                        column: x => x.VeiculoId,
                        principalTable: "Veiculos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FotosVeiculo_VeiculoId",
                table: "FotosVeiculo",
                column: "VeiculoId");

            migrationBuilder.CreateIndex(
                name: "IX_VeiculoOpcionais_OpcionalId",
                table: "VeiculoOpcionais",
                column: "OpcionalId");

            migrationBuilder.CreateIndex(
                name: "IX_VeiculoPacotes_VeiculoId",
                table: "VeiculoPacotes",
                column: "VeiculoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FotosVeiculo");

            migrationBuilder.DropTable(
                name: "VeiculoOpcionais");

            migrationBuilder.DropTable(
                name: "VeiculoPacotes");

            migrationBuilder.DropTable(
                name: "Opcionais");

            migrationBuilder.DropTable(
                name: "Veiculos");
        }
    }
}
