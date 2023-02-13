using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Ceyehat.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AirportMapping : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Airports",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    IataCode = table.Column<string>(type: "character varying(16)", maxLength: 16, nullable: true),
                    IcaoCode = table.Column<string>(type: "character varying(16)", maxLength: 16, nullable: true),
                    Latitude = table.Column<decimal>(type: "numeric(6,16)", nullable: false),
                    Longitude = table.Column<decimal>(type: "numeric(6,16)", nullable: false),
                    TimeZone = table.Column<string>(type: "character varying(16)", maxLength: 16, nullable: true),
                    CityId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Airports", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AirportArrivalFlightIds",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FlightId = table.Column<Guid>(type: "uuid", nullable: false),
                    AirportId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AirportArrivalFlightIds", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AirportArrivalFlightIds_Airports_AirportId",
                        column: x => x.AirportId,
                        principalTable: "Airports",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AirportDepartureFlightIds",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FlightId = table.Column<Guid>(type: "uuid", nullable: false),
                    AirportId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AirportDepartureFlightIds", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AirportDepartureFlightIds_Airports_AirportId",
                        column: x => x.AirportId,
                        principalTable: "Airports",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AirportArrivalFlightIds_AirportId",
                table: "AirportArrivalFlightIds",
                column: "AirportId");

            migrationBuilder.CreateIndex(
                name: "IX_AirportDepartureFlightIds_AirportId",
                table: "AirportDepartureFlightIds",
                column: "AirportId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AirportArrivalFlightIds");

            migrationBuilder.DropTable(
                name: "AirportDepartureFlightIds");

            migrationBuilder.DropTable(
                name: "Airports");
        }
    }
}
