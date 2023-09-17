namespace Tankerkoenig.Net.Data;

public interface IStation {
    string Brand { get; init; }
    double? Diesel { get; init; }
    double? E10 { get; init; }
    double? E5 { get; init; }
    string HouseNumber { get; init; }
    Guid Id { get; init; }
    bool IsOpen { get; init; }
    double Lat { get; init; }
    double Lng { get; init; }
    string Name { get; init; }
    string Place { get; init; }
    int PostCode { get; init; }
    string Street { get; init; }
}