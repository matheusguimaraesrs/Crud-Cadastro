using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Crud_Cadastro.Migrations
{
    /// <inheritdoc />
    public partial class UpdateCreatedOn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "RegisteredOn",
                table: "Usuarios",
                newName: "CreatedOn");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CreatedOn",
                table: "Usuarios",
                newName: "RegisteredOn");
        }
    }
}
