using BasketballAPI;
using BasketballAPI.Database_Stuff;
using Microsoft.AspNetCore.Mvc;

namespace BasketballAPI.Controllers
{
  [ApiController]
  [Route("api/playerstats/[controller]")]
  public class PlayerStatsController : ControllerBase
  {
    private readonly ApplicationDbContext _context;

    public PlayerStatsController(ApplicationDbContext context)
    {
      _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> PlayerStats(string playerId)
    {



      return Ok("Import complete");
    }
  }
}
