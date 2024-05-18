using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Maxi.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class productidremove : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "products");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProductId",
                table: "products",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
