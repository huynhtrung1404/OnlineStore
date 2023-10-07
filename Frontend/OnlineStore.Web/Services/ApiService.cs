using System.Text;
using System.Text.Json;
using OnlineStore.Web.Services.Interfaces;

namespace OnlineStore.Web.Services;
public class ApiService : IApiService
{
    private readonly HttpClient _onlineStoreClient;
    private readonly JsonSerializerOptions _options;

    public ApiService(IHttpClientFactory httpClientFactory)
    {
        _onlineStoreClient = httpClientFactory.CreateClient("OnlineStore");
        _options = new() { PropertyNameCaseInsensitive = true };
    }

    public async Task<T> GetAsync<T>(string path)
    {
        var response = await _onlineStoreClient.GetAsync(path.ToString());
        var content = await response.Content.ReadAsStringAsync();
        if (!response.IsSuccessStatusCode)
            throw new ApplicationException($"{response.StatusCode} - {response.Content}");
        return JsonSerializer.Deserialize<T>(content, _options)!;
    }

    public Task<bool> PostAsync<TBody>(string path, TBody body)
    {
        throw new NotImplementedException();
    }

    public Task<bool> PutAsync<TBody>(string path, TBody body)
    {
        throw new NotImplementedException();
    }

    public Task<bool> RemoveAsync(string path)
    {
        throw new NotImplementedException();
    }
}