using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Checkpoint.Migrations
{
    public partial class Banco : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tbl_Endereco",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Logradouro = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Cep = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Cidade = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_Endereco", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_Tutor",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    GeneroTutor = table.Column<int>(type: "int", nullable: false),
                    Dt_Nascimento = table.Column<DateTime>(type: "Date", nullable: false),
                    EnderecoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_Tutor", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tbl_Tutor_Tbl_Endereco_EnderecoId",
                        column: x => x.EnderecoId,
                        principalTable: "Tbl_Endereco",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_Cachorro",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Sexo = table.Column<int>(type: "int", nullable: true),
                    Cor = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Raca = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Castrado = table.Column<bool>(type: "bit", nullable: false),
                    DataNascimento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TutorId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_Cachorro", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tbl_Cachorro_Tbl_Tutor_TutorId",
                        column: x => x.TutorId,
                        principalTable: "Tbl_Tutor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_Gato",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Sexo = table.Column<int>(type: "int", nullable: true),
                    Cor = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Raca = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Castrado = table.Column<bool>(type: "bit", nullable: false),
                    DataNascimento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TutorId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_Gato", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tbl_Gato_Tbl_Tutor_TutorId",
                        column: x => x.TutorId,
                        principalTable: "Tbl_Tutor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_Amigo",
                columns: table => new
                {
                    CachorroId = table.Column<int>(type: "int", nullable: false),
                    GatoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_Amigo", x => new { x.CachorroId, x.GatoId });
                    table.ForeignKey(
                        name: "FK_Tbl_Amigo_Tbl_Cachorro_CachorroId",
                        column: x => x.CachorroId,
                        principalTable: "Tbl_Cachorro",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tbl_Amigo_Tbl_Gato_GatoId",
                        column: x => x.GatoId,
                        principalTable: "Tbl_Gato",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_Amigo_GatoId",
                table: "Tbl_Amigo",
                column: "GatoId");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_Cachorro_TutorId",
                table: "Tbl_Cachorro",
                column: "TutorId");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_Gato_TutorId",
                table: "Tbl_Gato",
                column: "TutorId");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_Tutor_EnderecoId",
                table: "Tbl_Tutor",
                column: "EnderecoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tbl_Amigo");

            migrationBuilder.DropTable(
                name: "Tbl_Cachorro");

            migrationBuilder.DropTable(
                name: "Tbl_Gato");

            migrationBuilder.DropTable(
                name: "Tbl_Tutor");

            migrationBuilder.DropTable(
                name: "Tbl_Endereco");
        }
    }
}
