using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

using System;

namespace Tankerkoenig.Net.Data;
public record OpeningTime(
    [property: JsonPropertyName("text")] string Text,
    [property: JsonPropertyName("start")] TimeOnly Start,
    [property: JsonPropertyName("end")] TimeOnly End
);