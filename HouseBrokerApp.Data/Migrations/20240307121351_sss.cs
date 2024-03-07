using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HouseBrokerApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class sss : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProperyDetailId",
                table: "PropertyImage");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProperyDetailId",
                table: "PropertyImage",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
