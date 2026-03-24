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
