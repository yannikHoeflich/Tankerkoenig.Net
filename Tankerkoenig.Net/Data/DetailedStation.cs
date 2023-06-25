using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

using System;

namespace Tankerkoenig.Net.Data;
public record DetailedStation(
   [property: JsonPropertyName("id")] Guid Id,
   [property: JsonPropertyName("name")] string Name,
   [property: JsonPropertyName("brand")] string Brand,
   [property: JsonPropertyName("street")] string Street,
   [property: JsonPropertyName("houseNumber")] string HouseNumber,
   [property: JsonPropertyName("postCode")] int PostCode,
   [property: JsonPropertyName("place")] string Place,
   [property: JsonPropertyName("openingTimes")] IReadOnlyList<OpeningTime> OpeningTimes,
   [property: JsonPropertyName("overrides")] IReadOnlyList<object> Overrides,
   [property: JsonPropertyName("wholeDay")] bool WholeDay,
   [property: JsonPropertyName("isOpen")] bool IsOpen,
   [property: JsonPropertyName("e5")] double E5,
   [property: JsonPropertyName("e10")] double E10,
   [property: JsonPropertyName("diesel")] double Diesel,
   [property: JsonPropertyName("lat")] double Lat,
   [property: JsonPropertyName("lng")] double Lng,
   [property: JsonPropertyName("state")] object? State
) : IStation;