using BasketballAPI;
using BasketballAPI.Database_Stuff;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class ImportController : Controller
{
    private readonly ApplicationDbContext _context;

    public ImportController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpPost("import")]
    public async Task<IActionResult> Import()
    {
        var importer = new CsvImporter(_context);

        await importer.ImportCsvAsync("C:\\Users\\spenc\\Desktop\\Mini Projects\\Basketball Stats App\\basketball-stats-app\\BasketballAPI\\BasketballAPI\\Controllers\\PlayerStatistics.csv");

        return Ok("Import complete");
    }

  [HttpPost("importPlayers")]
  public async Task<IActionResult> ImportPlayer()
  {
    var importer = new CsvImport(_context);

    await importer.ImportPlayersAsync("C:\\Users\\spenc\\Desktop\\Mini Projects\\Basketball Stats App\\basketball-stats-app\\BasketballAPI\\BasketballAPI\\Controllers\\Players.csv");

    return Ok("Import complete");
  }
}
