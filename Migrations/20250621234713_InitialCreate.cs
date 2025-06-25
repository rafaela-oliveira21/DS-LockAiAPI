using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace LockAiAPI.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TB_PLANOLOCACAO",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LocalidadePrimaria = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LocalidadeSecundaria = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LocalidadeTercearia = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Situacao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    idTipoObjeto = table.Column<int>(type: "int", nullable: false),
                    DataInclusao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdUsuarioInclusao = table.Column<int>(type: "int", nullable: false),
                    DataAtualizacao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdUsuarioAtualizacao = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_PLANOLOCACAO", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "TB_PLANOLOCACAO",
                columns: new[] { "Id", "DataAtualizacao", "DataInclusao", "Descricao", "IdUsuarioAtualizacao", "IdUsuarioInclusao", "LocalidadePrimaria", "LocalidadeSecundaria", "LocalidadeTercearia", "Nome", "Situacao", "idTipoObjeto" },
                values: new object[,]
                {
                    { 1, "2025-06-21", "2025-06-20", "Mesa de madeira", 100, 100, "Predio A", "Andar 1", "Sala 101", "Mesa", "Ativa", 1 },
                    { 2, "2025-06-20", "2025-06-18", "Cadeira ergonômica para escritório", 101, 101, "Prédio B", "Andar 2", "Sala 205", "Cadeira", "Em uso", 2 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TB_PLANOLOCACAO");
        }
    }
}
