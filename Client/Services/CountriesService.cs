using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace ConfTool.Client.Services
{
    public class CountriesService
    {
        private HttpClient _httpClient;
        private string _countriesUrl = "https://localhost:5003/api/countries/";

        public CountriesService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<string>> ListCountries()
        {
            var result = await _httpClient.GetFromJsonAsync<List<string>>(_countriesUrl);

            return result;
        }
    }
}
