/**CREATE TABLE PlayerGameStats
(
    Id INT IDENTITY(1,1) PRIMARY KEY,

    -- Player Info
    PersonId INT NOT NULL,
    FirstName NVARCHAR(50) NOT NULL,
    LastName NVARCHAR(50) NOT NULL,

    -- Game Info
    GameId BIGINT NOT NULL,

    GameDateTimeEst DATETIME NULL,
    GameDate DATETIME NULL,

    GameType NVARCHAR(50) NULL,
    GameLabel NVARCHAR(100) NULL,
    GameSubLabel NVARCHAR(100) NULL,

    SeriesGameNumber INT NULL,

    -- Team Info
    PlayerTeamId INT NULL,
    PlayerTeamCity NVARCHAR(50) NULL,
    PlayerTeamName NVARCHAR(50) NULL,

    OpponentTeamId INT NULL,
    OpponentTeamCity NVARCHAR(50) NULL,
    OpponentTeamName NVARCHAR(50) NULL,

    -- Game Result
    Win INT NULL,
    Home INT NULL,

    -- Player Stats
    NumMinutes DECIMAL(10,6) NULL,

    Points DECIMAL(10,6) NULL,
    Assists INT NULL,
    Blocks INT NULL,
    Steals INT NULL,

    FieldGoalsAttempted INT NULL,
    FieldGoalsMade INT NULL,
    FieldGoalsPercentage DECIMAL(6,3) NULL,

    ThreePointersAttempted INT NULL,
    ThreePointersMade INT NULL,
    ThreePointersPercentage DECIMAL(6,3) NULL,

    FreeThrowsAttempted INT NULL,
    FreeThrowsMade INT NULL,
    FreeThrowsPercentage DECIMAL(6,3) NULL,

    ReboundsDefensive INT NULL,
    ReboundsOffensive INT NULL,
    ReboundsTotal INT NULL,

    FoulsPersonal INT NULL,
    Turnovers INT NULL,

    PlusMinusPoints INT NULL,

    -- Misc
    Comment NVARCHAR(255) NULL,
    StartingPosition NVARCHAR(5) NULL
);

--Helpful indexes
CREATE INDEX IX_PlayerGameStats_PersonId
ON PlayerGameStats(PersonId);

CREATE INDEX IX_PlayerGameStats_GameId
ON PlayerGameStats(GameId);

CREATE INDEX IX_PlayerGameStats_GameDate
ON PlayerGameStats(GameDate);**/