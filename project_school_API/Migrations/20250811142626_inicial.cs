using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace project_school_API.Migrations
{
    public partial class inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Professores",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Professores", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Alunos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(type: "TEXT", nullable: false),
                    Sobrenome = table.Column<string>(type: "TEXT", nullable: false),
                    DataNasc = table.Column<string>(type: "TEXT", nullable: false),
                    ProfessorId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Alunos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Alunos_Professores_ProfessorId",
                        column: x => x.ProfessorId,
                        principalTable: "Professores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Professores",
                columns: new[] { "Id", "Nome" },
                values: new object[] { 1, "Vinicius" });

            migrationBuilder.InsertData(
                table: "Professores",
                columns: new[] { "Id", "Nome" },
                values: new object[] { 2, "Rafael" });

            migrationBuilder.InsertData(
                table: "Professores",
                columns: new[] { "Id", "Nome" },
                values: new object[] { 3, "Luna" });

            migrationBuilder.InsertData(
                table: "Alunos",
                columns: new[] { "Id", "DataNasc", "Nome", "ProfessorId", "Sobrenome" },
                values: new object[] { 1, "02/02/2002", "Maria", 1, "silva" });

            migrationBuilder.InsertData(
                table: "Alunos",
                columns: new[] { "Id", "DataNasc", "Nome", "ProfessorId", "Sobrenome" },
                values: new object[] { 2, "01/01/2001", "joão", 2, "Fenades" });

            migrationBuilder.InsertData(
                table: "Alunos",
                columns: new[] { "Id", "DataNasc", "Nome", "ProfessorId", "Sobrenome" },
                values: new object[] { 3, "03/03/1999", "alex", 3, "Alencar" });

            migrationBuilder.CreateIndex(
                name: "IX_Alunos_ProfessorId",
                table: "Alunos",
                column: "ProfessorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Alunos");

            migrationBuilder.DropTable(
                name: "Professores");
        }
    }
}
