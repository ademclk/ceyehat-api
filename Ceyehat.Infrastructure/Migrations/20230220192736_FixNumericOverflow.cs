using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ceyehat.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class FixNumericOverflow : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "Longitude",
                table: "Airports",
                type: "float",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "numeric(6,16)");

            migrationBuilder.AlterColumn<double>(
                name: "Latitude",
                table: "Airports",
                type: "float",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "numeric(6,16)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Longitude",
                table: "Airports",
                type: "numeric(6,16)",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<decimal>(
                name: "Latitude",
                table: "Airports",
                type: "numeric(6,16)",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");
        }
    }
}
