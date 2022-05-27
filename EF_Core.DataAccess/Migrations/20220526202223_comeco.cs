using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EF_Core.DataAccess.Migrations
{
    public partial class comeco : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Orcamentos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Data = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Cliente = table.Column<string>(type: "TEXT", maxLength: 255, nullable: false),
                    Valor = table.Column<decimal>(type: "TEXT", nullable: false),
                    StatusAtual = table.Column<int>(type: "INTEGER", nullable: false),
                    CadastradoPor = table.Column<string>(type: "TEXT", maxLength: 255, nullable: false),
                    AtualizadoPor = table.Column<string>(type: "TEXT", maxLength: 255, nullable: false),
                    DataCadastro = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DataAtualizacao = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orcamentos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OrcamentoStatusHistorico",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    OrcamentoId = table.Column<int>(type: "INTEGER", nullable: false),
                    OrcamentoStatus = table.Column<int>(type: "INTEGER", nullable: false),
                    CadastradoPor = table.Column<string>(type: "TEXT", nullable: true),
                    AtualizadoPor = table.Column<string>(type: "TEXT", nullable: true),
                    DataCadastro = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DataAtualizacao = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrcamentoStatusHistorico", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrcamentoStatusHistorico_Orcamentos_OrcamentoId",
                        column: x => x.OrcamentoId,
                        principalTable: "Orcamentos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrcamentoStatusHistorico_OrcamentoId",
                table: "OrcamentoStatusHistorico",
                column: "OrcamentoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrcamentoStatusHistorico");

            migrationBuilder.DropTable(
                name: "Orcamentos");
        }
    }
}
