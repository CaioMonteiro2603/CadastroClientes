using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CadastroClientes.Migrations
{
    /// <inheritdoc />
    public partial class Nova : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<string>(
                name: "CategoriaCliente",
                table: "Cliente",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "CategoriaCliente",
                table: "Cliente",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ClienteId",
                table: "Categoria",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Categoria_ClienteId",
                table: "Categoria",
                column: "ClienteId");

            migrationBuilder.AddForeignKey(
                name: "FK_Categoria_Cliente_ClienteId",
                table: "Categoria",
                column: "ClienteId",
                principalTable: "Cliente",
                principalColumn: "ClienteId");
        }
    }
}
