namespace Ceyehat.Contracts.Airlines;

public record CreateAirlineRequest
{
    public string? Name { get; init; }
    public string? IataCode { get; init; }
    public string? IcaoCode { get; init; }
    public string? Callsign { get; init; }
    public string? Code { get; init; }
    public string? Website { get; init; }
}