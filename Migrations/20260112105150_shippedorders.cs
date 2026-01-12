using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SportsStore2.Migrations
{
    /// <inheritdoc />
    public partial class shippedorders : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Shipped",
                table: "Orders",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Shipped",
                table: "Orders");
        }
    }
}
