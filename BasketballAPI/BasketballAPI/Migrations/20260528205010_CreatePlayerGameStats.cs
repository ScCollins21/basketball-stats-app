using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BasketballAPI.Migrations
{
    /// <inheritdoc />
    public partial class CreatePlayerGameStats : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PlayerGameStats",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PersonId = table.Column<int>(type: "int", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GameId = table.Column<long>(type: "bigint", nullable: false),
                    GameDateTimeEst = table.Column<DateTime>(type: "datetime2", nullable: true),
                    GameDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    GameType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GameLabel = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GameSubLabel = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SeriesGameNumber = table.Column<int>(type: "int", nullable: true),
                    PlayerTeamId = table.Column<int>(type: "int", nullable: true),
                    PlayerTeamCity = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PlayerTeamName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OpponentTeamId = table.Column<int>(type: "int", nullable: true),
                    OpponentTeamCity = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OpponentTeamName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Win = table.Column<int>(type: "int", nullable: true),
                    Home = table.Column<int>(type: "int", nullable: true),
                    NumMinutes = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Points = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Assists = table.Column<int>(type: "int", nullable: true),
                    Blocks = table.Column<int>(type: "int", nullable: true),
                    Steals = table.Column<int>(type: "int", nullable: true),
                    FieldGoalsAttempted = table.Column<int>(type: "int", nullable: true),
                    FieldGoalsMade = table.Column<int>(type: "int", nullable: true),
                    FieldGoalsPercentage = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    ThreePointersAttempted = table.Column<int>(type: "int", nullable: true),
                    ThreePointersMade = table.Column<int>(type: "int", nullable: true),
                    ThreePointersPercentage = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    FreeThrowsAttempted = table.Column<int>(type: "int", nullable: true),
                    FreeThrowsMade = table.Column<int>(type: "int", nullable: true),
                    FreeThrowsPercentage = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    ReboundsDefensive = table.Column<int>(type: "int", nullable: true),
                    ReboundsOffensive = table.Column<int>(type: "int", nullable: true),
                    ReboundsTotal = table.Column<int>(type: "int", nullable: true),
                    FoulsPersonal = table.Column<int>(type: "int", nullable: true),
                    Turnovers = table.Column<int>(type: "int", nullable: true),
                    PlusMinusPoints = table.Column<int>(type: "int", nullable: true),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartingPosition = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayerGameStats", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PlayerGameStats");
        }
    }
}
