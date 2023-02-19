using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ceyehat.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class FlightMappingV2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "PriceId",
                table: "Flights",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PriceId",
                table: "Flights");
        }
    }
}
