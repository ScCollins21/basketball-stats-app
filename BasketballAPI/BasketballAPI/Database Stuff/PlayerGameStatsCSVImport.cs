using BasketballAPI.Models;
using CsvHelper;
using CsvHelper.Configuration;
using CsvHelper.TypeConversion;
using Microsoft.EntityFrameworkCore;
using System.Globalization;
using System.Text.RegularExpressions;


namespace BasketballAPI.Database_Stuff
{

    public class PlayerGameStatsMap : ClassMap<PlayerGameStats>
    {
        public PlayerGameStatsMap()
        {
            Map(m => m.FirstName).Name("firstName");
            Map(m => m.LastName).Name("lastName");
            Map(m => m.PersonId).Name("personId");

            Map(m => m.GameId).Name("gameId");

            Map(m => m.GameDateTimeEst).Name("gameDateTimeEst");
            Map(m => m.GameDate).Name("gameDate");

            Map(m => m.PlayerTeamCity).Name("playerteamCity");
            Map(m => m.PlayerTeamName).Name("playerteamName");

            Map(m => m.OpponentTeamCity).Name("opponentteamCity");
            Map(m => m.OpponentTeamName).Name("opponentteamName");

            Map(m => m.GameType).Name("gameType");
            Map(m => m.GameLabel).Name("gameLabel");
            Map(m => m.GameSubLabel).Name("gameSubLabel");

            Map(m => m.SeriesGameNumber).Name("seriesGameNumber").TypeConverter<GameNumberConverter>(); ;

            Map(m => m.Win).Name("win");
            Map(m => m.Home).Name("home");

            Map(m => m.NumMinutes).Name("numMinutes").TypeConverter<NumMinutesConverter>();

            Map(m => m.Points).Name("points");
            Map(m => m.Assists).Name("assists");
            Map(m => m.Blocks).Name("blocks");
            Map(m => m.Steals).Name("steals");

            Map(m => m.FieldGoalsAttempted).Name("fieldGoalsAttempted");
            Map(m => m.FieldGoalsMade).Name("fieldGoalsMade");
            Map(m => m.FieldGoalsPercentage).Name("fieldGoalsPercentage");

            Map(m => m.ThreePointersAttempted).Name("threePointersAttempted");
            Map(m => m.ThreePointersMade).Name("threePointersMade");
            Map(m => m.ThreePointersPercentage).Name("threePointersPercentage");

            Map(m => m.FreeThrowsAttempted).Name("freeThrowsAttempted");
            Map(m => m.FreeThrowsMade).Name("freeThrowsMade");
            Map(m => m.FreeThrowsPercentage).Name("freeThrowsPercentage");

            Map(m => m.ReboundsDefensive).Name("reboundsDefensive");
            Map(m => m.ReboundsOffensive).Name("reboundsOffensive");
            Map(m => m.ReboundsTotal).Name("reboundsTotal");

            Map(m => m.FoulsPersonal).Name("foulsPersonal");
            Map(m => m.Turnovers).Name("turnovers");

            Map(m => m.PlusMinusPoints).Name("plusMinusPoints");

            Map(m => m.PlayerTeamId).Name("playerteamId");
            Map(m => m.OpponentTeamId).Name("opponentteamId");

            Map(m => m.Comment).Name("comment");

            Map(m => m.StartingPosition).Name("startingPosition");
        }
    }

    public class GameNumberConverter : DefaultTypeConverter
    {
        public override object ConvertFromString(string text, IReaderRow row, MemberMapData memberMapData)
        {
            if (string.IsNullOrWhiteSpace(text))
                return null;

            // pulls digits out of "Game 1"
            var match = Regex.Match(text, @"\d+");

            if (match.Success && int.TryParse(match.Value, out int result))
                return result;

            return null;
        }
    }

  public class NumMinutesConverter : DefaultTypeConverter
  {
    public override object ConvertFromString(string text, IReaderRow row, MemberMapData memberMapData)
    {
      if (string.IsNullOrWhiteSpace(text))
        return null;

      // Splits like this ex. "12:34" into ["12", "34"] and converts to 12 + (34/60) = 12.5667
      var parts = text.Split(':');

      if (parts.Length == 2 && // Check if the output is in the expected format
            int.TryParse(parts[0], out var minutes) &&
            int.TryParse(parts[1], out var seconds))
      {
        return minutes + (seconds / 60.0m);
      }

      if (decimal.TryParse(text, out var dec))
        return dec;

      return null;
    }
  }

  public class CsvImporter
    {
        private readonly ApplicationDbContext _context;

        public CsvImporter(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task ImportCsvAsync(string filePath)
        {
            using var reader = new StreamReader(filePath);

            var config = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                MissingFieldFound = null,
                HeaderValidated = null,
                BadDataFound = null
            };

            using var csv = new CsvReader(reader, config);

            csv.Context.RegisterClassMap<PlayerGameStatsMap>();

            var records = csv.GetRecords<PlayerGameStats>().ToList();

            await _context.PlayerGameStats.AddRangeAsync(records);

            await _context.SaveChangesAsync();
        }
    }

}
