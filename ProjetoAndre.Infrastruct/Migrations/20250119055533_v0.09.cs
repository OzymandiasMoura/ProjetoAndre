using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjetoAndre.Infrastruct.Migrations
{
    /// <inheritdoc />
    public partial class v009 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_products_BarCode",
                table: "products",
                column: "BarCode",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_products_Name",
                table: "products",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_combos_Code",
                table: "combos",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_combos_Name",
                table: "combos",
                column: "Name",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_products_BarCode",
                table: "products");

            migrationBuilder.DropIndex(
                name: "IX_products_Name",
                table: "products");

            migrationBuilder.DropIndex(
                name: "IX_combos_Code",
                table: "combos");

            migrationBuilder.DropIndex(
                name: "IX_combos_Name",
                table: "combos");
        }
    }
}
