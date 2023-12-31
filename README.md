# Tankkoenig.NET
Tankkoenig.NET is an unofficial .NET API Wrapper for the [Tankkönig](https://tankerkoenig.de/) api.
Tankkönig provides the gas prices for german gas stations. The gas stations have to provide them to the 'MTS-K'.
With this API Wrapper you can request nearby gas stations and their prices.

## Installation
### NuGet
[Tankkoenig.NET](https://www.nuget.org/packages/TankerkoenigNet/)
You can install the library either though visual studio in the NuGet explorer.
Alternatively you can install it through command line

```sh
dotnet add package TankerkoenigNet
```

## Getting started
### Get an Api key for Tankkönig
1. Go on [creativecommons.tankerkoenig.de](https://creativecommons.tankerkoenig.de/)
2. Navigate to 'API-KEY'
3. Request an API key

## Examples

Creating a client
```cs
var client = new TankkoenigClientForTests("[YOUR API KEY]", httpClient);
```

Get nearby gas stations
```cs
var stations = await client.ListStationsAsync(21, 12, 5); // client.ListStationsAsync([your lat], [your lon], [radius])
```

Get data for specific gas stations
```cs
var station = await _client.GetStationAsync(Guid.Parse("005056ba-7cb6-1ed2-bceb-90e59ad2cd35")); // the GUID of a random gas station, you have to replace that with the gas station you want.
```