namespace NanoRpcSharp
{
    using System;
    using System.Net.Http;
    using System.Text;
    using System.Threading.Tasks;
    using Microsoft.Extensions.Logging;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;

    public class NanoRpcClient
    {
        private static readonly JsonSerializerSettings JsonSettings = new JsonSerializerSettings
        {
            ContractResolver = new Util.JsonLowerCaseUnderscoreContractResolver(),
            NullValueHandling = NullValueHandling.Ignore,
        };

        private readonly HttpClient httpClient;

        private readonly ILogger logger;

        static NanoRpcClient()
        {
            JsonSettings.Converters.Add(new UInt256Converter());
            JsonSettings.Converters.Add(new UnixDateTimeConverter());
            JsonSettings.Converters.Add(new LongAsStringConverter());
        }

        public NanoRpcClient(HttpClient httpClient, ILogger<NanoRpcClient> logger)
        {
            this.httpClient = httpClient;
            this.logger = logger;
        }

        public async Task<TResponse> SendAsync<TResponse>(RequestBase<TResponse> request)
        {
            try
            {
                var reqText = JsonConvert.SerializeObject(request, JsonSettings);
                logger.LogDebug("Request:  " + reqText);
                var resp = await httpClient.PostAsync("/", new StringContent(reqText, Encoding.UTF8, "application/json"));
                resp.EnsureSuccessStatusCode();
                var respText = await resp.Content.ReadAsStringAsync();
                logger.LogDebug("Response: " + respText);

                var obj = JObject.Parse(respText);
                var errorText = obj["error"];
                if (errorText != null)
                {
                    throw new ErrorResponseException(errorText.Value<string>());
                }
                else
                {
                    return obj.ToObject<TResponse>(JsonSerializer.CreateDefault(JsonSettings));
                }
            }
            catch (HttpRequestException ex)
            {
                logger.LogError($"An error occurred connecting to NANO RPC: {ex}");
                throw;
            }
        }
    }
}
