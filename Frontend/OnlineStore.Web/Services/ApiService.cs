using System.Text;
using System.Text.Json;
using OnlineStore.Web.Services.Interfaces;

namespace OnlineStore.Web.Services;
public class ApiService<T> : IApiService<T> where T : class, new()
{
    private readonly HttpClient _httpClient;
    private readonly JsonSerializerOptions _options;

    public ApiService(HttpClient httpClient)
    {
        _httpClient = httpClient;
        _options = new() { PropertyNameCaseInsensitive = true };
    }

    public async Task<T> GetAsync(string path, params string[] allParam)
    {
        var urlPath = new StringBuilder(path);
        foreach (var param in allParam)
        {
            urlPath.Append(param);
        }
        var response = await _httpClient.GetAsync(urlPath.ToString());
        var content = await response.Content.ReadAsStringAsync();
        if (!response.IsSuccessStatusCode)
            throw new ApplicationException($"{response.StatusCode} - {response.Content}");
        return JsonSerializer.Deserialize<T>(content, _options) ?? new T();
    }

    public Task<bool> PostAsync<TBody>(string path, TBody body, params string[] param)
    {
        throw new NotImplementedException();
    }

    public Task<bool> PutAsync<TBody>(string path, TBody body, params string[] param)
    {
        throw new NotImplementedException();
    }

    public Task<bool> RemoveAsync(string path, params string[] param)
    {
        throw new NotImplementedException();
    }
}