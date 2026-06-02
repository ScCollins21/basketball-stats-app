using System.Globalization;
using CsvHelper;
using BasketballAPI.Models;
using CsvHelper.Configuration;


namespace BasketballAPI.Database_Stuff
{
  public class PlayerCSVImport
  {
  }

  public sealed class PlayerMap : ClassMap<Player>
  {
    public PlayerMap()
    {
      Map(m => m.PersonId).Name("personId");
      Map(m => m.FirstName).Name("firstName");
      Map(m => m.LastName).Name("lastName");
      Map(m => m.BirthDate).Name("birthDate");
      Map(m => m.School).Name("school");
      Map(m => m.Country).Name("country");

      Map(m => m.HeightInches).Name("heightInches");
      Map(m => m.BodyWeightLbs).Name("bodyWeightLbs");
      Map(m => m.Jersey).Ignore();

      Map(m => m.Guard).Name("guard");
      Map(m => m.Forward).Name("forward");
      Map(m => m.Center).Name("center");

      Map(m => m.DLeagueFlag).Name("dleagueFlag");
      Map(m => m.NbaFlag).Name("nbaFlag");
      Map(m => m.GamesPlayedFlag).Name("gamesPlayedFlag");

      Map(m => m.DraftYear).Name("draftYear");
      Map(m => m.DraftRound).Name("draftRound");
      Map(m => m.DraftNumber).Name("draftNumber");

      Map(m => m.FromYear).Name("fromYear");
      Map(m => m.ToYear).Name("toYear");
    }
  }

  public class CsvImport
  {
    private readonly ApplicationDbContext _context;

    public CsvImport(ApplicationDbContext context)
    {
      _context = context;
    }

    public async Task ImportPlayersAsync(string filePath)
    {
      using var reader = new StreamReader(filePath);
      using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);

      csv.Context.RegisterClassMap<PlayerMap>();

      var players = csv.GetRecords<Player>().ToList();

      await _context.Player.AddRangeAsync(players);
      await _context.SaveChangesAsync();
    }
  }
}
