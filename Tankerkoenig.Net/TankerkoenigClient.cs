using System.Globalization;
using System.Net.Http.Json;
using System.Runtime.InteropServices;
using System.Text;

using Tankerkoenig.Net.Data;
using Tankerkoenig.Net.Data.Responses;
using Tankerkoenig.Net.Results;

namespace Tankerkoenig.Net;
public class TankerkoenigClient {
    protected const string s_rawUri = "https://creativecommons.tankerkoenig.de/json/";

    protected HttpClient _httpClient;

    private readonly string _apiKey;

    public TankerkoenigClient(string apiKey) : this(apiKey, CreateHttpClient()) { }

    public TankerkoenigClient(string apiKey, HttpClient httpClient) {
        _apiKey = apiKey;
        _httpClient = httpClient;
    }

    private async Task<Result<T>> RequestAsync<T>(string path, Dictionary<string, string> query) where T : BaseApiResponse {
        string uri = BuildUri(path, query);

        HttpResponseMessage response;
        try {
            response = await _httpClient.GetAsync(uri);
        } catch (Exception ex) {
            return Result.Error(ex);
        }

        if (!response.IsSuccessStatusCode) {
            return Result.Error($"status code: {response.StatusCode} content: {await response.Content.ReadAsStringAsync()}");
        }

        T? responseObject;
        try {
            responseObject = await response.Content.ReadFromJsonAsync<T>();
        } catch (Exception ex) {
            return Result.Error(ex);
        }

        if (responseObject is null) {
            return Result.Error("Api returned NULL");
        }

        if (!responseObject.Ok) {
            return Result.Error("Api Returned Error");
        }

        return Result.Ok(responseObject);
    }



    public Task<Result<IReadOnlyList<Station>>> ListStationsAsync(double lat, double lon, int radius) => ListStationsAsync(lat, lon, radius, GasType.All);

    public async Task<Result<IReadOnlyList<Station>>> ListStationsAsync(double lat, double lon, int radius, GasType gasType) {
        Result<string> gasTypeStringResult = GetGasTypeString(gasType);
        if (gasTypeStringResult.TryToErrorResult(out Result<ErrorResponse> errorResult)) {
            return errorResult;
        }

        var query = new Dictionary<string, string>() {
            {"lat", lat.ToString(CultureInfo.InvariantCulture)},
            {"lng", lon.ToString(CultureInfo.InvariantCulture)},
            {"rad", radius.ToString(CultureInfo.InvariantCulture) },
            {"type", gasTypeStringResult.GetValueOrThrow() }
        };

        Result<ListResponse> requestResult = await RequestAsync<ListResponse>("list.php", query);
        if (requestResult.TryToErrorResult(out errorResult)) {
            return errorResult;
        }

        return requestResult.TryGetValue(out ListResponse? response) && response is not null && response.Stations is not null
            ? Result.Ok(response.Stations)
            : (Result<IReadOnlyList<Station>>)Result.Error("Unknown error");
    }

    public async Task<Result<DetailedStation>> GetStationAsync(Guid stationId) {
        var query = new Dictionary<string, string>() {
            {"id", stationId.ToString()}
        };

        Result<DetailResponse> requestResult = await RequestAsync<DetailResponse>("detail.php", query);
        if (requestResult.TryToErrorResult(out Result<ErrorResponse> errorResult)) {
            return errorResult;
        }

        return requestResult.TryGetValue(out DetailResponse? response) && response is not null && response.Station is not null
            ? Result.Ok(response.Station)
            : (Result<DetailedStation>)Result.Error("Unknown error");
    }

    private string BuildUri(string path, Dictionary<string, string> query) {
        var uriBuilder = new StringBuilder();
        uriBuilder.Append(path);
        uriBuilder.Append('?');

        uriBuilder.Append("apikey");
        uriBuilder.Append('=');
        uriBuilder.Append(_apiKey);
        foreach (KeyValuePair<string, string> item in query) {
            uriBuilder.Append('&');
            uriBuilder.Append(item.Key);
            uriBuilder.Append('=');
            uriBuilder.Append(item.Value);
        }

        return uriBuilder.ToString();
    }

    private static HttpClient CreateHttpClient() => new() {
        BaseAddress = new Uri(s_rawUri)
    };

    private static Result<string> GetGasTypeString(GasType gasType) {
        return gasType switch {
            GasType.All => Result.Ok("all"),
            GasType.Diesel => Result.Ok("diesel"),
            GasType.E5 => Result.Ok("e5"),
            GasType.E10 => Result.Ok("e10"),
            _ => (Result<string>)Result.Error("Invalid gasType"),
        };
    }
}
