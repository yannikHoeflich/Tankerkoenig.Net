using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System;
using Tankerkoenig.Net;
using Tankerkoenig.Net.Data;
using Tankerkoenig.Net.Results;

namespace UnitTests;
internal class RealApiTest {
    private string _apiKey;
    TankkoenigClient _client;

    [OneTimeSetUp]
    public void OneTimeSetUp() {
        string? apiKey = Environment.GetEnvironmentVariable("tankerkoenig_api");
        if (apiKey is null) {
            throw new Exception("Please set the 'tankerkoenig_api' environment variable");
        }

        _apiKey = apiKey;
    }

    [SetUp]
    public void Setup() {
        _client = new TankkoenigClient(_apiKey);
    }

    [Test]
    public async Task List() {
        var result = await _client.ListStationsAsync(51.95584, 8.66319);
        Assert.Multiple(() => {
            Assert.That(result.TryGetError(out Exception? exception), Is.False, $"Result Not Success: {exception?.GetType()} - {exception?.Message}");
            Assert.That(result.TryGetValue(out IReadOnlyList<Station>? value), Is.True);

            Assert.That(value.Count, Is.GreaterThan(0));
        });
    }

    [Test]
    public async Task Detail() {
        Result<DetailedStation> result = await _client.GetStationAsync(Guid.Parse("005056ba-7cb6-1ed2-bceb-90e59ad2cd35"));

        Assert.Multiple(() => {
            Assert.That(result.TryGetError(out Exception? exception), Is.False, $"Result Not Success: {exception?.GetType()} - {exception?.Message}");
            Assert.That(result.TryGetValue(out DetailedStation? value), Is.True);

            Assert.That(value, Is.Not.Null);
            Assert.That(value.Id, Is.EqualTo(Guid.Parse("005056ba-7cb6-1ed2-bceb-90e59ad2cd35")));
        });
    }
}
