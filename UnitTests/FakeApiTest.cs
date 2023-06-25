using RichardSzalay.MockHttp;
using Tankerkoenig.Net;
using Tankerkoenig.Net.Data;
using Tankerkoenig.Net.Results;

namespace UnitTests;
public class FakeApiTest {
    TankerkoenigClient _client;
    [SetUp]
    public void Setup() {
        HttpClient httpClient = MockHttpHandlerCreator.Create();
        _client = new TankerkoenigClientForTests("00000000-0000-0000-0000-000000000000", httpClient);
    }

    [Test]
    public async Task List() {
        Result<IReadOnlyList<Station>> result = await _client.ListStationsAsync(21, 12);
        Assert.Multiple(() => {
            Assert.That(result.TryGetError(out Exception? exception), Is.False, $"Result Not Success: {exception?.GetType()} - {exception?.Message}");
            Assert.That(result.TryGetValue(out IReadOnlyList<Station>? value), Is.True);

            Assert.That(value.Count, Is.EqualTo(1));

            Station station = value[0];
            Assert.That(station.Id, Is.EqualTo(Guid.Parse("accbd20e-a086-4dd3-a2e9-e8e0978a4f64")));
            Assert.That(station.Name, Is.EqualTo("Test GasStation"));
            Assert.That(station.Brand, Is.EqualTo("Tankkoenig.NET"));
            Assert.That(station.Street, Is.EqualTo("Test Street"));
            Assert.That(station.Place, Is.EqualTo("BERLIN"));
            Assert.That(station.Lat, Is.EqualTo(52.1234));
            Assert.That(station.Lng, Is.EqualTo(8.4321));
            Assert.That(station.Dist, Is.EqualTo(3.2));
            Assert.That(station.Diesel, Is.EqualTo(1.659));
            Assert.That(station.E5, Is.EqualTo(1.889));
            Assert.That(station.E10, Is.EqualTo(1.829));
            Assert.That(station.IsOpen, Is.True);
            Assert.That(station.HouseNumber, Is.EqualTo("420"));
            Assert.That(station.PostCode, Is.EqualTo(10365));
        });
    }
}