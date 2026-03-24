using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace ApiFutbolCostaRica.Infrastructure.ExternalServices.FootballApi.Models;

public class FootballApiResponse<T>
{
    [JsonPropertyName("response")]
    public List<T> Response { get; set; } = new();
}

public class TeamDto
{
    [JsonPropertyName("team")]
    public TeamData Team { get; set; } = new();

    [JsonPropertyName("venue")]
    public VenueData Venue { get; set; } = new();
}

public class TeamData
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; } = string.Empty;

    [JsonPropertyName("founded")]
    public int? Founded { get; set; }

    [JsonPropertyName("logo")]
    public string? Logo { get; set; }
}

public class VenueData
{
    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("image")]
    public string? Image { get; set; }
}

public class SquadDto
{
    [JsonPropertyName("team")]
    public TeamData Team { get; set; } = new();

    [JsonPropertyName("players")]
    public List<PlayerData> Players { get; set; } = new();
}

public class PlayerData
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; } = string.Empty;

    [JsonPropertyName("age")]
    public int? Age { get; set; }

    [JsonPropertyName("position")]
    public string Position { get; set; } = string.Empty;

    [JsonPropertyName("number")]
    public int? Number { get; set; }

    [JsonPropertyName("photo")]
    public string? Photo { get; set; }
}

public class FixtureDto
{
    [JsonPropertyName("fixture")]
    public FixtureData Fixture { get; set; } = new();

    [JsonPropertyName("teams")]
    public FixtureTeams Teams { get; set; } = new();

    [JsonPropertyName("goals")]
    public FixtureGoals Goals { get; set; } = new();
}

public class FixtureData
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("referee")]
    public string? Referee { get; set; }

    [JsonPropertyName("date")]
    public DateTime Date { get; set; }

    [JsonPropertyName("venue")]
    public VenueData Venue { get; set; } = new();

    [JsonPropertyName("status")]
    public FixtureStatus Status { get; set; } = new();
}

public class FixtureStatus
{
    [JsonPropertyName("long")]
    public string Long { get; set; } = string.Empty;

    [JsonPropertyName("short")]
    public string Short { get; set; } = string.Empty;
}

public class FixtureTeams
{
    [JsonPropertyName("home")]
    public FixtureTeam Home { get; set; } = new();

    [JsonPropertyName("away")]
    public FixtureTeam Away { get; set; } = new();
}

public class FixtureTeam
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; } = string.Empty;

    [JsonPropertyName("winner")]
    public bool? Winner { get; set; }
}

public class FixtureGoals
{
    [JsonPropertyName("home")]
    public int? Home { get; set; }

    [JsonPropertyName("away")]
    public int? Away { get; set; }
}
