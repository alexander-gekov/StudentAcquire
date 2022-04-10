using System;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using StudentAcquire.Listing.Service.Dtos;

namespace StudentAcquire.Listing.Service.SyncDataServices.Http
{
    public class HttpUserDataClient : IUserDataClient
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;

        public HttpUserDataClient(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _configuration = configuration;
        }
        public async Task SendListingToUser(ListingReadDto listing)
        {
            var httpContent = new StringContent(
                JsonSerializer.Serialize(listing),
                Encoding.UTF8,
                "application/json");

            var response = await _httpClient.PostAsync($"{_configuration["UserService"]}/api/u/listings", httpContent);

            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("Ok");
            }
            else
            {
                Console.WriteLine("not ok");
            }
        }
    }
}