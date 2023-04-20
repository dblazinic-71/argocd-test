using System.Text.Json;
using System.Net.Http.Json;

namespace wa2
{
    public class WeatherClient
    {
        private readonly JsonSerializerOptions options = new JsonSerializerOptions()
        {
            PropertyNameCaseInsensitive = true,
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
        };

        private readonly HttpClient client;

        public WeatherClient(HttpClient client)
        {
            this.client = client;
        }

        public async Task<WeatherForecast[]> GetWeatherAsync()
        {
            var t= await client.GetFromJsonAsync<WeatherForecast[]>("/WeatherForecast", options);
            Console.WriteLine(t.ToString());
            return t;
        }
    }
}
