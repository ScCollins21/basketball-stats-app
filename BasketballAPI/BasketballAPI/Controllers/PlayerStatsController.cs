using BasketballAPI;
using BasketballAPI.Database_Stuff;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BasketballAPI.Controllers
{
  [ApiController]
  [Route("api/playerstats/[controller]")]
  public class PlayerStatsController : ControllerBase
  {
    private readonly ApplicationDbContext _context;

    public PlayerStatsController(ApplicationDbContext context)
    {
      this._context = context;
    }

    [HttpGet("{playerId}")]
    public async Task<IActionResult> PlayerStatsCareerAvgs(int playerId)
    {

      var averages = await _context.PlayerGameStats.Where(s => s.PersonId == playerId && s.GameType == "Regular Season").GroupBy(s => s.PersonId) // Group by player ID to calculate averages for the specified player
        .Select(g => new
        {
          PlayerId = g.Key,
          PointsPerGame = g.Average(s => s.Points),
          AssistsPerGame = g.Average(s => s.Assists),
          ReboundsPerGame = g.Average(s => s.ReboundsTotal),
          StealsPerGame = g.Average(s => s.Steals),
          BlocksPerGame = g.Average(s => s.Blocks)
        }).FirstOrDefaultAsync();

      if(averages == null) {
        return NotFound("Player not found");
      }

      return Ok(averages);
    }
  }
}
