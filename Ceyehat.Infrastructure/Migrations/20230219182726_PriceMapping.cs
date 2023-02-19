using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ceyehat.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class PriceMapping : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Prices",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Amount = table.Column<decimal>(type: "numeric(18,2)", nullable: false),
                    Currency = table.Column<int>(type: "integer", maxLength: 3, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prices", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FlightPricing",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    PriceId = table.Column<Guid>(type: "uuid", nullable: false),
                    BaseCost = table.Column<decimal>(type: "numeric(10,2)", nullable: false),
                    MarkupPercentage = table.Column<decimal>(type: "numeric(10,2)", nullable: false),
                    DemandMultiplier = table.Column<decimal>(type: "numeric(10,2)", nullable: false),
                    CompetitionMultiplier = table.Column<decimal>(type: "numeric(10,2)", nullable: false),
                    SeasonalMultiplier = table.Column<decimal>(type: "numeric(10,2)", nullable: false),
                    LengthMultiplier = table.Column<decimal>(type: "numeric(10,2)", nullable: false),
                    ClassMultiplier = table.Column<decimal>(type: "numeric(10,2)", nullable: false),
                    TotalCost = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FlightPricing", x => new { x.Id, x.PriceId });
                    table.ForeignKey(
                        name: "FK_FlightPricing_Prices_PriceId",
                        column: x => x.PriceId,
                        principalTable: "Prices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FlightPricing_PriceId",
                table: "FlightPricing",
                column: "PriceId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FlightPricing");

            migrationBuilder.DropTable(
                name: "Prices");
        }
    }
}
