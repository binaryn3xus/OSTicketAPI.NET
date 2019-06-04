using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using OSTicketAPI.NET.DTO.OfficalApi;
using OSTicketAPI.NET.Interfaces;

namespace OSTicketAPI.NET
{
    public class OSTicketOfficalApi : IOSTicketOfficalApi
    {
        private readonly HttpClient _client = new HttpClient();
        private readonly JsonSerializerSettings _jsonSerializerSettings;

        public OSTicketOfficalApi(string baseUri, string apiKey)
        {
            _client.BaseAddress = new Uri(baseUri);
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            _client.DefaultRequestHeaders.Add("X-API-Key", apiKey);

            _jsonSerializerSettings = new JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            };
        }
        
        async Task<HttpStatusCode> IOSTicketOfficalApi.CreateTicket(TicketCreationOptions options)
        {
            var json = JsonConvert.SerializeObject(options, _jsonSerializerSettings);
            var request = new HttpRequestMessage(HttpMethod.Post, "api/tickets.json")
            {
                Content = new StringContent(json, Encoding.UTF8, "application/json")
            };
            var response = await _client.SendAsync(request);
            return response.StatusCode;
        }
    }
}
