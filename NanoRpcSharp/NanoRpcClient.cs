namespace NanoRpcSharp
{
    using System;
    using System.Net.Http;
    using System.Text;
    using System.Threading.Tasks;
    using Microsoft.Extensions.Logging;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;
    using Newtonsoft.Json.Serialization;

    public class NanoRpcClient : INanoRpcClient
    {
        public static readonly JsonSerializerSettings JsonSettings = new JsonSerializerSettings
        {
            ContractResolver = new DefaultContractResolver() { NamingStrategy = new SnakeCaseNamingStrategy() },
            NullValueHandling = NullValueHandling.Ignore,
        };

        private readonly HttpClient httpClient;

        private readonly ILogger logger;

        static NanoRpcClient()
        {
            JsonSettings.Converters.Add(new BigIntegerConverter());
            JsonSettings.Converters.Add(new BooleanConverter());
            JsonSettings.Converters.Add(new NullableBooleanConverter());
            JsonSettings.Converters.Add(new DateTimeOffsetConverter());
        }

        public NanoRpcClient(HttpClient httpClient, ILogger<NanoRpcClient> logger)
        {
            this.httpClient = httpClient;
            this.logger = logger;
        }

        public static string Serialize<TResponse>(RequestBase<TResponse> request)
        {
            return JsonConvert.SerializeObject(request, JsonSettings);
        }

        public static TResponse Deserialize<TResponse>(string json)
        {
            return JsonConvert.DeserializeObject<TResponse>(json, JsonSettings);
        }

        public async Task<TResponse> SendAsync<TResponse>(RequestBase<TResponse> request)
        {
            try
            {
                var reqText = Serialize(request);
                logger.LogTrace("Request:  " + reqText);

                var resp = await httpClient.PostAsync(string.Empty, new StringContent(reqText, Encoding.UTF8, "application/json"));
                resp.EnsureSuccessStatusCode();
                var respText = await resp.Content.ReadAsStringAsync();
                logger.LogTrace("Response: " + respText);

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
