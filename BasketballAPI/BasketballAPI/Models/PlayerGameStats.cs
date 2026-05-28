namespace BasketballAPI.Models
{
    public class PlayerGameStats
    {
        public int Id { get; set; }

        // Player Info
        public int? PersonId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        // Game Info
        public long GameId { get; set; }

        public DateTime? GameDateTimeEst { get; set; }
        public DateTime? GameDate { get; set; }

        public string GameType { get; set; }
        public string GameLabel { get; set; }
        public string GameSubLabel { get; set; }

        public int? SeriesGameNumber { get; set; }

        // Team Info
        public int? PlayerTeamId { get; set; }
        public string PlayerTeamCity { get; set; }
        public string PlayerTeamName { get; set; }

        public int? OpponentTeamId { get; set; }
        public string OpponentTeamCity { get; set; }
        public string OpponentTeamName { get; set; }

        // Game Result
        public int? Win { get; set; }
        public int? Home { get; set; }

        // Stats
        public decimal? NumMinutes { get; set; }

        public decimal? Points { get; set; }
        public decimal? Assists { get; set; }
        public decimal? Blocks { get; set; }
        public decimal? Steals { get; set; }

        public decimal? FieldGoalsAttempted { get; set; }
        public decimal? FieldGoalsMade { get; set; }
        public decimal? FieldGoalsPercentage { get; set; }

        public decimal? ThreePointersAttempted { get; set; }
        public decimal? ThreePointersMade { get; set; }
        public decimal? ThreePointersPercentage { get; set; }

        public decimal? FreeThrowsAttempted { get; set; }
        public decimal? FreeThrowsMade { get; set; }
        public decimal? FreeThrowsPercentage { get; set; }

        public decimal? ReboundsDefensive { get; set; }
        public decimal? ReboundsOffensive { get; set; }
        public decimal? ReboundsTotal { get; set; }

        public decimal? FoulsPersonal { get; set; }
        public decimal? Turnovers { get; set; } = 0;
        public decimal? PlusMinusPoints { get; set; }

        // Misc
        public string Comment { get; set; }
        public string StartingPosition { get; set; }
    }
}
