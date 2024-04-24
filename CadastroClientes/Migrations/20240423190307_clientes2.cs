using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CadastroClientes.Migrations
{
    /// <inheritdoc />
    public partial class clientes2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Uf",
                table: "Cliente",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Uf",
                table: "Cliente");
        }
    }
}
