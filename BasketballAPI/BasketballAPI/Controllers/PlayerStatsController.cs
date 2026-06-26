using BasketballAPI;
using BasketballAPI.Database_Stuff;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BasketballAPI.Controllers
{
  [ApiController]
  [Route("api/playerstats")]
  public class PlayerStatsController : ControllerBase
  {
    private readonly ApplicationDbContext _context;

    public PlayerStatsController(ApplicationDbContext context)
    {
      this._context = context;
    }

    [HttpGet("stataverages/{playerId}")]//update route in front end to match this route
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

    [HttpGet("byname/{playerName}")]
    public async Task<IActionResult> PlayersByName(string playerName)
    {
      if (playerName == null)
      {
        return BadRequest("Player name cannot be null"); // Handle null entry for playerName
      }

      var averages = await _context.Player.Where(s => s.FirstName /**+ " " + s.LastName**/ == playerName).GroupBy(s => s.FirstName)
        .Select(g => new
        {
          PlayerId = g.Key,
          FirstName = g.Select(s => s.FirstName).First(),
          LastName = g.Select(s => s.LastName).First(),
          FromYear = g.Select(s => s.FromYear).First(),
          ToYear = g.Select(s => s.ToYear).First()//Need to add handling for null because current players have a null to year
        }).ToListAsync();

      return Ok(averages);
    }

  }
}
