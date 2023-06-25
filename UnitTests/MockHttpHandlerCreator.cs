using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using RichardSzalay.MockHttp;
using System;
using Tankerkoenig.Net;

namespace UnitTests;
internal static class MockHttpHandlerCreator {
    public static HttpClient Create() {
        var mockHttp = new MockHttpMessageHandler();

        mockHttp.When($"{TankkoenigClient.RawUri}list.php").Respond("application/json", s_listJson);
        mockHttp.When($"{TankkoenigClient.RawUri}details.php").Respond("application/json", s_detailJson);

        return mockHttp.ToHttpClient();
    }

    private const string s_listJson = """
        {
            "ok": true,
            "license": "CC BY 4.0 -  https:\/\/creativecommons.tankerkoenig.de",
            "data": "MTS-K",
            "status": "ok",
            "stations": [
                {
                    "id": "accbd20e-a086-4dd3-a2e9-e8e0978a4f64",
                    "name": "Test GasStation",
                    "brand": "Tankkoenig.NET",
                    "street": "Test Street",
                    "place": "BERLIN",
                    "lat": 52.1234,
                    "lng": 8.4321,
                    "dist": 3.2,
                    "diesel": 1.659,
                    "e5": 1.889,
                    "e10": 1.829,
                    "isOpen": true,
                    "houseNumber": "420",
                    "postCode": 10365
                }
            ]
        }
        """;

    private const string s_detailJson = """
        {
            "ok": true,
            "license": "CC BY 4.0 -  https:\/\/creativecommons.tankerkoenig.de",
            "data": "MTS-K",
            "status": "ok",
            "station": {
                "id": "accbd20e-a086-4dd3-a2e9-e8e0978a4f64",
                "name": "Test GasStation",
                "brand": "Tankkoenig.NET",
                "street": "Test Street",
                "houseNumber": "420",
                "postCode": 10365,
                "place": "BERLIN",
                "openingTimes": [
                    {
                        "text": "Mo-Fr",
                        "start": "06:00:00",
                        "end": "22:00:00"
                    },
                    {
                        "text": "Samstag",
                        "start": "07:00:00",
                        "end": "22:00:00"
                    },
                    {
                        "text": "Sonntag, Feiertag",
                        "start": "08:00:00",
                        "end": "22:00:00"
                    }
                ],
                "overrides": [],
                "wholeDay": false,
                "isOpen": true,
                "diesel": 1.659,
                "e5": 1.889,
                "e10": 1.829,
                "lat": 52.1234,
                "lng": 8.4321,
                "state": null
            }
        }
        """;
}
