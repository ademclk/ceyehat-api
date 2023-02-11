using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ceyehat.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class FlightMapping : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Flights",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    FlightNumber = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    ScheduledDeparture = table.Column<DateTime>(type: "timestamp with time zone", maxLength: 256, nullable: false),
                    ScheduledArrival = table.Column<DateTime>(type: "timestamp with time zone", maxLength: 256, nullable: false),
                    Status = table.Column<int>(type: "integer", maxLength: 32, nullable: false),
                    Type = table.Column<int>(type: "integer", maxLength: 32, nullable: false),
                    ActualDeparture = table.Column<DateTime>(type: "timestamp with time zone", maxLength: 256, nullable: true),
                    ActualArrival = table.Column<DateTime>(type: "timestamp with time zone", maxLength: 256, nullable: true),
                    AircraftId = table.Column<Guid>(type: "uuid", nullable: false),
                    DepartureAirportId = table.Column<Guid>(type: "uuid", nullable: false),
                    ArrivalAirportId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Flights", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Flights");
        }
    }
}
