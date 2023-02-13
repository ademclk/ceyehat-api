using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ceyehat.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SeatMapping : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Seats",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    SeatNumber = table.Column<string>(type: "character varying(4)", maxLength: 4, nullable: true),
                    SeatClass = table.Column<int>(type: "integer", nullable: false),
                    SeatStatus = table.Column<int>(type: "integer", nullable: false),
                    AircraftId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Seats", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Seats");
        }
    }
}
