using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System;

namespace Tankerkoenig.Net;
public class TankerkoenigClientForTests : TankerkoenigClient {
    public TankerkoenigClientForTests(string apiKey, HttpClient httpClient) : base(apiKey) {
        httpClient.BaseAddress = new Uri(RawUri);
        _httpClient = httpClient;
    }
}
