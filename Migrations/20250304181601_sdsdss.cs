using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Zapateria.Migrations
{
    /// <inheritdoc />
    public partial class sdsdss : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Zapatos_Tipos_TipoId",
                table: "Zapatos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Zapatos",
                table: "Zapatos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Tipos",
                table: "Tipos");

            migrationBuilder.RenameTable(
                name: "Zapatos",
                newName: "Zapato");

            migrationBuilder.RenameTable(
                name: "Tipos",
                newName: "Tipo");

            migrationBuilder.RenameIndex(
                name: "IX_Zapatos_TipoId",
                table: "Zapato",
                newName: "IX_Zapato_TipoId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Zapato",
                table: "Zapato",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tipo",
                table: "Tipo",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Zapato_Tipo_TipoId",
                table: "Zapato",
                column: "TipoId",
                principalTable: "Tipo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Zapato_Tipo_TipoId",
                table: "Zapato");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Zapato",
                table: "Zapato");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Tipo",
                table: "Tipo");

            migrationBuilder.RenameTable(
                name: "Zapato",
                newName: "Zapatos");

            migrationBuilder.RenameTable(
                name: "Tipo",
                newName: "Tipos");

            migrationBuilder.RenameIndex(
                name: "IX_Zapato_TipoId",
                table: "Zapatos",
                newName: "IX_Zapatos_TipoId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Zapatos",
                table: "Zapatos",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tipos",
                table: "Tipos",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Zapatos_Tipos_TipoId",
                table: "Zapatos",
                column: "TipoId",
                principalTable: "Tipos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
