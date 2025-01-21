using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjetoAndre.Infrastruct.Migrations
{
    /// <inheritdoc />
    public partial class v010 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "combos",
                columns: table => new
                {
                    IdCombo = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Code = table.Column<string>(type: "text", nullable: false),
                    Discount = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_combos", x => x.IdCombo);
                    table.UniqueConstraint("ComboCode", x => x.Code);
                });

            migrationBuilder.CreateTable(
                name: "products",
                columns: table => new
                {
                    IdProduct = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    BarCode = table.Column<string>(type: "text", nullable: false),
                    Marca = table.Column<string>(type: "text", nullable: false),
                    CostPrice = table.Column<decimal>(type: "numeric", nullable: false),
                    SellPrice = table.Column<decimal>(type: "numeric", nullable: false),
                    Supplier = table.Column<string>(type: "text", nullable: true),
                    NCM = table.Column<string>(type: "text", nullable: false),
                    CFop = table.Column<string>(type: "text", nullable: false),
                    ComboId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_products", x => x.IdProduct);
                    table.ForeignKey(
                        name: "FK_products_combos_ComboId",
                        column: x => x.ComboId,
                        principalTable: "combos",
                        principalColumn: "IdCombo");
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_products_BarCode",
                table: "products",
                column: "BarCode",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_products_ComboId",
                table: "products",
                column: "ComboId");

            migrationBuilder.CreateIndex(
                name: "IX_products_Name",
                table: "products",
                column: "Name",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "products");

            migrationBuilder.DropTable(
                name: "combos");
        }
    }
}
