using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Ceyehat.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class CustomerMappingV2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CustomerPassengerIds");

            migrationBuilder.AddColumn<int>(
                name: "Currency",
                table: "CustomerBookings",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PassengerType",
                table: "CustomerBookings",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<float>(
                name: "Price",
                table: "CustomerBookings",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.CreateTable(
                name: "CustomerBoardingPasses",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    BoardingGroup = table.Column<string>(type: "character varying(2)", maxLength: 2, nullable: true),
                    BoardingGate = table.Column<string>(type: "character varying(8)", maxLength: 8, nullable: true),
                    BoardingTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CheckInTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CustomerId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerBoardingPasses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CustomerBoardingPasses_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CustomerFlightTickets",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    BoardingPassId = table.Column<Guid>(type: "uuid", nullable: true),
                    BookingId = table.Column<Guid>(type: "uuid", nullable: false),
                    CustomerId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerFlightTickets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CustomerFlightTickets_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CustomerBoardingPasses_CustomerId",
                table: "CustomerBoardingPasses",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerFlightTickets_CustomerId",
                table: "CustomerFlightTickets",
                column: "CustomerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CustomerBoardingPasses");

            migrationBuilder.DropTable(
                name: "CustomerFlightTickets");

            migrationBuilder.DropColumn(
                name: "Currency",
                table: "CustomerBookings");

            migrationBuilder.DropColumn(
                name: "PassengerType",
                table: "CustomerBookings");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "CustomerBookings");

            migrationBuilder.CreateTable(
                name: "CustomerPassengerIds",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CustomerId = table.Column<Guid>(type: "uuid", nullable: false),
                    PassengerId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerPassengerIds", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CustomerPassengerIds_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CustomerPassengerIds_CustomerId",
                table: "CustomerPassengerIds",
                column: "CustomerId");
        }
    }
}
