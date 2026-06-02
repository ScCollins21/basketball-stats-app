using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BasketballAPI.Models
{
  public class Player
  {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    public int PersonId { get; set; }

    public string FirstName { get; set; } = string.Empty;

    public string LastName { get; set; } = string.Empty;

    public DateTime? BirthDate { get; set; }

    public string? School { get; set; }

    public string Country { get; set; } = string.Empty;

    public int? HeightInches { get; set; }

    public int? BodyWeightLbs { get; set; }

    public int? Jersey { get; set; }

    // Position flags
    public int? Guard { get; set; }

    public int? Forward { get; set; }

    public int? Center { get; set; }

    // League flags
    public int? DLeagueFlag { get; set; }

    public int? NbaFlag { get; set; }

    public int? GamesPlayedFlag { get; set; }

    // Draft information
    public int? DraftYear { get; set; }

    public int? DraftRound { get; set; }

    public int? DraftNumber { get; set; }

    // Career years
    public int? FromYear { get; set; }

    public int? ToYear { get; set; }
  }
}
