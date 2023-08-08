using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolAPI.Migrations
{
    /// <inheritdoc />
    public partial class First : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AlunoTB",
                columns: table => new
                {
                    PK_ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    NOME = table.Column<string>(type: "VARCHAR", maxLength: 50, nullable: false),
                    SOBRENOME = table.Column<string>(type: "VARCHAR", maxLength: 150, nullable: false),
                    GENERO = table.Column<string>(type: "VARCHAR", maxLength: 20, nullable: false),
                    TELEFONE = table.Column<string>(type: "VARCHAR", maxLength: 30, nullable: false),
                    EMAIL = table.Column<string>(type: "VARCHAR", maxLength: 50, nullable: false),
                    DATA_NASCIMENTO = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Pk_aluno_id", x => x.PK_ID);
                });

            migrationBuilder.CreateTable(
                name: "Materia",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Materia", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TURMA",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CURSO = table.Column<string>(type: "varchar", maxLength: 50, nullable: false, defaultValue: "Curso Basico"),
                    Nome = table.Column<string>(type: "varchar", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TURMA", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "BOLETIM",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    DATA = table.Column<DateTime>(type: "date", nullable: false),
                    AlunoId = table.Column<int>(type: "INTGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BOLETIM", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BOLETIM_AlunoTB_AlunoId",
                        column: x => x.AlunoId,
                        principalTable: "AlunoTB",
                        principalColumn: "PK_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ALUNO_X_TURMA",
                columns: table => new
                {
                    ALUNO_ID = table.Column<int>(type: "INTEGER", nullable: false),
                    TURMA_ID = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ALUNO_X_TURMA", x => new { x.ALUNO_ID, x.TURMA_ID });
                    table.ForeignKey(
                        name: "FK_ALUNO_X_TURMA_AlunoTB_ALUNO_ID",
                        column: x => x.ALUNO_ID,
                        principalTable: "AlunoTB",
                        principalColumn: "PK_ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ALUNO_X_TURMA_TURMA_TURMA_ID",
                        column: x => x.TURMA_ID,
                        principalTable: "TURMA",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "NotasMaterias",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    BoletimId = table.Column<int>(type: "INTEGER", nullable: false),
                    MateriaId = table.Column<int>(type: "INTEGER", nullable: false),
                    Nota = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NotasMaterias", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NotasMaterias_BOLETIM_BoletimId",
                        column: x => x.BoletimId,
                        principalTable: "BOLETIM",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NotasMaterias_Materia_MateriaId",
                        column: x => x.MateriaId,
                        principalTable: "Materia",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ALUNO_X_TURMA_TURMA_ID",
                table: "ALUNO_X_TURMA",
                column: "TURMA_ID");

            migrationBuilder.CreateIndex(
                name: "IX_AlunoTB_EMAIL",
                table: "AlunoTB",
                column: "EMAIL",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_BOLETIM_AlunoId",
                table: "BOLETIM",
                column: "AlunoId");

            migrationBuilder.CreateIndex(
                name: "IX_NotasMaterias_BoletimId",
                table: "NotasMaterias",
                column: "BoletimId");

            migrationBuilder.CreateIndex(
                name: "IX_NotasMaterias_MateriaId",
                table: "NotasMaterias",
                column: "MateriaId");

            migrationBuilder.CreateIndex(
                name: "IX_TURMA_Nome",
                table: "TURMA",
                column: "Nome",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ALUNO_X_TURMA");

            migrationBuilder.DropTable(
                name: "NotasMaterias");

            migrationBuilder.DropTable(
                name: "TURMA");

            migrationBuilder.DropTable(
                name: "BOLETIM");

            migrationBuilder.DropTable(
                name: "Materia");

            migrationBuilder.DropTable(
                name: "AlunoTB");
        }
    }
}
