using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace HandyCrew.Models
{
   public class LocationHQService
    {
        private readonly HttpClient _httpClient;

        public LocationHQService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<string> ConvertCoordinatesToAddress(double latitude, double longitude)
        {

            
            // Replace with your actual API endpoint and key
            string apiKey = "pk.f96281c8a845a1a5357397e1e62bf021"; // Ensure you replace this with your actual API key
                                                                 
            string url = $"https://api.locationiq.com/v1/reverse?key={apiKey}&lat={latitude}&lon={longitude}&format=json";
        

            var response = await _httpClient.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadFromJsonAsync<LocationHQResponse>();
                Console.WriteLine($"API Response: {result}");
                return result?.FormattedAddress ?? "Address not found"; // Adjust based on the actual response structure
            }

            var responseContent = await response.Content.ReadAsStringAsync();
            Console.WriteLine($"Error: {response.StatusCode}, Content: {responseContent}");

                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                   return "Error retrieving address";
        }
    }

   public class LocationHQResponse
   {
       public string FormattedAddress { get; set; }
   }
}
