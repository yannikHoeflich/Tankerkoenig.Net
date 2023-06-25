using static System.Collections.Specialized.BitVector32;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

using System;

namespace Tankerkoenig.Net.Data.Responses;
internal abstract class BaseApiResponse {
    [JsonPropertyName("ok")]
    public bool Ok { get; set; }

    [JsonPropertyName("license")]
    public string? License { get; set; }
                 
    [JsonPropertyName("data")]
    public string? Data { get; set; }
                 
    [JsonPropertyName("status")]
    public string? Status { get; set; }
}