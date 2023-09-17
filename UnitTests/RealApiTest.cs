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
    /*private TankerkoenigClient _client;

    [SetUp]
    public void Init() {
        var apikey = GetEnvironmentVariable("API_KEY") ?? throw new InvalidOperationException("The environment variable 'API_KEY' must be set.");
        _client = new TankerkoenigClient(apikey);
    }

    [Test]
    public async Task GetListAsync() {
        var result = await _client.ListStationsAsync(52, 8, 5);
        IReadOnlyList<Tankerkoenig.Net.Data.Station>? stations = null;
        Assert.Multiple(() => {
            Assert.That(result.TryGetValue(out stations), Is.True, GetErrorMessage(result));
            Assert.That(stations, Is.Not.Null);
            Assert.That(stations, Has.Count.AtLeast(1));
        });

        var station = stations.First();
        Assert.Multiple(() => {
            Assert.That(station.Diesel, Is.Positive);
            Assert.That(station.E5, Is.Positive);
            Assert.That(station.E10, Is.Positive);

            Assert.That(station.Id, Is.Not.EqualTo(Guid.Empty));
        });
    }

    [Test]
    public async Task GetStationAsync() {
        var result = await _client.GetStationAsync(Guid.Parse("5a17f90e-ca4b-4096-978c-13e2f5c8c6e8"));

        Assert.Multiple(() => {
            Assert.That(result.TryGetValue(out DetailedStation? station), Is.True, GetErrorMessage(result));
            Assert.That(station.Diesel, Is.Positive);
            Assert.That(station.E5, Is.Positive);
            Assert.That(station.E10, Is.Positive);

            Assert.That(station.Id, Is.Not.EqualTo(Guid.Empty));
        });

        result = await _client.GetStationAsync(Guid.Parse("ee17120e-ca4b-4096-978c-13e2f5c8c6e8"));
        Assert.That(!result.Success);
    }

    private static string GetErrorMessage<T>(Result<T> result) {
        if (result.TryGetError(out var error)) {
            return error.Message;
        }

        return "Unknown error";
    }

    private static string? GetEnvironmentVariable(string key) {
        string? var1 = Environment.GetEnvironmentVariable("API_KEY", EnvironmentVariableTarget.Machine);
        string? var2 = Environment.GetEnvironmentVariable("API_KEY", EnvironmentVariableTarget.Process);
        string? var3 = Environment.GetEnvironmentVariable("API_KEY", EnvironmentVariableTarget.User);

        if(var1 is not null) {
            return var1;
        }

        if (var2 is not null) {
            return var2;
        }

        if (var3 is not null) {
            return var3;
        }

        return null;
    }*/
}
