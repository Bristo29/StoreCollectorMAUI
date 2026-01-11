using System.Net.Http.Json;

namespace StoreCollector.Maui.Services
{
    public class ApiService
    {
        private readonly HttpClient _client;

        public ApiService()
        {
            _client = new HttpClient
            {
                BaseAddress = new Uri("http://192.168.1.16:5270")
            };
        }

        public async Task<T> GetAsync<T>(string url)
        {
            return await _client.GetFromJsonAsync<T>(url);
        }

        public async Task<TResponse> PostAsync<TRequest, TResponse>(string url, TRequest data)
        {
            var result = await _client.PostAsJsonAsync(url, data);

            // opcional: lanzar si no es success
            result.EnsureSuccessStatusCode();

            return await result.Content.ReadFromJsonAsync<TResponse>();
        }

        public async Task PutAsync<TRequest>(string url, TRequest data)
        {
            var result = await _client.PutAsJsonAsync(url, data);
            // opcional: lanzar si no es success
            result.EnsureSuccessStatusCode();
        }

        public async Task DeleteAsync(string url)
        {
            var result = await _client.DeleteAsync(url);
            // opcional: lanzar si no es success
            result.EnsureSuccessStatusCode();
        }
    }
}
