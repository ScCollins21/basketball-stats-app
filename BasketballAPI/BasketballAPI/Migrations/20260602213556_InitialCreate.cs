using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BasketballAPI.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Player",
                columns: table => new
                {
                    PersonId = table.Column<int>(type: "int", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    School = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HeightInches = table.Column<int>(type: "int", nullable: true),
                    BodyWeightLbs = table.Column<int>(type: "int", nullable: true),
                    Jersey = table.Column<int>(type: "int", nullable: true),
                    Guard = table.Column<int>(type: "int", nullable: true),
                    Forward = table.Column<int>(type: "int", nullable: true),
                    Center = table.Column<int>(type: "int", nullable: true),
                    DLeagueFlag = table.Column<int>(type: "int", nullable: true),
                    NbaFlag = table.Column<int>(type: "int", nullable: true),
                    GamesPlayedFlag = table.Column<int>(type: "int", nullable: true),
                    DraftYear = table.Column<int>(type: "int", nullable: true),
                    DraftRound = table.Column<int>(type: "int", nullable: true),
                    DraftNumber = table.Column<int>(type: "int", nullable: true),
                    FromYear = table.Column<int>(type: "int", nullable: true),
                    ToYear = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Player", x => x.PersonId);
                });

            migrationBuilder.CreateTable(
                name: "PlayerGameStats",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PersonId = table.Column<int>(type: "int", nullable: true),
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
                    Assists = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Blocks = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Steals = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    FieldGoalsAttempted = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    FieldGoalsMade = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    FieldGoalsPercentage = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    ThreePointersAttempted = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    ThreePointersMade = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    ThreePointersPercentage = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    FreeThrowsAttempted = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    FreeThrowsMade = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    FreeThrowsPercentage = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    ReboundsDefensive = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    ReboundsOffensive = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    ReboundsTotal = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    FoulsPersonal = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Turnovers = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    PlusMinusPoints = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
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
                name: "Player");

            migrationBuilder.DropTable(
                name: "PlayerGameStats");
        }
    }
}
