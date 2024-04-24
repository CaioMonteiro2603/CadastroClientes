using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CadastroClientes.Migrations
{
    /// <inheritdoc />
    public partial class CateCli : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Cliente",
                newName: "ClienteId");

            migrationBuilder.AddColumn<int>(
                name: "ClienteId",
                table: "Categoria",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Categoria_ClienteId",
                table: "Categoria",
                column: "ClienteId");

            migrationBuilder.AddForeignKey(
                name: "FK_Categoria_Cliente_ClienteId",
                table: "Categoria",
                column: "ClienteId",
                principalTable: "Cliente",
                principalColumn: "ClienteId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Categoria_Cliente_ClienteId",
                table: "Categoria");

            migrationBuilder.DropIndex(
                name: "IX_Categoria_ClienteId",
                table: "Categoria");

            migrationBuilder.DropColumn(
                name: "ClienteId",
                table: "Categoria");

            migrationBuilder.RenameColumn(
                name: "ClienteId",
                table: "Cliente",
                newName: "Id");
        }
    }
}
