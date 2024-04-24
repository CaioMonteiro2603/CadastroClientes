using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CadastroClientes.Migrations
{
    /// <inheritdoc />
    public partial class ClienteMap : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Categoria_Cliente_ClienteId",
                table: "Categoria");

            migrationBuilder.AlterColumn<int>(
                name: "ClienteId",
                table: "Categoria",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Categoria_Cliente_ClienteId",
                table: "Categoria",
                column: "ClienteId",
                principalTable: "Cliente",
                principalColumn: "ClienteId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Categoria_Cliente_ClienteId",
                table: "Categoria");

            migrationBuilder.AlterColumn<int>(
                name: "ClienteId",
                table: "Categoria",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Categoria_Cliente_ClienteId",
                table: "Categoria",
                column: "ClienteId",
                principalTable: "Cliente",
                principalColumn: "ClienteId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
