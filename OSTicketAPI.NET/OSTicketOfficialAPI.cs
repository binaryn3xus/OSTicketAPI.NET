using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using OSTicketAPI.NET.DTO;
using OSTicketAPI.NET.Interfaces;
using OSTicketAPI.NET.Logging;

namespace OSTicketAPI.NET
{
    public class OSTicketOfficialApi : IOSTicketOfficialApi
    {
        private readonly HttpClient _client = new HttpClient();
        private readonly JsonSerializerSettings _jsonSerializerSettings;
        private readonly ILog _logger = LogProvider.For<OSTicketOfficialApi>();

        public OSTicketOfficialApi(string baseUri, string apiKey)
        {
            if (string.IsNullOrWhiteSpace(baseUri))
                throw new ArgumentException("osTicket base uri cannot be null or empty", nameof(baseUri));
            if (string.IsNullOrWhiteSpace(apiKey))
                throw new ArgumentException("osTicket api key cannot be null or empty", nameof(apiKey));

            _client.BaseAddress = new Uri(baseUri);
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            _client.DefaultRequestHeaders.Add("X-API-Key", apiKey);

            _jsonSerializerSettings = new JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            };
        }

        async Task<HttpResponseMessage> IOSTicketOfficialApi.CreateTicket(TicketCreationOptions options)
        {
            try
            {
                var json = JsonConvert.SerializeObject(options, _jsonSerializerSettings);
                var request = new HttpRequestMessage(HttpMethod.Post, "api/tickets.json")
                {
                    Content = new StringContent(json, Encoding.UTF8, "application/json")
                };
                var result = await _client.SendAsync(request);
                
                if(!result.IsSuccessStatusCode)
                    _logger.Error($"{result.ReasonPhrase}: {result.Content}");

                return result;
            }
            catch (Exception ex)
            {
                _logger.Error(ex, ex.Message);
                throw;
            }
        }
    }
}
