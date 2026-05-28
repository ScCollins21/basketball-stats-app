using BasketballAPI;
using BasketballAPI.Database_Stuff;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class ImportController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public ImportController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpPost]
    public async Task<IActionResult> Import()
    {
        var importer = new CsvImporter(_context);

        await importer.ImportCsvAsync("C:\\Users\\spenc\\Desktop\\Mini Projects\\Basketball Stats App\\BasketballAPI\\BasketballAPI\\Controllers\\PlayerStatistics.csv");

        return Ok("Import complete");
    }
}