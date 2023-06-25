using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

using System;

namespace Tankerkoenig.Net.Data.Responses;
internal class ListResponse: BaseApiResponse {
    [JsonPropertyName("stations")]
    public IReadOnlyList<Station> Stations { get; set; }
}
