using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PackIT.Infrastructure.EF.Migrations
{
    /// <inheritdoc />
    public partial class PackItem_Quantity_Correction : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Quentity",
                schema: "packing",
                table: "PackingItems",
                newName: "Quantity");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Quantity",
                schema: "packing",
                table: "PackingItems",
                newName: "Quentity");
        }
    }
}
